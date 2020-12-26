using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Db.Entity
{
    public class Roadmap
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Visibility { get; set; } = 1;
        public int Status { get; set; } = 1;
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int UserId { get; set; }


        public virtual User User { get; set; }
    }
}
