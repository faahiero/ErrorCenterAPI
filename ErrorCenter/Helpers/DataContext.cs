using System;
using System.Linq;
using ErrorCenter.Entities;
using ErrorCenter.Entities.EntityConfiguration;
using Microsoft.EntityFrameworkCore;
using Environment = ErrorCenter.Entities.Environment;

namespace ErrorCenter.Helpers
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> opt) : base(opt) { }
        

        public DbSet<User> Users { get; set; }
        public DbSet<Error> Errors { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<Environment> Environments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ErrorConfiguration());
            modelBuilder.ApplyConfiguration(new EnvironmentConfiguration());
            modelBuilder.ApplyConfiguration(new LevelConfiguration());
        }
        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("CreatedAt") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("CreatedAt").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("CreatedAt").IsModified = false;
                }
            }
            return base.SaveChanges();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }
    }
}