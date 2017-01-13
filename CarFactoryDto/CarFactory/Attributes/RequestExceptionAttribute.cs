using CarFactory.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;

namespace CarFactory.Attributes
{
    public class RequestExceptionAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionContext)
        {
            string message =
                $"[{actionContext.Request.Method}] {actionContext.Request.RequestUri}";

            var baseApiController = actionContext.ActionContext.ControllerContext.Controller as CarsBaseController;
            baseApiController?.Logger.Error(actionContext.Exception, message);

            base.OnException(actionContext);
        }
    }
}