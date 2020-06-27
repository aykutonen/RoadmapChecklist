using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Domain
{
    public class AuditableEntity : BaseEntity
    {
        protected AuditableEntity()
        {
            UpDateTime = DateTime.Now;
        }

        public DateTime CreateTime { get; set; }
        public DateTime UpDateTime { get; set; }
    }
}
