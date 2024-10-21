using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertySystemProject.Domain.Validators
{
    public class EstadoBrasileiroValidatorAttribute : ValidationAttribute
    {
        private static readonly string[] EstadosValidos = new string[]
    {
        "AC", "AL", "AP", "AM", "BA", "CE", "DF", "ES", "GO", "MA", "MT", "MS", "MG", "PA", "PB", "PR", "PE", "PI",
        "RJ", "RN", "RS", "RO", "RR", "SC", "SP", "SE", "TO"
    };

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var estado = value as string;

            if (string.IsNullOrEmpty(estado))
            {
                return new ValidationResult("O Estado é obrigatório.");
            }

            if (!EstadosValidos.Contains(estado.ToUpper()))
            {
                return new ValidationResult("Estado inválido. Use uma sigla de estado válida.");
            }

            return ValidationResult.Success;
        }
    }
}
