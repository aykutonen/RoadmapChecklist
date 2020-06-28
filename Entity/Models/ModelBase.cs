using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public abstract class ModelBase
    {
        public int Id { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
