using System.Linq;
namespace PortMan.Api.Authentication.permissions;

/// <summary>
/// Extension for the services.AddAuthorization
/// Injects IServiceCollection and adds to it a list of permissions mapped to auth policy
/// </summary>
public static class AuthorizationExtensions
{
    public static IServiceCollection AddPermissionAuthorization(this IServiceCollection services)
    {
        services.AddAuthorization(options =>
        {
            var permissions = typeof(Permissions)
                .GetNestedTypes()
                .SelectMany(t => t.GetFields())
                .Select(f => f.GetValue(null)?.ToString());

            foreach (var permission in permissions)
            {
                options.AddPolicy(permission, policy =>
                policy.RequireClaim("permission", permission));
            }
        });
            return services;
    }
}
