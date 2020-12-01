using Microsoft.EntityFrameworkCore;
using RomeApi.Models;

namespace RomeApi.Data
{
    public class RomeApiContext : DbContext
    {
        public RomeApiContext(DbContextOptions<RomeApiContext> options) : base(options)
        {
        }

        public DbSet<CategoryGroup> CategoryGroups { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryGroup>(entity =>
            {
                entity.HasIndex(e => e.Rank).IsUnique();
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");
            });
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasIndex(e => e.Rank).IsUnique();
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");
            });
            modelBuilder.Entity<Topic>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");
            });
            modelBuilder.Entity<Post>(entity =>
            {
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");
            });
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Name).IsUnique();
                entity.HasIndex(e => e.Email).IsUnique();
                entity.Property(e => e.IsAdmin).HasDefaultValue(false);
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("now()");
                entity.Property(e => e.UpdatedAt).HasDefaultValueSql("now()");
            });
        }
    }
}