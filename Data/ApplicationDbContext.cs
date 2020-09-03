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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            new UserBuilder(modelBuilder.Entity<User>());
            new RoadmapBuilder(modelBuilder.Entity<Roadmap>());
            new CopiedRoadmapsBuilder(modelBuilder.Entity<CopiedRoadmaps>());
            new RoadmapItemBuilder(modelBuilder.Entity<RoadmapItem>());
            new CategoryBuilder(modelBuilder.Entity<Category>());
            new RoadmapCategoryBuilder(modelBuilder.Entity<RoadmapCategoryRelation>());
            new TagBuilder(modelBuilder.Entity<Tag>());
            new RoadmapTagBuilder(modelBuilder.Entity<RoadmapTagRelation>());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=RoadmapChecklistDatabase;Trusted_Connection=true"); //ToDo: encapsulate it like appsetting.json ?
        }
    }
}
