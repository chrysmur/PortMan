using System;
using System.Collections.Generic;
using System.Text;
using PortMan.Domain;

namespace PortMan.Application.TenantService;
internal interface ITenantRepository
{
    Task<Tenant> GetTenantByIdAsync(string tenantId, CancellationToken token);
}
