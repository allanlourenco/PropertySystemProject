using Microsoft.AspNetCore.Mvc;
using PropertySystemProject.Domain.DTOs;
using PropertySystemProject.Domain.Interfaces.Service;

namespace PropertySystemProject.Application.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    public class AccountController(IAccountService accountService) : ControllerBase
    {
        /// <summary>
        /// Autentica um usuário e retorna um token JWT.
        /// </summary>
        /// <param name="model">Objeto contendo os dados de login (usuário e senha).</param>
        /// <returns>Retorna um token JWT se a autenticação for bem-sucedida. Caso contrário, retorna uma resposta de erro.</returns>
        /// <response code="200">Autenticação bem-sucedida, token JWT retornado.</response>
        /// <response code="400">Requisição inválida, os dados fornecidos estão incorretos ou incompletos.</response>
        /// <response code="401">Autenticação falhou, credenciais inválidas.</response>
        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Login([FromBody] LoginDTO model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await accountService.LoginAsync(model);
            if (!response.Flag)
                return Unauthorized(response.Message);

            return Ok(new { Token = response.JWTToken });
        }

        /// <summary>
        /// Registra um novo usuário no sistema.
        /// </summary>
        /// <param name="model">Objeto contendo os dados de registro do usuário.</param>
        /// <returns>Retorna uma mensagem de sucesso se o registro for bem-sucedido. Caso contrário, retorna uma resposta de erro.</returns>
        /// <response code="200">Registro bem-sucedido, mensagem de sucesso retornada.</response>
        /// <response code="400">Requisição inválida, os dados fornecidos estão incorretos ou incompletos.</response>
        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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
