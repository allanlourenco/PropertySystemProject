using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PropertySystemProject.Domain.DTOs;
using PropertySystemProject.Domain.Entities;
using PropertySystemProject.Domain.Interfaces.Service;
using System.Net;

namespace PropertySystemProject.Application.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    public class PropertiesController(IPropertyService propertyService) : ControllerBase
    {
        /// <summary>
        /// Busca todos os imóveis e seus endereços cadastrados.
        /// </summary>
        /// <returns>Retorna uma lista de imóveis com seus endereços.</returns>
        /// <response code="200">Retorna a lista de imóveis com sucesso.</response>
        /// <response code="400">Erro ao processar a solicitação.</response>
        [HttpGet]
        [ProducesResponseType(typeof(List<PropertyResponseDTO>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAllProperties()
        {
            try
            {
                return Ok(await propertyService.GetAllPropertiesAsync());
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex, "Ocorreu um erro etapa processo");
                //var retorno = new OperationResponse<bool>();
                //retorno.Messages.Add(new OperationMessage() { Description = "Problema retornar dados. " + ex, Type = OperationMessageTypes.Error });
                return BadRequest(ex.Message);
            }

        }

        /// <summary>
        /// Busca um imóvel específico pelo ID.
        /// </summary>
        /// <param name="id">ID do imóvel.</param>
        /// <returns>Retorna os detalhes do imóvel, se encontrado.</returns>
        /// <response code="200">Imóvel encontrado com sucesso.</response>
        /// <response code="404">Imóvel não encontrado.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PropertyResponseDTO), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetPropertyById(Guid id)
        {
            var property = await propertyService.GetPropertyByIdAsync(id);
            if (property == null) return NotFound();
            return Ok(property);
        }

        /// <summary>
        /// Adiciona um novo imóvel ao sistema.
        /// </summary>
        /// <param name="propertyDTO">Objeto contendo os dados do imóvel a ser cadastrado.</param>
        /// <returns>Retorna os detalhes do imóvel recém-criado.</returns>
        /// <response code="201">Imóvel criado com sucesso.</response>
        /// <response code="400">Erro ao criar o imóvel, dados inválidos.</response>
        [Authorize]
        [HttpPost]
        [ProducesResponseType(typeof(PropertyResponseDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddProperty([FromBody] PropertyRequestDTO propertyDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var propertyResponseDTO = await propertyService.AddPropertyAsync(propertyDTO);

            if (propertyResponseDTO == null)
            {
                return BadRequest("Erro ao criar o imóvel.");
            }

            return CreatedAtAction(nameof(GetPropertyById), new { id = propertyResponseDTO.Id }, propertyResponseDTO);
        }

        /// <summary>
        /// Atualiza os dados de um imóvel existente.
        /// </summary>
        /// <param name="id">ID do imóvel a ser atualizado.</param>
        /// <param name="propertyDTO">Objeto contendo os novos dados do imóvel.</param>
        /// <returns>Retorna NoContent se a atualização for bem-sucedida.</returns>
        /// <response code="204">Imóvel atualizado com sucesso.</response>
        /// <response code="400">Erro ao processar a solicitação, dados inválidos.</response>
        /// <response code="404">Imóvel não encontrado.</response>
        [Authorize]
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateProperty(Guid id, [FromBody] PropertyRequestDTO propertyDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);             }

            var propertyResponseDTO = await propertyService.UpdatePropertyAsync(id, propertyDTO);

            if (propertyResponseDTO == null)
            {
                return NotFound("Imóvel não encontrado.");
            }

            return NoContent();
        }

        /// <summary>
        /// Exclui um imóvel existente.
        /// </summary>
        /// <param name="id">ID do imóvel a ser excluído.</param>
        /// <returns>Retorna NoContent se a exclusão for bem-sucedida.</returns>
        /// <response code="204">Imóvel excluído com sucesso.</response>
        [Authorize]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteProperty(Guid id)
        {
            await propertyService.DeletePropertyAsync(id);
            return NoContent();
        }
    }
}
