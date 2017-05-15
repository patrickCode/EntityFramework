using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.Owin.Security.OAuth;

namespace SPA_Authentication.Providers
{
    public class SimpleAuthorizationServerProvider: OAuthAuthorizationServerProvider
    {
        //Used for validating the client
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {   
            context.Validated();
        }

        //Validates username and password sent to the Authorization token endpoint
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            //For allowing CORS
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
            using (var authRepository = new AuthRepository())
            {
                var user = await authRepository.FindUser(context.UserName, context.Password);
                if (user == null)
                {
                    context.SetError("invalid_grant", "The user name or password is incorrect");
                    return;
                }
            }

            //Create the claims identity if the username/password is correct. (Authentication Type is Bearer)
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim("sub", context.UserName));
            identity.AddClaim(new Claim("role", "user"));

            context.Validated(identity); ///Token is generated behind the screens
        }
    }
}