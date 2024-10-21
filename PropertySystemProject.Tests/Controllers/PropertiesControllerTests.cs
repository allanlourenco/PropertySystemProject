using Microsoft.AspNetCore.Mvc;
using Moq;
using PropertySystemProject.Application.Controllers;
using PropertySystemProject.Domain.DTOs;
using PropertySystemProject.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PropertySystemProject.Tests.Controllers
{
    [TestFixture]
    public class PropertiesControllerTests
    {
        private Mock<IPropertyService> _propertyServiceMock;
        private PropertiesController _controller;

        [SetUp]
        public void Setup()
        {
            _propertyServiceMock = new Mock<IPropertyService>();
            _controller = new PropertiesController(_propertyServiceMock.Object);
        }

        [Test]
        public async Task GetAllProperties_ReturnsOkResult_WithProperties()
        {
            var properties = new List<PropertyResponseDTO>
            {
                
                new PropertyResponseDTO { Id = Guid.NewGuid(), Area = 100, NumberBathrooms = 3, NumberRooms = 3, Price = 500000, Status = Domain.Enums.StatusImovel.Disponivel, Type = Domain.Enums.TipoImovel.Casa, Title = "Imovel 10", Address = new AddressRequestDTO { CEP = "05565666", City = "São Paulo", Complement = "", Number = 200, State = "sp", Street = "Rua José" }  },
                new PropertyResponseDTO { Id = Guid.NewGuid(), Area = 100, NumberBathrooms = 3, NumberRooms = 3, Price = 500000, Status = Domain.Enums.StatusImovel.Disponivel, Type = Domain.Enums.TipoImovel.Casa, Title = "Imovel 10", Address = new AddressRequestDTO { CEP = "05565666", City = "São Paulo", Complement = "", Number = 200, State = "sp", Street = "Rua José" }  }
            };
            _propertyServiceMock.Setup(service => service.GetAllPropertiesAsync())
                .ReturnsAsync(properties);

            var result = await _controller.GetAllProperties();

            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual((int)HttpStatusCode.OK, okResult.StatusCode);
            Assert.AreEqual(properties, okResult.Value);
        }

        [Test]
        public async Task GetPropertyById_ReturnsOkResult_WhenPropertyExists()
        {
            var propertyId = Guid.NewGuid();
            var property = new PropertyResponseDTO { Id = propertyId, Area = 100, NumberBathrooms = 3, NumberRooms = 3, Price = 500000, Status = Domain.Enums.StatusImovel.Disponivel, Type = Domain.Enums.TipoImovel.Casa, Title = "Imovel 10", Address = new AddressRequestDTO { CEP = "05565666", City = "São Paulo", Complement = "", Number = 200, State = "sp", Street = "Rua José" } };
            _propertyServiceMock.Setup(service => service.GetPropertyByIdAsync(propertyId))
                .ReturnsAsync(property);

            var result = await _controller.GetPropertyById(propertyId);

            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual((int)HttpStatusCode.OK, okResult.StatusCode);
            Assert.AreEqual(property, okResult.Value);
        }

        [Test]
        public async Task GetPropertyById_ReturnsNotFound_WhenPropertyDoesNotExist()
        {
            var propertyId = Guid.NewGuid();
            _propertyServiceMock.Setup(service => service.GetPropertyByIdAsync(propertyId))
                .ReturnsAsync((PropertyResponseDTO)null);

            var result = await _controller.GetPropertyById(propertyId);

            Assert.IsInstanceOf<NotFoundResult>(result);
        }

        [Test]
        public async Task AddProperty_ReturnsCreatedAtAction_WhenPropertyIsValid()
        {
            var propertyDTO = new PropertyRequestDTO { Area = 100, NumberBathrooms = 3, NumberRooms = 3, Price = 500000, Status = Domain.Enums.StatusImovel.Disponivel, Type = Domain.Enums.TipoImovel.Casa, Title = "Imovel 10", Address = new AddressRequestDTO { CEP = "05565666", City = "São Paulo", Complement = "", Number = 200, State = "sp", Street = "Rua José" } };
            var propertyResponseDTO = new PropertyResponseDTO {Id = Guid.NewGuid(), Area = 100, NumberBathrooms = 3, NumberRooms = 3, Price = 500000, Status = Domain.Enums.StatusImovel.Disponivel, Type = Domain.Enums.TipoImovel.Casa, Title = "Imovel 10", Address = new AddressRequestDTO { CEP = "05565666", City = "São Paulo", Complement = "", Number = 200, State = "sp", Street = "Rua José" } };
            _propertyServiceMock.Setup(service => service.AddPropertyAsync(propertyDTO))
                .ReturnsAsync(propertyResponseDTO);

            var result = await _controller.AddProperty(propertyDTO);

            var createdResult = result as CreatedAtActionResult;
            Assert.IsNotNull(createdResult);
            Assert.AreEqual((int)HttpStatusCode.Created, createdResult.StatusCode);
            Assert.AreEqual(nameof(_controller.GetPropertyById), createdResult.ActionName);
            Assert.AreEqual(propertyResponseDTO.Id, createdResult.RouteValues["id"]);
            Assert.AreEqual(propertyResponseDTO, createdResult.Value);
        }

        [Test]
        public async Task AddProperty_ReturnsBadRequest_WhenModelStateIsInvalid()
        {
            _controller.ModelState.AddModelError("Error", "Invalid model");

            var result = await _controller.AddProperty(new PropertyRequestDTO() { Area = 100, NumberBathrooms = 3, NumberRooms = 3, Price = 500000, Status = Domain.Enums.StatusImovel.Disponivel, Type = Domain.Enums.TipoImovel.Casa, Title = "Imovel 10", Address = new AddressRequestDTO { CEP = "05565666", City = "São Paulo", Complement = "", Number = 200, State = "sp", Street = "Rua José" } });

            Assert.IsInstanceOf<BadRequestObjectResult>(result);
        }

        [Test]
        public async Task UpdateProperty_ReturnsNoContent_WhenUpdateIsSuccessful()
        {
            var propertyId = Guid.NewGuid();
            var propertyDTO = new PropertyRequestDTO { Area = 100, NumberBathrooms = 3, NumberRooms = 3, Price = 500000, Status = Domain.Enums.StatusImovel.Disponivel, Type = Domain.Enums.TipoImovel.Casa, Title = "Imovel 10", Address = new AddressRequestDTO { CEP = "05565666", City = "São Paulo", Complement = "", Number = 200, State = "sp", Street = "Rua José" } };
            _propertyServiceMock.Setup(service => service.UpdatePropertyAsync(propertyId, propertyDTO))
                .ReturnsAsync(new PropertyResponseDTO {Id = propertyId, Area = 100, NumberBathrooms = 3, NumberRooms = 3, Price = 500000, Status = Domain.Enums.StatusImovel.Disponivel, Type = Domain.Enums.TipoImovel.Casa, Title = "Imovel 10", Address = new AddressRequestDTO { CEP = "05565666", City = "São Paulo", Complement = "", Number = 200, State = "sp", Street = "Rua José" } });

            var result = await _controller.UpdateProperty(propertyId, propertyDTO);

            Assert.IsInstanceOf<NoContentResult>(result);
        }

        [Test]
        public async Task UpdateProperty_ReturnsNotFound_WhenPropertyDoesNotExist()
        {
            var propertyId = Guid.NewGuid();
            var propertyDTO = new PropertyRequestDTO { Area = 100, NumberBathrooms = 3, NumberRooms = 3, Price = 500000, Status = Domain.Enums.StatusImovel.Disponivel, Type = Domain.Enums.TipoImovel.Casa, Title = "Imovel 10", Address = new AddressRequestDTO { CEP = "05565666", City = "São Paulo", Complement = "", Number = 200, State = "sp", Street = "Rua José" } };
            _propertyServiceMock.Setup(service => service.UpdatePropertyAsync(propertyId, propertyDTO))
                .ReturnsAsync((PropertyResponseDTO)null);

            var result = await _controller.UpdateProperty(propertyId, propertyDTO);

            Assert.IsInstanceOf<NotFoundResult>(result);
        }

        [Test]
        public async Task DeleteProperty_ReturnsNoContent_WhenDeleteIsSuccessful()
        {
            var propertyId = Guid.NewGuid();

            var result = await _controller.DeleteProperty(propertyId);

            Assert.IsInstanceOf<NoContentResult>(result);
        }

    }
}
