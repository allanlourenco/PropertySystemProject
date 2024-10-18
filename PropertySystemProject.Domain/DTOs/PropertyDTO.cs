﻿using PropertySystemProject.Domain.Entities;
using PropertySystemProject.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertySystemProject.Domain.DTOs
{
    public class PropertyDTO
    {
        [Required(ErrorMessage = "O título do imóvel é obrigatório.")]
        [StringLength(150, ErrorMessage = "O titulo deve ter no máximo 150 caracteres.")]
        public string Title { get; set; } = string.Empty;
        [Required(ErrorMessage = "O tipo do imóvel é obrigatório.")]
        [EnumDataType(typeof(TipoImovel), ErrorMessage = "O valor fornecido para o campo Tipo é inválido.")]
        public TipoImovel Type { get; set; }
        [Range(0.01, double.MaxValue, ErrorMessage = "A área do imóvel deve ser maior que zero.")]
        [Required(ErrorMessage = "A área do imóvel é obrigatória.")]
        public double Area { get; set; }
        public int? NumberRooms { get; set; }
        public int? NumberBathrooms { get; set; }
        [Range(0.01, double.MaxValue, ErrorMessage = "O preço do imóvel deve ser maior que zero.")]
        [Required(ErrorMessage = "O preço do imóvel é obrigatório.")]
        public double Price { get; set; }
        [Required(ErrorMessage = "O status do imóvel é obrigatório.")]
        [EnumDataType(typeof(StatusImovel), ErrorMessage = "O valor fornecido para o campo Status é inválido.")]
        public StatusImovel Status { get; set; }

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
