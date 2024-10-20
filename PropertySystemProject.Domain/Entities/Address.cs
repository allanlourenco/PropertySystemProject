using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertySystemProject.Domain.Entities
{
    public class Address : BaseEntityWithKey
    {
        public string Street {  get; set; } = string.Empty;
        public int Number { get; set; }
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string CEP { get; set; } = string.Empty;
        public string? Complement { get; set; }

        public Property Property { get; set; }
    }
}
