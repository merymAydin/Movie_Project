using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreEntity
{
    public abstract class BaseEntity : IEntity
    {
        public Guid Id { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; } = false;

        public BaseEntity()
        {
            Id = Guid.NewGuid();
            CreateAt = DateTime.UtcNow;
            UpdateAt = null;
            IsActive = true;
            IsDeleted = false;
        }
    }
}
