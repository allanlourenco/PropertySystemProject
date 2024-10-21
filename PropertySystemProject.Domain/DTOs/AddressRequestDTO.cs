using PropertySystemProject.Domain.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertySystemProject.Domain.DTOs
{
    public class AddressRequestDTO
    {
        [Required(ErrorMessage = "A rua do imóvel é obrigatório.")]
        public string Street { get; set; } = string.Empty;
        [Required(ErrorMessage = "O número do endereço do imóvel é obrigatório.")]
        public int Number { get; set; }
        [Required(ErrorMessage = "A cidade do imóvel é obrigatória.")]
        public string City { get; set; } = string.Empty;
        [Required(ErrorMessage = "O estado do imóvel é obrigatório.")]
        [EstadoBrasileiroValidator]
        public string State { get; set; } = string.Empty;
        [RegularExpression(@"^\d{5}-\d{3}$|^\d{8}$", ErrorMessage = "CEP inválido. O formato deve ser XXXXX-XXX ou XXXXXXXX.")]
        [Required(ErrorMessage = "O CEP do imóvel é obrigatório.")]
        public string CEP { get; set; } = string.Empty;
        public string? Complement { get; set; }
    }
}
