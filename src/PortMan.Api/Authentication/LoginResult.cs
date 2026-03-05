using System.Net;
using PortMan.Api.Authentication.Types;

namespace PortMan.Api.Authentication;

public sealed class LoginResult
{
    public bool IsSuccess { get; private init; }
    public TokenResponse? Token { get; private init; }
    public string? ErrorMessage { get; private init; }
    public HttpStatusCode StatusCode { get; private init; }

    public static LoginResult Success(string token) => new()
    {
        IsSuccess = true,
        Token = new TokenResponse(token, "Bearer", 3600),
        StatusCode = HttpStatusCode.OK
    };

    public static LoginResult Failure(string errorMessage) => new()
    {
        IsSuccess = false,
        ErrorMessage = errorMessage,
        StatusCode = HttpStatusCode.Unauthorized
    };
}
