using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Web.Db.Entity;

namespace Web.Db
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public AppDbContext() { }

        public DbSet<Entity.User> User { get; set; }
        public DbSet<Roadmap> Roadmap { get; set; }
    }
}
