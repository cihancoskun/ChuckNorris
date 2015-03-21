using System;

namespace App.Domain.Entities
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            CreatedAt = UpdatedAt = DateTime.Now;
            IsDeleted = false;
        }

        public int Id { get; set; }

        public int? UpdatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }

        public int? CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }

        public int? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsActive { get; set; }
    }
}
