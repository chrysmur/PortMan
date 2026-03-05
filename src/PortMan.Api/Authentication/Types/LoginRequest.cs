namespace PortMan.Api.Authentication.Types;

public class LoginRequest
{
    public string TenantId { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
}
