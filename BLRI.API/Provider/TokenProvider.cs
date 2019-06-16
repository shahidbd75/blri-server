using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BLRI.Entity.Auth;
using Microsoft.IdentityModel.Tokens;

namespace BLRI.API.Provider
{
    public class TokenProvider : ITokenProvider
    {
        public string GenerateToken(User user)
        {
            var utcNow = DateTime.UtcNow;

            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, utcNow.ToString("d"))
            };

            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ApplicationConfiguration.JwtSecurityKey));
            var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
            var jwt = new JwtSecurityToken(
                signingCredentials: signingCredentials,
                claims: claims,
                notBefore: utcNow,
                expires: utcNow.AddDays(ApplicationConfiguration.TokenExpiration),
                audience: ApplicationConfiguration.TokenIAudience,
                issuer: ApplicationConfiguration.TokenIssuer
            );

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }
}
