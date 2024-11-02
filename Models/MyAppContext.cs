using Microsoft.EntityFrameworkCore;
using MyApp.Models.DomainModels;
using MyApp.Models.SeedData;

namespace MyApp.Models
{
    public class MyAppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }

        public MyAppDbContext(DbContextOptions<MyAppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ModelSeedData.Seed(modelBuilder);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Addresses)
                .WithOne(a => a.User)
                .HasForeignKey(a => a.UserId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
