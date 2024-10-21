using PropertySystemProject.Domain.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertySystemProject.Tests.DTOs
{
    [TestFixture]
    public class EstadoBrasileiroValidatorTests
    {
        private class TestModel
        {
            [EstadoBrasileiroValidator]
            public string State { get; set; }
        }

        [Test]
        public void EstadoBrasileiroValidator_ShouldBeValid_WhenStateIsValid()
        {
            var model = new TestModel { State = "SP" };
            var context = new ValidationContext(model) { MemberName = "State" };

            var result = Validator.TryValidateProperty(model.State, context, null);

            Assert.IsTrue(result);
        }

        [Test]
        public void EstadoBrasileiroValidator_ShouldReturnError_WhenStateIsInvalid()
        {
            var model = new TestModel { State = "XX" };
            var context = new ValidationContext(model) { MemberName = "State" };
            var validationResults = new List<ValidationResult>();

            var result = Validator.TryValidateProperty(model.State, context, validationResults);

            Assert.IsFalse(result);
            Assert.AreEqual("Estado inválido. Use uma sigla de estado válida.", validationResults[0].ErrorMessage);
        }

        [Test]
        public void EstadoBrasileiroValidator_ShouldReturnError_WhenStateIsEmpty()
        {
            var model = new TestModel { State = "" };
            var context = new ValidationContext(model) { MemberName = "State" };
            var validationResults = new List<ValidationResult>();

            var result = Validator.TryValidateProperty(model.State, context, validationResults);

            Assert.IsFalse(result);
            Assert.AreEqual("O Estado é obrigatório.", validationResults[0].ErrorMessage);
        }

        [Test]
        public void EstadoBrasileiroValidator_ShouldReturnError_WhenStateIsNull()
        {
            var model = new TestModel { State = null };
            var context = new ValidationContext(model) { MemberName = "State" };
            var validationResults = new List<ValidationResult>();

            var result = Validator.TryValidateProperty(model.State, context, validationResults);

            Assert.IsFalse(result);
            Assert.AreEqual("O Estado é obrigatório.", validationResults[0].ErrorMessage);
        }
    }
}
