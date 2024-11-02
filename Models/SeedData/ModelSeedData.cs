using Microsoft.EntityFrameworkCore;
using MyApp.Models.DomainModels;

namespace MyApp.Models.SeedData
{
    public static class ModelSeedData
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var users = new List<User>
            {
                new() {
                    Id = 1,
                    Username = "ginters",
                    EmailAddress = "ginters@example.com",
                    Password = "P@ssword1"
                },
                new() {
                    Id = 2,
                    Username = "janis",
                    EmailAddress = "janis@example.com",
                    Password = "P@ssword1"
                }
            };

            modelBuilder.Entity<User>().HasData(users);

            var addresses = new List<Address>
            {
                new() {
                    Id = 1,
                    UserId = 1,
                    AddressLine1 = "Saules iela 10",
                    AddressLine2 = null,
                    City = "Sigulda",
                    State = "Latvia",
                    ZipCode = "LV-2158"
                },
                new() {
                    Id= 2,
                    UserId = 2,
                    AddressLine1 = "Mēness iela 2",
                    AddressLine2 = null,
                    City = "Cēsis",
                    State = "Latvia",
                    ZipCode = "LV-4101"
                }
            };

            modelBuilder.Entity<Address>().HasData(addresses);
        }
    }
}

