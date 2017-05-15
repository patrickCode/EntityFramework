using Microsoft.AspNet.Identity.EntityFramework;

namespace SPA_Authentication
{
    public class AuthContext: IdentityDbContext<IdentityUser>
    {
        public AuthContext()
            : base("AuthContext")
        {

        }
    }
}