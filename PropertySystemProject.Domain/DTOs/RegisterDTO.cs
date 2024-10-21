﻿using PropertySystemProject.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertySystemProject.Domain.DTOs
{
    public class RegisterDTO : LoginDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public UserRole Role { get; set; }

        [Required, Compare(nameof(Password)), DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
