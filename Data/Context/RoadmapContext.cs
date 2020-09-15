using System;
using Data.Builder;
using Entity;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class RoadmapContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Tag> Tag { get; set; }
        public DbSet<Roadmap> Roadmap { get; set; }
        public DbSet<RoadmapItem> RoadmapItem { get; set; }
        public DbSet<RoadmapCategory> RoadmapCategory { get; set; }
        public DbSet<RoadmapTag> RoadmapTag { get; set; }
        public DbSet<CopiedRoadmap> CopiedRoadmap { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            new UserBuilder(modelBuilder.Entity<User>());
            new RoadmapBuilder(modelBuilder.Entity<Roadmap>());
            new CopiedRoadmapBuilder.(modelBuilder.Entity<CopiedRoadmap>());
            new RoadmapItemBuilder(modelBuilder.Entity<RoadmapItem>());
            new CategoryBuilder(modelBuilder.Entity<Category>());
            new RoadmapCategoryBuilder(modelBuilder.Entity<RoadmapCategory>());
            new TagBuilder(modelBuilder.Entity<Tag>());
            new RoadmapTagBuilder(modelBuilder.Entity<RoadmapTag>());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=RoadmapContext; Trusted_Connection=true");

        }

    }
}
