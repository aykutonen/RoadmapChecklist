using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Domain.User
{
    public class User : AuditableEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Picture { get; set; }
        public int Status { get; set; }

        public ICollection<Roadmap.Roadmap> Roadmaps { get; set; }
    }
}
