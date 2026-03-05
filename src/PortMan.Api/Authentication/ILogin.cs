using System.Net;

namespace PortMan.Api.Authentication;

public interface ILogin
{
    Task<LoginResult> LoginUserAsync(string tenantId, string username, string password, CancellationToken cancellationToken = default);
}
