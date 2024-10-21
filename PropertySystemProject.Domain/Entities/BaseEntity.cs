using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertySystemProject.Domain.Entities
{
    public class BaseEntityAudit : BaseEntityWithKey
    {
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsActive { get; set; } = true;

        public void SetUpdatedAt() { UpdatedAt = DateTime.Now; }
    }

    public class BaseEntityWithKey : BaseEntity
    {
        public Guid Id { get; set; }
    }

    public class BaseEntity
    {

    }
}
