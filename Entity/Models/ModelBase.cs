using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Models
{
    public abstract class ModelBase
    {
        public ModelBase()
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
