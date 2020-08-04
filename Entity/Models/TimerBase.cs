using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Models
{
    public class TimerBase : ModelBase
    {
        protected TimerBase()
        {
            UpDateTime = DateTime.Now;
        }

        public DateTime CreateTime { get; set; }
        public DateTime UpDateTime { get; set; }
    }


}
