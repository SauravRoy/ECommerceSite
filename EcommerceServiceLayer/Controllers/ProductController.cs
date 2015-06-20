using System;
using System.Collections.Generic;
using System.Web.Http;
using EcommerceDAL;

namespace EcommerceServiceLayer.Controllers
{
    public class ProductController : ApiController
    {
        // GET api/values
        public IEnumerable<Product> Get()
        {
            return DAL.GetProducts();
        }

        // GET api/values/5
        public string Get(string id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
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
