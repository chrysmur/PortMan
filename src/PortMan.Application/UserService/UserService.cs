using System;
using System.Collections.Generic;
using System.Text;
using PortMan.Domain;

namespace PortMan.Application.UserService;
internal class UserService : IUserService
{
    public User? GetUserByEmail(string email) => throw new NotImplementedException();
    public User? GetUserByUsername(string username) => throw new NotImplementedException();
    public User? GetUserById(Guid id) => throw new NotImplementedException();
    public IEnumerable<User> GetUsersByTenantId(Guid tenantId) => throw new NotImplementedException();
    public User CreateUser(string username, string email, string password, Guid tenantId)
    {
        throw new NotImplementedException();
    }
    public bool ValidateUserCredentials(string username, string password)
    {
        throw new NotImplementedException();
    }
}
