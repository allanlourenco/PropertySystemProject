using PropertySystemProject.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertySystemProject.Domain.Entities
{
    public class Property : BaseEntityAudit
    {
        public string Title { get; set; } = string.Empty;
        public TipoImovel Type { get; set; }
        public double Area { get; set; }
        public int? NumberRooms { get; set; }
        public int? NumberBathrooms { get; set; }
        public double Price {  get; set; }
        public StatusImovel Status { get; set; }
        public Guid AddressId { get; set; }
        public Address Address { get; set; }

        public Property()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.Now;
        }
    }
}
