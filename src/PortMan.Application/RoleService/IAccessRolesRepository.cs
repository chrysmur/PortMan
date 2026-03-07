using System;
using System.Collections.Generic;
using System.Text;

namespace PortMan.Application.RoleService;

public interface IAccessRolesRepository
{
    Task<IEnumerable<string>> GetUserRolesAsync(string username, CancellationToken cancellationToken = default);
    Task<IEnumerable<string>> CreateUserRolesAsync(string userId, string role, CancellationToken cancellation = default) 
}
