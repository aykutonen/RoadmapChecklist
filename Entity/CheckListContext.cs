using System;
using System.Collections.Generic;
using System.Text;
using Entity.Domain.Roadmap;
using Entity.Domain.User;
using Microsoft.EntityFrameworkCore;

namespace Entity
{
    public class CheckListContext : DbContext
    {
        public CheckListContext() : base()
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Roadmap> Roadmaps { get; set; }
        public DbSet<RoadmapItem> RoadmapItems { get; set; }
        public DbSet<CopiedRoadmaps> CopiedRoadmaps { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<RoadmapCategory> RoadmapCategories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<RoadmapTag> RoadmapTags { get; set; }
    }
}
