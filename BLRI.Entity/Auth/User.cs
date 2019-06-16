
using Microsoft.AspNetCore.Identity;

namespace BLRI.Entity.Auth
{
    public class User: IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
