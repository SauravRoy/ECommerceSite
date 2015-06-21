using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.OData.Extensions;

namespace learningMVC.App_Start
{
    public class WebApiConfig
    {

        public static void Register(System.Web.Http.HttpConfiguration config)
        {
            System.Web.Http.OData.Builder.ODataConventionModelBuilder builder = new System.Web.Http.OData.Builder.ODataConventionModelBuilder();
            builder.EntitySet<Models.Employee>("Employee");
            config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
        }
    }
}