using Microsoft.AspNetCore.Mvc;
using ShipInfo.DOMAIN;

namespace ShipInfo.WebAPI
{
    [ApiController]
    [Produces("application/json")]
    [Route("users")]

    public class AccountController : ControllerBase
    {

        private readonly AccountService _accountService;

        public AccountController(AccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("registration")]
        public async Task<IActionResult> RegisterUserAsync([FromBody] UserRegisterRequest userReg)
        {
            var result = await _accountService.RegisterUser(userReg);

            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] UserLogginRequest userLog)
        {
            var response = await _accountService.Login(userLog);

            return Ok(response);
        }

    }
}
