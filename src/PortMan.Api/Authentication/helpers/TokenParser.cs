namespace PortMan.Api.Authentication.helpers;

public static class TokenParser
{
    public static string? GetTenantId(string token) => GetClaimValue(token, "tenantId");

    private static string? GetClaimValue(string token, string claimType)
    {
        var handler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
        var jwtToken = handler.ReadJwtToken(token);
        var claim = jwtToken.Claims.FirstOrDefault(c => c.Type == claimType);
        return claim?.Value;
    }

}
