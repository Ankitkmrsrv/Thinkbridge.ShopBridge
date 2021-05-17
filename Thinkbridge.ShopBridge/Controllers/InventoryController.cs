using log4net;
using log4net.Config;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using Thinkbridge.ShopBridge.Models;

[assembly: log4net.Config.XmlConfigurator(ConfigFile = "Web.config")]
namespace Thinkbridge.ShopBridge.Controllers
{
    public class InventoryController : ApiController
    {
        ILog log;
        //public InventoryController()
        //{
        //    XmlConfigurator.Configure();
        //}
        // GET api/<controller>
        public IEnumerable<Product> Get()
        {
            // List<usp_RetieveInventory_Result> response = new List<usp_RetieveInventory_Result>();
            dynamic response; // = new ObjectResult<usp_RetieveInventory_Result>();
            using (DatabaseEntities db = new DatabaseEntities())
            {
                response = db.usp_RetieveInventory();
            }
            return Json(response);
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody] Product product)
        {
            log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            log.Info("test log");
            using (DatabaseEntities db = new DatabaseEntities())
            {
                var response = db.usp_CreateInventory(product.Name, product.price, product.ProductImage, product.Quantity, product.Description);
            }
            log.Error("error here");
        }

        // PUT api/<controller>/5
        public void Put(Guid id, [FromBody] Product product)
        {
            using (DatabaseEntities db = new DatabaseEntities())
            {
                var response = db.usp_UpdateInventory(id, product.Name, product.price, product.ProductImage, product.Quantity, product.Description);
            }
        }

        // DELETE api/<controller>/5
        public void Delete(Guid id)
        {
            using (DatabaseEntities db = new DatabaseEntities())
            {
                var response = db.usp_DeleteInventory(id);
            }
        }
    }
}