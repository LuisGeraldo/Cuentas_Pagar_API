using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using prjCuentasxcobrar.Services;

namespace prjCuentasxcobrar.Models
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IAccountService _IAccountService;
        public AccountController(IAccountService IAccountService)
        {
            _IAccountService = IAccountService;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Authenticate([FromBody] Login Model)
        {
            IActionResult response = Unauthorized();
            var user = _IAccountService.Login(Model);

            if (user != null)
            {
                var tokenString = _IAccountService.CreateToken(user);
                response = Ok(new { Success = true, token = tokenString, user = Model });
            }
            else
            {
                response = BadRequest(new { Success = false,  Message = "Las credenciales son incorrectas"});
            }

            return response;
        }
    }
}
