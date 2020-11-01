using System;

namespace Entity
{
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            var dt = DateTime.UtcNow;
            this.CreateAt = dt;
            this.UpdateAt = dt;
            this.Status = 1;
        }

        public int Id { get; set; }
        public int Status { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
