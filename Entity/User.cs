using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Picture { get; set; }

        // Relations
        public virtual ICollection<Roadmap> Roadmaps { get; set; }

    }
}
