using System.Net.Http;
using System.Net;
using DomainEntitites;
using System.Web.Http;
using EcommerceDAL;

namespace EcommerceServiceLayer.Controllers
{
    public class AuthController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage Post([FromBody]User user)
        {

            EcommerceDAL.DAL.AddUser(user);
            return new HttpResponseMessage() { StatusCode = HttpStatusCode.OK, ReasonPhrase = "Successfully Added !" };

        }

        public HttpResponseMessage Get(string id)
        {
            
            return EcommerceDAL.DAL.GetUser(id)== null ?  new HttpResponseMessage(HttpStatusCode.NotFound) :  new HttpResponseMessage(HttpStatusCode.OK);

        }
    }
}
