using System;
using BLRI.Entity.Auth;
using Microsoft.AspNetCore.Identity;

namespace BLRI.DAL.SeedData
{
    public static class UserSeed
    {
        //        public static void SeedData (UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        //        {
        //            SeedRoles(roleManager);
        //            SeedUsers(userManager);
        //        }
        //
        //        private static void SeedRoles(RoleManager<IdentityRole> roleManager)
        //        {
        //            if (!roleManager.RoleExistsAsync("Administrator").Result)
        //            {
        //                roleManager.CreateAsync(new IdentityRole("Administrator"));
        //            }
        //            if (!roleManager.RoleExistsAsync("User").Result)
        //            {
        //                roleManager.CreateAsync(new IdentityRole("User"));
        //            }
        //        }
        //
        //        private static void SeedUsers(UserManager<User> userManager)
        //        {
        //            //TODO: Set Seed User
        //            if (userManager.FindByNameAsync("admin").Result == null)
        //            {
        //                var user = new User
        //                {
        //                    Email = "blri_admin@gmail.com",
        //                    FirstName = "Administrator",
        //                    LastName = "User",
        //                    UserName = "admin",
        //                    PasswordHash = Guid.NewGuid().ToString()
        //                };
        //
        //                var result = userManager.CreateAsync(user, "admin123").Result;
        //                if (result.Succeeded)
        //                {
        //                    userManager.AddToRoleAsync(user, "Administrator");
        //                }
        //            }
        //        }

        public static IdentityRole IdentityRole => new IdentityRole("Administrator");
        public static User User =>
            new User()
            {
                Email = "admin_blri@gmail.com",
                FirstName = "Administrator",
                LastName = "User",
                UserName = "admin",
                NormalizedUserName = "admin".ToUpper(),
                NormalizedEmail = "admin_blri@gmail.com".ToUpper(),
                PasswordHash = new PasswordHasher<User>().HashPassword(null,"admin123"),
                SecurityStamp = string.Empty
            };
    }
}
