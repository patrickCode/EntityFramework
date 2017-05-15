using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SPA_Authentication.Models;
using System;
using System.Threading.Tasks;

namespace SPA_Authentication
{
    public class AuthRepository : IDisposable
    {
        private AuthContext _authContext;
        private UserManager<IdentityUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        
        public AuthRepository()
        {
            _authContext = new AuthContext();
            _userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(_authContext));
            _roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(_authContext));

        }

        public async Task<IdentityResult> RegisterUser(UserModel userModel)
        {
            var user = new IdentityUser
            {
                UserName = userModel.UserName,
                Email = userModel.Email,
                PhoneNumber = userModel.Phone
            };
            var result = await _userManager.CreateAsync(user, userModel.Password);

            var role = _roleManager.FindByName(userModel.Role);
            _userManager.AddToRole(user.Id, role.Name);

            return result;
        }
        //https://code.msdn.microsoft.com/ASPNET-MVC-5-Security-And-44cbdb97/sourcecode?fileId=147300&pathId=144741120

        public async Task<IdentityUser> FindUser(string userName, string password)
        {
            var user = await _userManager.FindAsync(userName, password);
            return user;
        }

        public void Dispose()
        {
            _authContext.Dispose();
            _userManager.Dispose();
        }
    }
}