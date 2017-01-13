using CarFactory.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CarFactory
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Filters.Add(new CheckModelForNullAttribute());
            config.Filters.Add(new SimpleAuthorizeAttribute());
            config.Filters.Add(new RequestExceptionAttribute());

            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
