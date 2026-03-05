using System;
using System.Collections.Generic;
using System.Text;
using PortMan.Domain;

namespace PortMan.Application.UserService;
internal interface IUserService
{
    User? GetUserByEmail(string email);
    User? GetUserByUsername(string username);
    User? GetUserById(Guid id);
    IEnumerable<User> GetUsersByTenantId(Guid tenantId);
    User CreateUser(string username, string email, string password, Guid tenantId);
    bool ValidateUserCredentials(string username, string password);
}
