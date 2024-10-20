using Microsoft.AspNetCore.Mvc;
using PropertySystemProject.Domain.Entities;
using PropertySystemProject.Domain.Interfaces.Service;
using System.Net;

namespace PropertySystemProject.Application.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    public class PropertyController(IPropertyService propertyService) : ControllerBase
    {
        /// <summary>
        /// Busca todos os imóveis e seus endereços cadastrados 
        /// </summary>
        /// <returns>Retorna uma lista de imóveis com seus respectivos endereços</returns>
        [ProducesResponseType(typeof(List<Property>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
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
    }
}
