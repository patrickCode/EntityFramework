using Owin;
using System;
using Microsoft.Owin;
using System.Web.Http;
using Microsoft.Owin.Cors;
using SPA_Authentication.Providers;
using Microsoft.Owin.Security.OAuth;

[assembly: OwinStartup(typeof(SPA_Authentication.Startup))]

namespace SPA_Authentication
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureOAuth(app);
            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);
            app.UseCors(CorsOptions.AllowAll);
            app.UseWebApi(config);
        }
        
        public void ConfigureOAuth(IAppBuilder app)
        {
            var oAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),   //Token endpoint where to get the token from. POST api/token Content-Type: application/x-www-form-urlencoded {grant_type=password&username=admin&password=@dmin23!}
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new SimpleAuthorizationServerProvider()
            };

            //Token Generation
            app.UseOAuthAuthorizationServer(oAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}