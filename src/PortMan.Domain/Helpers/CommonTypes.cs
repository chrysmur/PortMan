
namespace PortMan.Domain.Helpers;
public enum SubscriptionPeriod
{
    Monthly,
    SemiAnnually,
    Yearly
}

public enum CouponPeriod
{
    Daily,
    Weekly,
    Monthly,
    Quarterly,
    SemiAnnually,
    Annually
}

public enum PaymentMethod
{
    Card,
    MobileMoney,
    //PayPal,
    //BankTransfer
}

public enum TransactionType
{
    Buy,
    Sell,
    CouponPayment,
    Maturity,
    Dividend,
    InterestPayment,
    Fee,
    Transfer
}
