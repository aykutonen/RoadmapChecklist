using System;
using Data.Builder;
using Entity;
using Entity.Models.Categories;
using Entity.Models.Roadmaps;
using Entity.Models.Tags;
using Entity.Models.Users;
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
            modelBuilder.ApplyConfiguration(new CategoryBuilder());
            modelBuilder.ApplyConfiguration(new RoadmapCategoryBuilder());
            modelBuilder.ApplyConfiguration(new RoadmapBuilder());
            modelBuilder.ApplyConfiguration(new CopiedRoadmapBuilder());
            modelBuilder.ApplyConfiguration(new RoadmapItemBuilder());
            modelBuilder.ApplyConfiguration(new RoadmapTagBuilder());
            modelBuilder.ApplyConfiguration(new TagBuilder());
            modelBuilder.ApplyConfiguration(new UserBuilder());

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=RoadmapContext; Trusted_Connection=true");

        }

    }
}
