using System.Data;
using System.Net;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using PortMan.Api.Authentication.helpers;
using PortMan.Application.RoleService;
using PortMan.Application.UserService;
using PortMan.Domain;
using static PortMan.Api.Authentication.permissions.Permissions;

namespace PortMan.Api.Authentication;

internal class LoginUser : ILogin
{
    private readonly ITokenService _tokenService;
    private readonly IUserRepository _userRepository;
    private readonly IAccessRolesRepository _accessRolesRepository;

    public LoginUser(ITokenService tokenService, IUserRepository userRepository, IAccessRolesRepository accessRolesRepository)
    {
        _tokenService = tokenService;
        _userRepository = userRepository;
        _accessRolesRepository = accessRolesRepository;
    }
    /// <summary>
    /// Validates credentials and generate JWT token if successful. Returns LoginResult with token or error message.
    /// </summary>
    /// <param name="tenantId">Tenant ID</param>
    /// <param name="username">Username of the user</param>
    /// <param name="password">Password of the user</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>LoginResult containing the token or error message</returns>
    public async Task<LoginResult> LoginUserAsync(
    string tenantId,
    string username,
    string password,
    CancellationToken cancellationToken = default)
    {
        // Validate inputs
        if (string.IsNullOrWhiteSpace(tenantId) ||
            string.IsNullOrWhiteSpace(username) ||
            string.IsNullOrWhiteSpace(password))
        {
            return LoginResult.Failure("Invalid credentials");
        }

        // Retrieve user from database
        Domain.User? user = await _userRepository.GetUserByUsernameAndTenantIdAsync(
            username,
            tenantId,
            cancellationToken);

        if (user is null || !PassWordHandler.VerifyPassword(password, user.PasswordHash))
        {
            return LoginResult.Failure("Invalid credentials");
        }

        // Build claims
        var claims = new List<Claim>
        {
        new(ClaimTypes.NameIdentifier, user.Id.ToString()),
        new(ClaimTypes.Name, user.Username),
        new("TenantId", user.TenantId)
        };


        //Get user permissions 
        var permissions = await _accessRolesRepository.GetUserRolesAsync(username, CancellationToken.None);
        foreach (string permission in permissions)
        {
            claims.Add(new Claim("permission", permission));
        }

        if (user.Roles is not null)
        {
            claims.AddRange(user.Roles.Select(role =>
                new Claim(ClaimTypes.Role, role.Name)));
        }

        // Generate token
        string token = _tokenService.GenerateToken(
            user.Id.ToString(),
            user.TenantId,
            claims.ToArray());

        return LoginResult.Success(token);
    }
}
