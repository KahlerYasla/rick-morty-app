using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace CoreInfrastructureLayer.Helpers
{
    public static class JwtTokenGenerator
    {
        static readonly TimeSpan TokenExpiration = TimeSpan.FromHours(1);

        public static string GenerateToken(string username, string email, string secretRaw)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(secretRaw);

            var claims = new List<Claim>
            {
                new (JwtRegisteredClaimNames.Sub, username!),
                new (JwtRegisteredClaimNames.Email, email!),
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow + TokenExpiration,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token).ToString();
        }
    }
}