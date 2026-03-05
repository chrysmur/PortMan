/*
 * Copyright (c) 2026 AngryPanda Inc. All rights reserved.
 * This is the Identity entity class for the PortMan application
 */

namespace PortMan.Domain;

public class Tenant
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Phone { get; set; }
    public required string TaxPin { get; set; }
    public required string Address { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    public bool IsActive { get; set; }
}

public class User
{
    public Guid Id { get; set; } =  Guid.NewGuid();
    public required string TenantId { get; set; }
    public required string Username { get; set; }
    public required string Email { get; set; }
    public required string PasswordHash { get; set; }    
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Phone { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    public bool IsActive { get; set; }
    public bool IsEmailConfirmed { get; set; }
    public bool IsPhoneConfirmed { get; set; }
    public bool IsTwoFactorEnabled { get; set; }
    public bool SMSTwoFactorEnabled { get; set; }
    public bool EmailTwoFactorEnabled { get; set; }
    public IList<AccessRoles>? Roles { get; } = Array.Empty<AccessRoles>();
}
