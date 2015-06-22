using System.Web.Mvc;
using System.Web.Routing;

namespace EcommerceServiceLayer.Filters
{
    public class CustomAuthorize : ActionFilterAttribute
    {
       
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if(filterContext.HttpContext.Request.Cookies.Count<=0)
            {
                filterContext.Result = new RedirectToRouteResult(
                new RouteValueDictionary
                {
                    { "controller", "LogOn" },
                    { "action", "Index" }
                });
            }
        }
        
    }
}