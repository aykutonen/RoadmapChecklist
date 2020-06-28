using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class User : ModelBase
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Picture { get; set; }
        public int Status { get; set; }

        public virtual ICollection<Roadmap> Roadmap { get; set; }
    }
}
