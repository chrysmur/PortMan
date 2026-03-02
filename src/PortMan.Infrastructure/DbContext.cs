/*Copyright(c) 2026 AngryPanda Inc. All rights reserved.
* This is the Identity entity class for the PortMan application
*/

using Microsoft.EntityFrameworkCore;
using PortMan.Domain;
using PortMan.Domain.Entities;

namespace PortMan.Infrastructure;

public class PortManDbContext : DbContext
{
    // Identity Entities
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<User> Users { get; set; }

    // Access Control Entities
    public DbSet<AccessRoles> AccessRoles { get; set; }
    public DbSet<AccessGroups> AccessGroups { get; set; }
    public DbSet<UserAccessGroups> UserAccessGroups { get; set; }
    public DbSet<AccessGroupRoles> AccessGroupRoles { get; set; }

    // Transaction Entities
    public DbSet<Transactions> Transactions { get; set; }
    public DbSet<InstrumentPriceHistory> InstrumentPriceHistories { get; set; }
}
