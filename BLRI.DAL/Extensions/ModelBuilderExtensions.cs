using BLRI.DAL.SeedData;
using BLRI.Entity.Animals;
using BLRI.Entity.Auth;
using BLRI.Entity.Units;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BLRI.DAL.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BiometricUnit>().HasData(UnitSeed.BiometricUnits);
            modelBuilder.Entity<GrowthUnit>().HasData(UnitSeed.GrowthUnits);
            modelBuilder.Entity<WeightUnit>().HasData(UnitSeed.WeightUnits);
            modelBuilder.Entity<Genotype>().HasData(BasicSeed.Genotypes);
            modelBuilder.Entity<AnimalCategory>().HasData(BasicSeed.AnimalCategories);
            modelBuilder.Entity<IdentityRole>().HasData(UserSeed.IdentityRole);


            // Add Security Admin User

            User applicationUser = new User
            {
                UserName = "admin",
                Email = "admin@blri.com",
                NormalizedEmail = "admin@blri.com".ToUpper(),
                NormalizedUserName = "admin".ToUpper(),
                PhoneNumber = "01700000000"
            };
            PasswordHasher<User> password = new PasswordHasher<User>();
            applicationUser.PasswordHash = password.HashPassword(applicationUser, "admin123");

            modelBuilder.Entity<User>().HasData(applicationUser);
        }
    }
}
