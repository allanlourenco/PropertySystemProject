using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertySystemProject.Domain.Entities
{
    public class BaseEntityAudit : BaseEntityWithKey
    {
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
        public bool IsActive { get; set; } = true;
    }

    public class BaseEntityWithKey : BaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
    }

    public class BaseEntity
    {

    }
}
