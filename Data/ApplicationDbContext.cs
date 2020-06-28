using System;
using System.Collections.Generic;
using System.Text;
using Data.Builders;
using Entity.Domain.Roadmap;
using Entity.Domain.User;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        //entities
        public DbSet<User> User { get; set; }
        public DbSet<Roadmap> Roadmap { get; set; }
        public DbSet<CopiedRoadmaps> CopiedRoadmaps { get; set; }
        public DbSet<RoadmapItem> RoadmapItem { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<RoadmapCategoryRelation> RoadmapCategoryRelation { get; set; }
        public DbSet<Tag> Tag { get; set; }
        public DbSet<RoadmapTagRelation> RoadmapTagRelation { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            new UserBuilder(builder.Entity<User>());
            new RoadmapBuilder(builder.Entity<Roadmap>());
            new CopiedRoadmapsBuilder(builder.Entity<CopiedRoadmaps>());
            new RoadmapItemBuilder(builder.Entity<RoadmapItem>());
            new CategoryBuilder(builder.Entity<Category>());
            new RoadmapCategoryBuilder(builder.Entity<RoadmapCategoryRelation>());
            new TagBuilder(builder.Entity<Tag>());
            new RoadmapTagBuilder(builder.Entity<RoadmapTagRelation>());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=RoadmapChecklistDB;Trusted_Connection=true"); //ToDo: encapsulate it like appsetting.json ?
        }
    }
}
