using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Filters;

namespace learningMVC.Filters
{
    public class CustomErrorAttriute : FilterAttribute,IExceptionFilter
    {
        public Task  ExecuteExceptionFilterAsync(HttpActionExecutedContext actionExecutedContext, System.Threading.CancellationToken cancellationToken)
        {

            throw new NotImplementedException();

        }

    }
}