using Microsoft.AspNetCore.Mvc;
using PropertySystemProject.Domain.DTOs;
using PropertySystemProject.Domain.Interfaces.Service;

namespace PropertySystemProject.Application.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    public class AccountController(IAccountService accountService) : ControllerBase
    {
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await accountService.LoginAsync(model);
            if (!response.Flag)
                return Unauthorized(response.Message);

            return Ok(new { Token = response.JWTToken });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await accountService.RegisterAsync(model);
            if (!response.Flag)
                return BadRequest(response.Message);

            return Ok(response.Message);
        }
    }
}
