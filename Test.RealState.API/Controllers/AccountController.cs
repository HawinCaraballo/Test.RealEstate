
namespace Test.RealEstate.API.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Test.RealEstate.Application.Interfaces.Identity;
    using Test.RealEstate.Application.Models.Account;

    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<AuthenticationResponse>> Login([FromBody] AuthenticationRequest request)
        {
            return Ok(await _accountService.Login(request));
        }

        [HttpPost("Register")]
        public async Task<ActionResult<RegisterResponse>> Register([FromBody] RegisterRequest request)
        {
            return Ok(await _accountService.Register(request));
        }
    }
}
