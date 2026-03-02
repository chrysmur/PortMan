/*Copyright(c) 2026 AngryPanda Inc. All rights reserved.
* This is the Identity entity class for the PortMan application
*/
using PortMan.Domain.Helpers;

namespace PortMan.Domain;

public class Country
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Code { get; set; } // ISO country code
}
public class BaseCurrency
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Code { get; set; } // ISO currency code
}

public class AssetClass
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Code { get; set; }
}

//public class CouponFrequency
//{
//    public Guid Id { get; set; }
//    public required string Name { get; set; }
//}

public class Customer
{
    public Guid Id { get; set; }
    public required string TenantId { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Phone { get; set; }
    public required string NextOfKinName { get; set; }
    public required string TaxPin { get; set; }
    public bool IsActive { get; set; }
}
public class Broker
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public string? RegulatorId { get; set; }
    public required Country CountryId { get; set; }
    public string? ContactEmail { get; set; }
    public string? ContactPhone { get; set; }
    public string? Address { get; set; }
    public bool IsActive { get; set; }
}

public class Portfolio
{
    public Guid id { get; set; }
    public required string Name { get; set; }
    public required Customer customer { get; set; }
    public required BaseCurrency BaseCurrency { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsActive { get; set; }
}

public class Instrument
{
    public Guid id { get; set; }
    public required string Name { get; set; }
    public required AssetClass AssetClass { get; set; }
    public required BaseCurrency Currency { get; set; }
    public DateTime IssueDate { get; set; }
    public DateTime? MaturityDate { get; set; } //Some assets might not have a maturity date, e.g., stocks
    public decimal FaceValue { get; set; } // Initial value of the instrument
    public decimal? InterestRate { get; set; } // For fixed income instruments. Stocks might not have an interest rate
    public CouponPeriod? InterestPeriod { get; set; }
    public bool IsTaxExcempt { get; set; } // Defaults to True. Assuming that instrument value is already taxed.
    public decimal? TaxRate { get; set; } // null for tax excempt instruments, otherwise the tax rate to apply on gains
    public decimal? ManagementFee { get; set; } // Annual management fee as a percentage of the instrument's value
    public bool IsActive { get; set; }
}

public class  Position
{
    public Guid Id { get; set; }
    public required Portfolio Portfolio { get; set; }
    public required Instrument Instrument { get; set; }
    public decimal Quantity { get; set; }
    public decimal CurrentValue { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public bool IsActive { get; set; }
}
