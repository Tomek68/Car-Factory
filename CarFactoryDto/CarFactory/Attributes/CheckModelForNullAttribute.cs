using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace CarFactory.Attributes
{
    public class CheckModelForNullAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var nullArgs =
                actionContext.ActionArguments.Where(kv => kv.Value == null)
                    .Select(kv => string.Format("The argument '{0}' cannot be null", kv.Key))
                    .ToArray();
            if (nullArgs.Any())
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.BadRequest,
                    string.Join("\n", nullArgs));
            }
        }
    }
}