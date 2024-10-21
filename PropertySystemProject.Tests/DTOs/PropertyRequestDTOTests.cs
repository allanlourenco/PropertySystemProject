using PropertySystemProject.Domain.DTOs;
using PropertySystemProject.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertySystemProject.Tests.DTOs
{
    [TestFixture]
    public class PropertyRequestDTOTests
    {
        [Test]
        public void PropertyRequestDTO_Validation_ShouldBeValid_WhenAllPropertiesAreValid()
        {
            // Arrange
            var property = new PropertyRequestDTO
            {
                Title = "Casa de Veraneio",
                Type = TipoImovel.Casa,
                Area = 100.5,
                NumberRooms = 3,
                NumberBathrooms = 2,
                Price = 500000,
                Status = StatusImovel.Disponivel,
                Address = new AddressRequestDTO
                {
                    Street = "Rua das Flores",
                    Number = 123,
                    City = "São Paulo",
                    State = "SP",
                    CEP = "12345-678"
                }
            };

            // Act
            var validationResults = Validate(property);

            // Assert
            Assert.IsEmpty(validationResults);
        }

        [Test]
        public void PropertyRequestDTO_Validation_ShouldReturnError_WhenTitleIsEmpty()
        {
            // Arrange
            var property = new PropertyRequestDTO
            {
                Title = "",
                Type = TipoImovel.Casa,
                Area = 100.5,
                Price = 500000,
                Status = StatusImovel.Disponivel,
                Address = new AddressRequestDTO
                {
                    Street = "Rua das Flores",
                    Number = 123,
                    City = "São Paulo",
                    State = "SP",
                    CEP = "12345-678"
                }
            };

            // Act
            var validationResults = Validate(property);

            // Assert
            Assert.IsNotEmpty(validationResults);
            Assert.AreEqual("O título do imóvel é obrigatório.", validationResults[0].ErrorMessage);
        }

        [Test]
        public void PropertyRequestDTO_Validation_ShouldReturnError_WhenTitleExceedsMaxLength()
        {
            // Arrange
            var property = new PropertyRequestDTO
            {
                Title = new string('A', 151), // 151 characters
                Type = TipoImovel.Casa,
                Area = 100.5,
                Price = 500000,
                Status = StatusImovel.Disponivel,
                Address = new AddressRequestDTO
                {
                    Street = "Rua das Flores",
                    Number = 123,
                    City = "São Paulo",
                    State = "SP",
                    CEP = "12345-678"
                }
            };

            // Act
            var validationResults = Validate(property);

            // Assert
            Assert.IsNotEmpty(validationResults);
            Assert.AreEqual("O titulo deve ter no máximo 150 caracteres.", validationResults[0].ErrorMessage);
        }

        [Test]
        public void PropertyRequestDTO_Validation_ShouldReturnError_WhenTypeIsNotProvided()
        {
            // Arrange
            var property = new PropertyRequestDTO
            {
                Title = "Casa de Veraneio",
                Area = 100.5,
                Price = 500000,
                Status = StatusImovel.Disponivel,
                Address = new AddressRequestDTO
                {
                    Street = "Rua das Flores",
                    Number = 123,
                    City = "São Paulo",
                    State = "SP",
                    CEP = "12345-678"
                }
            };

            // Act
            var validationResults = Validate(property);

            // Assert
            Assert.IsNotEmpty(validationResults);
            Assert.AreEqual("O valor fornecido para o campo Tipo é inválido. Deve ser 1, 2 ou 3. 1 - Casa, 2 - Apartamento ou 3 - Terreno.", validationResults[0].ErrorMessage);
        }

        [Test]
        public void PropertyRequestDTO_Validation_ShouldReturnError_WhenAreaIsZero()
        {
            // Arrange
            var property = new PropertyRequestDTO
            {
                Title = "Casa de Veraneio",
                Type = TipoImovel.Casa,
                Area = 0,
                Price = 500000,
                Status = StatusImovel.Disponivel,
                Address = new AddressRequestDTO
                {
                    Street = "Rua das Flores",
                    Number = 123,
                    City = "São Paulo",
                    State = "SP",
                    CEP = "12345-678"
                }
            };

            // Act
            var validationResults = Validate(property);

            // Assert
            Assert.IsNotEmpty(validationResults);
            Assert.AreEqual("A área do imóvel deve ser maior que zero.", validationResults[0].ErrorMessage);
        }

        [Test]
        public void PropertyRequestDTO_Validation_ShouldReturnError_WhenPriceIsZero()
        {
            // Arrange
            var property = new PropertyRequestDTO
            {
                Title = "Casa de Veraneio",
                Type = TipoImovel.Casa,
                Area = 100.5,
                Price = 0,
                Status = StatusImovel.Disponivel,
                Address = new AddressRequestDTO
                {
                    Street = "Rua das Flores",
                    Number = 123,
                    City = "São Paulo",
                    State = "SP",
                    CEP = "12345-678"
                }
            };

            // Act
            var validationResults = Validate(property);

            // Assert
            Assert.IsNotEmpty(validationResults);
            Assert.AreEqual("O preço do imóvel deve ser maior que zero.", validationResults[0].ErrorMessage);
        }

        [Test]
        public void PropertyRequestDTO_Validation_ShouldReturnError_WhenStatusIsNotProvided()
        {
            // Arrange
            var property = new PropertyRequestDTO
            {
                Title = "Casa de Veraneio",
                Type = TipoImovel.Casa,
                Area = 100.5,
                Price = 500000,
                Address = new AddressRequestDTO
                {
                    Street = "Rua das Flores",
                    Number = 123,
                    City = "São Paulo",
                    State = "SP",
                    CEP = "12345-678"
                }
            };

            // Act
            var validationResults = Validate(property);

            // Assert
            Assert.IsNotEmpty(validationResults);
            Assert.AreEqual("O valor fornecido para o campo Status é inválido. Deve ser 1 ou 2. 1 - Disponível ou 2 - Vendido.", validationResults[0].ErrorMessage);
        }

        [Test]
        public void PropertyRequestDTO_Validation_ShouldReturnError_WhenAddressIsNull()
        {
            // Arrange
            var property = new PropertyRequestDTO
            {
                Title = "Casa de Veraneio",
                Type = TipoImovel.Casa,
                Area = 100.5,
                Price = 500000,
                Status = StatusImovel.Disponivel,
                Address = null // Address is null
            };

            // Act
            var validationResults = Validate(property);

            // Assert
            Assert.IsNotEmpty(validationResults);
            Assert.AreEqual("O endereço é obrigatório.", validationResults[0].ErrorMessage);
        }

        private IList<ValidationResult> Validate(PropertyRequestDTO property)
        {
            var context = new ValidationContext(property);
            var results = new List<ValidationResult>();
            Validator.TryValidateObject(property, context, results, true);
            return results;
        }
    }
}
