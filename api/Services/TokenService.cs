
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using api.Interfaces;
using api.Models;
using Microsoft.IdentityModel.Tokens;

namespace api.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration configuration;
        private readonly SymmetricSecurityKey key;

        public TokenService(IConfiguration configuration)
        {
            this.configuration = configuration;
            key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
        }

        public string CreateToken(AppUser user)
        {
            var claims = new List<Claim>{
                new(JwtRegisteredClaimNames.Email, user.Email),
                new(JwtRegisteredClaimNames.GivenName, user.UserName)
            };
            var creds =  new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var tokenDescriptor = new SecurityTokenDescriptor {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = creds,
                Issuer = configuration["Jwt:Issuer"],
                Audience = configuration["Jwt:Audience"]
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}