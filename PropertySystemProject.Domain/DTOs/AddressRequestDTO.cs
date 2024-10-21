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
        [StringLength(2, MinimumLength = 2, ErrorMessage = "O campo estado do imóvel deve conter exatamente 2 caracteres.")]
        public string State { get; set; } = string.Empty;
        [Required(ErrorMessage = "O CEP do imóvel é obrigatório.")]
        public string CEP { get; set; } = string.Empty;
        public string? Complement { get; set; }
    }
}
