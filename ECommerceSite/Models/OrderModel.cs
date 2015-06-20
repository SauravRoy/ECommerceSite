using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerceSite.Models
{
    public class OrderModel
    {
        public List<ProductModel> products { get; set; }
        public int UserId { get; set; }
        public int OrderId { get; set; }
    }
}