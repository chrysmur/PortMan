using System.Net;
using Microsoft.AspNetCore.Identity;
using PortMan.Api.Authentication.helpers;
using PortMan.Domain;

namespace PortMan.Api.Authentication;

internal class Login : ILogin
{
    TokenService tokenService = new TokenService();
    private readonly User user = new()
    {
        Id = Guid.NewGuid(),
        TenantId = Guid.NewGuid().ToString(),
        Username = "testuser",
        FirstName = "Kris",
        LastName = "Portman",
        Phone = "1234567890",
        Email = "kport@tutanota.com",
        PasswordHash = PassWordHandler.HashPassword("Magicpassword1")
    };

    HttpStatusCode LoginUser(string tenantId, string username, string password)
    {
        throw new NotImplementedException();
    }
    bool IsCredentialValid(string tenantId, string username, string password)
    {
        // >> Call the user service to get the user by username and tenantId
        if (username == user.Username && tenantId == user.TenantId &&
            PassWordHandler.VerifyPassword(password, user.PasswordHash))
        {
            return true;
        }
        return false;
    }

    string GenerateToken(string tenantId, string username, string password)
    {
        if (IsCredentialValid(tenantId, username, password))
        {
            // >> Generate a JWT token for the user
            // >> Include the user ID and tenant ID in the token claims
            // >>TODO: Get access roles from the user service and include them in the token claims
            return tokenService.GenerateToken(user.Id.ToString(), user.TenantId, new Claim[] { });
        }
        throw new UnauthorizedAccessException("Invalid credentials");
    }
}
