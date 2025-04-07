using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace jwt_funder.Services.AuthServices
{
    public class JWTService
    {
        private readonly string _secretKey;
        private readonly string _issuer;
        private readonly string _audience;
        private readonly int _expiryInMinutes;

        public JWTService(IConfiguration configuration)
        {
            _secretKey = configuration["JwtConfig:Key"] ?? throw new InvalidOperationException();
            _issuer = configuration["JwtConfig:Issuer"] ?? throw new InvalidOperationException();
            _audience = configuration["JwtConfig:Audience"]?? throw new InvalidOperationException();
            _expiryInMinutes = int.Parse(configuration["JwtConfig:TokenValidityMins"] ?? throw new InvalidOperationException());
        }

        public string GenerateToken(string emailId)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, emailId),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: _issuer,
                audience: _audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_expiryInMinutes),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
