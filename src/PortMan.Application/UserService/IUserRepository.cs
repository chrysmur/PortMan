using System;
using System.Collections.Generic;
using System.Text;
using PortMan.Application.Types;
using PortMan.Domain;

namespace PortMan.Application.UserService;
public interface IUserRepository
{
    Task<User?> GetUserByEmailAsync(string email, CancellationToken token);
    Task<User?> GetUserByUsernameAsync(string username, CancellationToken token);
    Task<User?> GetUserByUsernameAndTenantIdAsync(string username, string tenantId, CancellationToken token);
    Task<User?> GetUserByIdAsync(Guid id, CancellationToken token);
    Task<IEnumerable<User>> GetUsersByTenantIdAsync(string tenantId, CancellationToken token);
    Task<User> CreateUserAsync(CreateUserRequest user, string tenantId, CancellationToken token);
    Task<bool> ValidateUserCredentialsAsync(string username, string password, CancellationToken token);
}
