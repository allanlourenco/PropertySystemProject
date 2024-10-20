using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertySystemProject.Domain.DTOs
{
    public class PropertyResponseDTO : PropertyRequestDTO
    {
        public Guid Id { get; set; }
    }
}
