using System.Net;

namespace PortMan.Api.Authentication;

internal interface ILogin
{
    bool IsCredentialValid(string tenantId, string username, string password);
    string GenerateToken(string tenantId, string username, string password);
    HttpStatusCode LoginUser(string tenantId, string username, string password);
}
