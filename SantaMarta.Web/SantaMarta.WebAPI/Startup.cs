using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System.Web.Http;
using SantaMarta.WebAPI.Provider;

[assembly: OwinStartup(typeof(SantaMarta.WebAPI.Startup))]
namespace SantaMarta.WebAPI
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            ConfigureOAuth(app);

            WebApiConfig.Register(config);
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.UseWebApi(config);

        }

        private void ConfigureOAuth(IAppBuilder app)
        {  
 
        app.UseOAuthAuthorizationServer(new OAuthAuthorizationServerOptions
        {
            TokenEndpointPath = new PathString("/token"),
            Provider = new SimpleAuthorizationServerProvider(),
            AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(60),
            AllowInsecureHttp = true,

        });
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}