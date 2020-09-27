using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Models
{
    public class TimerBase 
    {
        protected TimerBase()
        {
            UpDateTime = DateTime.Now;
            CreateTime = DateTime.Now;
        }

        public DateTime CreateTime { get; set; }
        public DateTime UpDateTime { get; set; }
    }


}
