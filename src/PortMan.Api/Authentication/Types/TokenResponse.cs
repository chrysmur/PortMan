namespace PortMan.Api.Authentication.Types;

public record TokenResponse(string AccessToken, string TokenType, int ExpiresIn);
