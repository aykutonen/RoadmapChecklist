using Entity.Models.Roadmaps;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Models.Users
{
    public class User : ModelBase
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Picture { get; set; }
        public int Status { get; set; }

        public virtual ICollection<Roadmap> Roadmaps { get; set; }
    }
}
