
using System.Collections.Generic;


namespace ECommerceSite.Models
{
    public class OrderModel
    {
        public List<ProductModel> products { get; set; }
        public int UserId { get; set; }
        public int OrderId { get; set; }
        public bool Visible { get; set; }
        public List<ProductModel> SelectedProducts { get; set; }

    }
}