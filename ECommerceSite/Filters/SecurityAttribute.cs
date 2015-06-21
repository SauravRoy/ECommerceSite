using System.Web.Mvc;
using System.Web.Routing;

namespace EcommerceServiceLayer.Filters
{
    public class CustomAuthorize : ActionFilterAttribute
    {
        private string _controllerName { get; set; }
        private string _actionName { get; set; }

        public CustomAuthorize(string ControllerName, string ActionName)
        {
            _controllerName = ControllerName;
            _actionName = ActionName;
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if(filterContext.HttpContext.Request.Cookies.Count<=0)
            {
                filterContext.Result = new RedirectToRouteResult(
                new RouteValueDictionary
                {
                    { "controller", _controllerName },
                    { "action", _actionName }
                });
            }
        }
        
    }
}