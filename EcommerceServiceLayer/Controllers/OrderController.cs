using System;
using System.Collections.Generic;
using System.Web.Http;
using EcommerceDAL;
using DomainEntitites;

namespace EcommerceServiceLayer.Controllers
{
    public class OrderController : ApiController
    {
        

        // GET api/values/5
        public string Get(string id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]OrderModel orderModel)
        {
            // Use auto mapper for domain to entity conversion 

            Order order = new Order();

            Product prod = new Product() { Price = orderModel.products[0].Price, Name = orderModel.products[0].ProductName, Id = orderModel.products[0].Id };

            var prodOrder = new Order { OrderDate = DateTime.Today, Product = prod, Qty = 1, Status = 1, UserId = 1, Total = 100 };
            DAL.AddOrder(prodOrder);


        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
