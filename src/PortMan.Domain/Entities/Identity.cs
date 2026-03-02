/*
 * Copyright (c) 2026 AngryPanda Inc. All rights reserved.
 * This is the Identity entity class for the PortMan application
 */

namespace PortMan.Domain;

public class Tenant
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Phone { get; set; }
    public required string TaxPin { get; set; }
    public required string Address { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public bool IsActive { get; set; }
}

public class User
{
    public Guid Id { get; set; }
    public required string TenantId { get; set; }
    public required string Username { get; set; }
    public required string Email { get; set; }
    public required string PasswordHash { get; set; }    
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Phone { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public bool IsActive { get; set; }
    public bool IsEmailConfirmed { get; set; }
    public bool IsPhoneConfirmed { get; set; }
    public bool IsTwoFactorEnabled { get; set; }
    public bool SMSTwoFactorEnabled { get; set; }
    public bool EmailTwoFactorEnabled { get; set; }
}
