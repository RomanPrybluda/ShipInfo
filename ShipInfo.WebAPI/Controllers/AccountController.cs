using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShipInfo.Domain;

namespace ShipInfo.WebAPI
{
    [ApiController]
    [Produces("application/json")]
    //[Authorize]
    [Route("accounts")]

    public class AccountController : ControllerBase
    {

        private readonly AccountService _accountService;

        public AccountController(AccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("user-registration")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> RegisterUserAsync([FromBody] UserRegisterRequest userReg)
        {
            var result = await _accountService.RegisterUser(userReg);

            return Ok(result);
        }

        [HttpPost("user-login")]
        [AllowAnonymous]
        public async Task<IActionResult> LoginAsync([FromBody] UserLogginRequest userLog)
        {
            var response = await _accountService.Login(userLog);

            return Ok(response);
        }

    }
}
