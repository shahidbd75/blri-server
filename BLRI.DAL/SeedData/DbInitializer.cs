using BLRI.DAL.Repositories.Core;
using BLRI.Entity.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Internal;

namespace BLRI.DAL.SeedData
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            if (!context.BiometricUnit.Any())
            {
                context.BiometricUnit.AddRange(UnitSeed.BiometricUnits);
            }

            if (!context.GrowthUnit.Any())
            {
                context.GrowthUnit.AddRange(UnitSeed.GrowthUnits);
            }
            if (!context.WeightUnit.Any())
            {
                context.WeightUnit.AddRange(UnitSeed.WeightUnits);
            }
            if (!context.Genotype.Any())
            {
                context.Genotype.AddRange(BasicSeed.Genotypes);
            }
            if (!context.AnimalCategory.Any())
            {
                context.AnimalCategory.AddRange(BasicSeed.AnimalCategories);
            }
            if (!context.Roles.Any())
            {
                context.Roles.Add(UserSeed.IdentityRole);
            }

            context.SaveChanges();
            if (!context.Users.Any())
            {
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

                context.Users.Add(applicationUser);
            }

            context.SaveChanges();
        }
    }
}
