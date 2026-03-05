using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace PortMan.Api.Authentication;

internal class TokenService : ITokenService
{
    private IConfiguration _configuration;
    public void Initialize(IConfiguration configuration) => _configuration = configuration;
    public string GenerateToken(string userId, string tenantId, IEnumerable<Claim> claims)
    {
        var signingSecret = _configuration["Jwt:Secret"] ?? throw new InvalidOperationException("JWT secret is not configured (Jwt:Secret).");
        var tokenHandler = new JwtSecurityTokenHandler();
        var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signingSecret));

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            
            Issuer = _configuration["Jwt:Issuer"],
            Audience = _configuration["Jwt:Audience"],
            Expires = DateTime.UtcNow.AddMinutes(5),
            Subject = new ClaimsIdentity(claims.Concat(new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, userId),
                    new Claim("tenantId", tenantId)
                })),
            SigningCredentials = new SigningCredentials(
                authSigningKey,
                SecurityAlgorithms.HmacSha256)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}
