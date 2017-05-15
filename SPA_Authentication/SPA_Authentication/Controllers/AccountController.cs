using System.Web.Http;
using System.Threading.Tasks;
using SPA_Authentication.Models;
using Microsoft.AspNet.Identity;

namespace SPA_Authentication.Controllers
{
    [RoutePrefix("api/account")]
    public class AccountController : ApiController
    {
        private readonly AuthRepository _repository;
        public AccountController()
        {
            _repository = new AuthRepository();
        }


        /*{
          "userName": "Admin",
          "password": "@dmin23!",
          "confirmPassword": "@dmin23!"
        }*/
        [Route("Register")]
        public async Task<IHttpActionResult> Register(UserModel userModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _repository.RegisterUser(userModel);
            var errorResult = GetErrorResult(result);

            if (errorResult != null)
            {
                return errorResult;
            }

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _repository.Dispose();
            }
            base.Dispose(disposing);
        }

        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
                return InternalServerError();

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    return BadRequest();
                }
                return BadRequest(ModelState);
            }
            return null;
        }
    }
}