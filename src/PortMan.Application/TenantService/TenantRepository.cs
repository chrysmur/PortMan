using System;
using System.Collections.Generic;
using System.Text;
using PortMan.Domain;

namespace PortMan.Application.TenantService;
internal class TenantRepository : ITenantRepository
{
    public Task<Tenant> GetTenantByIdAsync(string tenantId, CancellationToken token) => throw new NotImplementedException();
}
