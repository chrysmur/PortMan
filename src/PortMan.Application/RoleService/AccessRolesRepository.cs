using System;
using System.Collections.Generic;
using System.Text;
using PortMan.Domain;

namespace PortMan.Application.RoleService;

public class AccessRolesRepository : IAccessRolesRepository
{
    public Task<IEnumerable<string>> GetUserRolesAsync(string userId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
    public Task<IEnumerable<string>> CreateUserRolesAsync(string userId, string role, CancellationToken cancellation = default)
    {
        throw new NotImplementedException();
    }
}
