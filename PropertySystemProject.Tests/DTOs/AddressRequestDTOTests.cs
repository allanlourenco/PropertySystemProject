using PropertySystemProject.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertySystemProject.Tests.DTOs
{
    [TestFixture]
    public class AddressRequestDTOTests
    {
        [Test]
        public void AddressRequestDTO_Validation_ShouldBeValid_WhenAllPropertiesAreValid()
        {
            // Arrange
            var address = new AddressRequestDTO
            {
                Street = "Rua das Flores",
                Number = 123,
                City = "São Paulo",
                State = "SP",
                CEP = "12345-678",
                Complement = "Apto 12"
            };

            // Act
            var validationResults = Validate(address);

            // Assert
            Assert.IsEmpty(validationResults);
        }

        [Test]
        public void AddressRequestDTO_Validation_ShouldReturnError_WhenStreetIsEmpty()
        {
            // Arrange
            var address = new AddressRequestDTO
            {
                Street = "",
                Number = 123,
                City = "São Paulo",
                State = "SP",
                CEP = "12345-678"
            };

            // Act
            var validationResults = Validate(address);

            // Assert
            Assert.IsNotEmpty(validationResults);
            Assert.AreEqual("A rua do imóvel é obrigatório.", validationResults[0].ErrorMessage);
        }

        [Test]
        public void AddressRequestDTO_Validation_ShouldReturnError_WhenNumberIsNull()
        {
            // Arrange
            var address = new AddressRequestDTO
            {
                Street = "Rua das Flores",
                Number = 0,
                City = "São Paulo",
                State = "SP",
                CEP = "12345-678"
            };

            // Act
            var validationResults = Validate(address);

            // Assert
            Assert.IsNotEmpty(validationResults);
            Assert.AreEqual("O número do endereço do imóvel é obrigatório.", validationResults[0].ErrorMessage);
        }

        [Test]
        public void AddressRequestDTO_Validation_ShouldReturnError_WhenCityIsEmpty()
        {
            // Arrange
            var address = new AddressRequestDTO
            {
                Street = "Rua das Flores",
                Number = 123,
                City = "",
                State = "SP",
                CEP = "12345-678"
            };

            // Act
            var validationResults = Validate(address);

            // Assert
            Assert.IsNotEmpty(validationResults);
            Assert.AreEqual("A cidade do imóvel é obrigatória.", validationResults[0].ErrorMessage);
        }

        [Test]
        public void AddressRequestDTO_Validation_ShouldReturnError_WhenStateIsEmpty()
        {
            // Arrange
            var address = new AddressRequestDTO
            {
                Street = "Rua das Flores",
                Number = 123,
                City = "São Paulo",
                State = "",
                CEP = "12345-678"
            };

            // Act
            var validationResults = Validate(address);

            // Assert
            Assert.IsNotEmpty(validationResults);
            Assert.AreEqual("O estado do imóvel é obrigatório.", validationResults[0].ErrorMessage);
        }

        [Test]
        public void AddressRequestDTO_Validation_ShouldReturnError_WhenStateIsInvalid()
        {
            // Arrange
            var address = new AddressRequestDTO
            {
                Street = "Rua das Flores",
                Number = 123,
                City = "São Paulo",
                State = "INVALID", // Estado inválido
                CEP = "12345-678"
            };

            // Act
            var validationResults = Validate(address);

            // Assert
            Assert.IsNotEmpty(validationResults);
        }

        [Test]
        public void AddressRequestDTO_Validation_ShouldReturnError_WhenCEPIsInvalid()
        {
            // Arrange
            var address = new AddressRequestDTO
            {
                Street = "Rua das Flores",
                Number = 123,
                City = "São Paulo",
                State = "SP",
                CEP = "123456789" // CEP sem o hífen
            };

            // Act
            var validationResults = Validate(address);

            // Assert
            Assert.IsNotEmpty(validationResults);
            Assert.AreEqual("CEP inválido. O formato deve ser XXXXX-XXX ou XXXXXXXX.", validationResults[0].ErrorMessage);
        }

        [Test]
        public void AddressRequestDTO_Validation_ShouldReturnError_WhenCEPIsEmpty()
        {
            // Arrange
            var address = new AddressRequestDTO
            {
                Street = "Rua das Flores",
                Number = 123,
                City = "São Paulo",
                State = "SP",
                CEP = "" // CEP vazio
            };

            // Act
            var validationResults = Validate(address);

            // Assert
            Assert.IsNotEmpty(validationResults);
            Assert.AreEqual("O CEP do imóvel é obrigatório.", validationResults[0].ErrorMessage);
        }

        private IList<ValidationResult> Validate(AddressRequestDTO address)
        {
            var context = new ValidationContext(address);
            var results = new List<ValidationResult>();
            Validator.TryValidateObject(address, context, results, true);
            return results;
        }
    }
}
