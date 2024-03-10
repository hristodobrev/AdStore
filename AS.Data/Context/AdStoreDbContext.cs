using AS.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace AS.Data.Context
{
    public class AdStoreDbContext : DbContext
    {
        public AdStoreDbContext(DbContextOptions<AdStoreDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
