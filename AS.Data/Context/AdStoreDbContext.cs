using AS.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace AS.Data.Context
{
    public class AdStoreDbContext : DbContext
    {
        public AdStoreDbContext(DbContextOptions<AdStoreDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Ad> Ads { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasIndex(u => u.Username).IsUnique();
            modelBuilder.Entity<User>().Property(u => u.DateCreated).HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Category>().HasIndex(u => u.Name).IsUnique();
            modelBuilder.Entity<Category>().Property(u => u.DateCreated).HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Ad>().HasIndex(u => u.Title).IsUnique();
            modelBuilder.Entity<Ad>().Property(u => u.Price).HasPrecision(7, 2);
            modelBuilder.Entity<Ad>().Property(u => u.DateCreated).HasDefaultValueSql("getdate()");

            base.OnModelCreating(modelBuilder);
        }
    }
}
