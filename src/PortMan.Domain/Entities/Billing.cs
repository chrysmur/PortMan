using PortMan.Domain.Helpers;

namespace PortMan.Domain;

public class SubscriptionPlan
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required SubscriptionPeriod BillingCycle { get; set; } // e.g., Monthly, Yearly
    public required decimal Price { get; set; }
    public string? Description { get; set; }
}

public class Subscriptions
{
    public Guid Id { get; set; }
    public Guid TenantId { get; set; }
    public Guid SubscriptionPlanId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool CancelAtEndOfPeriod { get; set; }
    public bool IsTrial { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public bool IsActive { get; set; }
}

public class BillingRecords
{
    public Guid Id { get; set; }
    public Guid TenantId { get; set; }
    public Guid SubscriptionId { get; set; }
    public decimal Amount { get; set; }
    public DateTime BillingDate { get; set; }
    public required PaymentMethod PaymentMethod { get; set; } // e.g., Credit Card, PayPal
    public required string TransactionId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
