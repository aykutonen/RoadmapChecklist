using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Domain.User
{
    public class User : AuditableEntity
    {
        //fields
        public string Name { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Picture { get; set; }
        public int Status { get; set; }

        //relations
        public ICollection<Roadmap.Roadmap> Roadmaps { get; set; }
    }
}
