using CarFactory.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace CarFactory.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class SimpleAuthorizeAttribute : AuthorizeAttribute
    {

        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized,
                "CAUTION: Your call is unauthorized");
        }

        protected override bool IsAuthorized(HttpActionContext actionContext)
        {

            var baseIsAuthorized = base.IsAuthorized(actionContext);
            if (!baseIsAuthorized)
            {
                return false;
            }

            var simpleAuthorizeAttribute =
                actionContext.ActionDescriptor.GetCustomAttributes<SimpleAuthorizeAttribute>(false).FirstOrDefault() ??
                actionContext.ActionDescriptor.ControllerDescriptor.GetCustomAttributes<SimpleAuthorizeAttribute>(true).FirstOrDefault();
            if (simpleAuthorizeAttribute == null)
            {
                return true;
            }
            return baseIsAuthorized;

        }
    }
}