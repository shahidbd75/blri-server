using System;
using BLRI.Entity.Auth;

namespace BLRI.DAL.SeedData
{
    public static class UserSeed
    {
        public static User User =>
            new User()
            {
                Email = "abc@yahoo.com",
                FirstName = "Administrator",
                LastName = "User",
                UserName = "Admin",
                PasswordHash = Guid.NewGuid().ToString()
            };
    }
}
