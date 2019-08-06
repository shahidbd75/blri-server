using BLRI.Entity.Auth;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using BLRI.DAL.Repositories.Core;
using Microsoft.AspNetCore.Identity;

namespace BLRI.API.Provider
{
    public static class AuthenticationProvider
    {
        public static void AddAuthenticationProvider(this IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.ClaimsIssuer = ApplicationConfiguration.TokenIssuer;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = ApplicationConfiguration.TokenIssuer,
                    ValidAudience = ApplicationConfiguration.TokenIAudience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ApplicationConfiguration.JwtSecurityKey))
                };
            });

            services.AddIdentityCore<User>(o =>
            {
                o.Password.RequireDigit = false;
                o.Password.RequireLowercase = false;
                o.Password.RequireUppercase = false;
                o.Password.RequireNonAlphanumeric = false;
                o.Password.RequiredLength = 6;
            }).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
        }
    }
}
