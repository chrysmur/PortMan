using System.Security.Claims;
namespace PortMan.Api.Authentication;

internal interface ITokenService
{
    string GenerateToken(string userId, string tenantId, IEnumerable<Claim> claims);
}
