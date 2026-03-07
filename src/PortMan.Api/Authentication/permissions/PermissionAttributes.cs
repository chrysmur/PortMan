using Microsoft.AspNetCore.Authorization;
namespace PortMan.Api.Authentication.permissions;

public class PermissionAttribute : AuthorizeAttribute
{
    public PermissionAttribute(params string[] permissions) => Policy = string.Join(",", permissions);

    public string[] Permissions { get; }
}
