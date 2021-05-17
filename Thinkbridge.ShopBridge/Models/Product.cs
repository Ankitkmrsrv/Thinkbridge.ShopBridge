using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Thinkbridge.ShopBridge.Models
{
    public class Product
    {
        public string Name { get; set; }
        public decimal? price { get; set; }
        public string ProductImage { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
    }
}