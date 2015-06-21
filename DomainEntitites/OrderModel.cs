using System;
using System.Collections.Generic;


namespace DomainEntitites
{
    public class OrderModel
    {
        public List<Products> products { get; set; }
        public int UserId { get; set; }
        public int OrderId { get; set; }
        public bool Visible { get; set; }
        public List<Products> SelectedProducts { get; set; }

    }
}
