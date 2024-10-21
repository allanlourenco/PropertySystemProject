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
        /// Busca todos os imóveis e seu endereço cadastrado 
        /// </summary>
        /// <returns>Retorna uma lista de imóveis com seu endereço cadastrado</returns>
        [ProducesResponseType(typeof(List<PropertyResponseDTO>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [HttpGet]
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPropertyById(Guid id)
        {
            var property = await propertyService.GetPropertyByIdAsync(id);
            if (property == null) return NotFound();
            return Ok(property);
        }

        [Authorize]
        [HttpPost]
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

        [Authorize]
        [HttpPut("{id}")]
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

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProperty(Guid id)
        {
            await propertyService.DeletePropertyAsync(id);
            return NoContent();
        }
    }
}
