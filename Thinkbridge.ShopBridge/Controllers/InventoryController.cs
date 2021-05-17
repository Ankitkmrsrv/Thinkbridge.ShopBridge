using log4net;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using System.Web.Http;
using Thinkbridge.ShopBridge.Models;

namespace Thinkbridge.ShopBridge.Controllers
{
    public class InventoryController : ApiController
    {
        ILog log;
        public IHttpActionResult Get()
        {
            try
            {
                List<usp_RetieveInventory_Result> response = new List<usp_RetieveInventory_Result>();
                using (DatabaseEntities db = new DatabaseEntities())
                {
                    var data = db.usp_RetieveInventory();
                    foreach (var item in data)
                    {
                        response.Add(item);
                    }
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                var error = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent("Error ", System.Text.Encoding.UTF8, "text/plain")
                };
                throw new HttpResponseException(error);
            }
        }

        // POST api/<controller>
        public IHttpActionResult Post([FromBody] usp_RetieveInventory_Result product)
        {
            log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            usp_RetieveInventory_Result response = product;
            Guid inventoryId = Guid.NewGuid();
            try
            {
                using (DatabaseEntities db = new DatabaseEntities())
                {
                    log.Info(product);
                    db.usp_CreateInventory(inventoryId, product.name, product.price, product.productimage, product.quantity, product.description);
                    log.Info("product created with id " + inventoryId);
                }
                response.inventoryid = inventoryId;
                return Ok(response);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                var error = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent("Error ", System.Text.Encoding.UTF8, "text/plain")
                };
                throw new HttpResponseException(error);
            }
        }

        // PUT api/<controller>/5
        public IHttpActionResult Put(Guid id, [FromBody] usp_RetieveInventory_Result product)
        {
            log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            usp_RetieveInventory_Result response = product;
            try
            {
                using (DatabaseEntities db = new DatabaseEntities())
                {
                    log.Info(product);
                    db.usp_UpdateInventory(id, product.name, product.price, product.productimage, product.quantity, product.description);
                    log.Info("product updated with id " + id);
                }
                response.inventoryid = id;
                return Ok(response);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                var error = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent("Error", System.Text.Encoding.UTF8, "text/plain")
                };
                throw new HttpResponseException(error);
            }
        }

        // DELETE api/<controller>/5
        public IHttpActionResult Delete(Guid id)
        {
            try
            {
                using (DatabaseEntities db = new DatabaseEntities())
                {
                    var response = db.usp_DeleteInventory(id);
                }
                return Ok("record deleted");
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                var error = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent("Error ", System.Text.Encoding.UTF8, "text/plain"),
                    StatusCode = HttpStatusCode.InternalServerError
                };
                throw new HttpResponseException(error);
            }
        }
    }
}