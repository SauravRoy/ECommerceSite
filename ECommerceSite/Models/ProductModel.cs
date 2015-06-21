using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerceSite.Models
{
    public class ProductModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int Qty { get; set; }

    }
}