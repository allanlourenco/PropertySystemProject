using PropertySystemProject.Domain.Entities;
using PropertySystemProject.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertySystemProject.Domain.DTOs
{
    public class PropertyRequestDTO
    {
        [Required(ErrorMessage = "O título do imóvel é obrigatório.")]
        [StringLength(150, ErrorMessage = "O titulo deve ter no máximo 150 caracteres.")]
        public string Title { get; set; } = string.Empty;
        [EnumDataType(typeof(TipoImovel), ErrorMessage = "O valor fornecido para o campo Tipo é inválido. Deve ser 1, 2 ou 3. 1 - Casa, 2 - Apartamento ou 3 - Terreno.")]
        public TipoImovel Type { get; set; }
        [Range(0.01, double.MaxValue, ErrorMessage = "A área do imóvel deve ser maior que zero.")]
        [Required(ErrorMessage = "A área do imóvel é obrigatória.")]
        public double Area { get; set; }
        public int? NumberRooms { get; set; }
        public int? NumberBathrooms { get; set; }
        [Range(0.01, double.MaxValue, ErrorMessage = "O preço do imóvel deve ser maior que zero.")]
        [Required(ErrorMessage = "O preço do imóvel é obrigatório.")]
        public double Price { get; set; }
        [EnumDataType(typeof(StatusImovel), ErrorMessage = "O valor fornecido para o campo Status é inválido. Deve ser 1 ou 2. 1 - Disponível ou 2 - Vendido.")]
        public StatusImovel Status { get; set; }
        [Required(ErrorMessage = "O endereço é obrigatório.")]
        public required AddressRequestDTO Address { get; set; }
    }
}
