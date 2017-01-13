using CarFactory.Providers;
using CarFactory.Services;
using CarFactory.Utils;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
[assembly: OwinStartup(typeof(CarFactory.App_Start.Startup))]
namespace CarFactory.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);
            ConfigureOAuth(app);

            app.UseWebApi(config);
        }

        public void ConfigureOAuth(IAppBuilder app)
        {
            var oAuthServerOptions = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(AppConfiguration.AccessTokenExpireTimeInMin),
                Provider = new SimpleAuthorizationServerProvider(new AuthService()),
                RefreshTokenProvider = new SimpleRefreshTokenProvider(new TokenService())
            };

            app.UseOAuthAuthorizationServer(oAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}