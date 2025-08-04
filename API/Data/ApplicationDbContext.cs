using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<ItemEntity> Items => Set<ItemEntity>();
        public DbSet<BidEntity> Bids => Set<BidEntity>();
        public DbSet<UserEntity> Users => Set<UserEntity>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedData.Seed(modelBuilder);
        }

    }

}
