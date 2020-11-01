using Data.Builders;
using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<User> User { get; set; }
        public DbSet<Roadmap> Roadmap { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<CategoryRoadmapRelation> CategoryRoadmapRelation { get; set; }
        public DbSet<RoadmapCopy> RoadmapCopy { get; set; }
        public DbSet<RoadmapItem> RoadmapItem { get; set; }
        public DbSet<Tag> Tag { get; set; }
        public DbSet<TagRoadmapRelation> TagRoadmapRelation { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CategoryBuilder());
            modelBuilder.ApplyConfiguration(new CategoryRoadmapRelationBuilder());
            modelBuilder.ApplyConfiguration(new RoadmapBuilder());
            modelBuilder.ApplyConfiguration(new RoadmapCopyBuilder());
            modelBuilder.ApplyConfiguration(new TagBuilder());
            modelBuilder.ApplyConfiguration(new TagRoadmapRelationBuilder());
            modelBuilder.ApplyConfiguration(new UserBuilder());
        }
    }
}
