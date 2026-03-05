using System;
using System.Collections.Generic;
using System.Text;
using PortMan.Domain;

namespace PortMan.Application.UserService;
internal class UserRepository : IUserRepository
{
    public Task<User?> GetUserByEmailAsync(string email, CancellationToken token) => throw new NotImplementedException();
    public Task<User?> GetUserByUsernameAsync(string username, CancellationToken token) => throw new NotImplementedException();
    public Task<User?> GetUserByUsernameAndTenantIdAsync(string username, string tenantId, CancellationToken token) => throw new NotImplementedException();
    public Task<User?> GetUserByIdAsync(Guid id, CancellationToken token) => throw new NotImplementedException();
    public Task<IEnumerable<User>> GetUsersByTenantIdAsync(Guid tenantId, CancellationToken token) => throw new NotImplementedException();
    public Task<User> CreateUserAsync(string username, string email, string password, Guid tenantId, CancellationToken token) => throw new NotImplementedException();
    public Task<bool> ValidateUserCredentialsAsync(string username, string password, CancellationToken token) => throw new NotImplementedException();
}
