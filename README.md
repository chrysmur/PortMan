/PortMAn
│
├── PortMAn.Web            → Presentation layer (Web API / MVC)
├── PortMAn.Application    → Use cases, services, commands, queries
├── PortMAn.Domain         → Business models, entities, domain events
├── PortMAn.Infrastructure → EF Core, File I/O, SMTP, external APIs
├── PortMAn.Tests          → Unit and integration tests

Folder structure
PortMan.sln
│
├── src/
│   ├── PortMan.Web/PortMan.Web.csproj
│   ├── PortMan.Application/PortMan.Application.csproj
│   ├── PortMan.Domain/PortMan.Domain.csproj
│   ├── PortMan.Infrastructure/PortMan.Infrastructure.csproj
│
└── tests/
    └── PortMan.Tests/PortMan.Tests.csproj


Commands
mkdir PortMan
cd .\PortMan\
dotnet new sln -n PortMan
mkdir src
mkdir tests
dotnet new webapi -n PortMan.Api -o .\src\PortMan.Api
dotnet new classlib -n PortMan.Domain -o .\src\PortMan.Domain
dotnet new classlib -n PortMan.Application -o .\src\PortMan.Application
dotnet new classlib -n PortMan.Infrastructure -o .\src\PortMan.Infrastructure
dotnet new xunit -n PortMan.Tests -o .\tests\PortMan.Tests

dotnet sln add src/PortOne.Api
dotnet sln add src/PortOne.Domain
dotnet sln add src/PortOne.Application
dotnet sln add src/PortOne.Infrastructure
dotnet sln add tests/PortOne.Tests

dotnet add .\src\PortMan.Application\ reference .\src\PortMan.Domain\
dotnet add .\src\PortMan.Api\ reference .\src\PortMan.Application\
dotnet add .\src\PortMan.Infrastructure\ reference .\src\PortMan.Application\
dotnet add .\tests\PortMan.Tests\ reference .\src\PortMan.Application\
dotnet add .\tests\PortMan.Tests\ reference .\src\PortMan.Api\
dotnet add .\tests\PortMan.Tests\ reference .\src\PortMan.Domain\
dotnet add .\tests\PortMan.Tests\ reference .\src\PortMan.Infrastructure\



DB SChema

## IDENTITY
### Users
- Id
- TenantId (> Tenant)
- Email
- PhoneNumber
- FirstName
- LastName
- PasswordHash
- IsActive
- DateCreated
- DateUpdated
- LastLoginAt
- IsEmailVerified
- IsPhoneNumberVerified
- Is2FAEnabled
- SMS2FA
- Email2FA

### Tenants
- Id
- Name
- Email
- PhoneNumber
- Address
- KRAPin
- IsActive
- DateCreated
- DateUpdated

## RBAC
### AccessRoles (e.g PortfolioRead, PortfolioEdit) (Define access roles)
- Id
- Name

### AccessGroups (Tenant level e.g pmanagers, analysts etc) (define accessgroups)
- Id
- Name
- TenantId (> Tenant)

### UserAccessGroups ( Assign users to accessgroups)
- Id
- UserId (> User)
- AccessGroupId (> AccessGroups)

### AccessGroupRoles (Assign roles to groups)
- Id
- AccessGroupId (> )
- AccessRoleId (> AccessRoles)

## BILLING
### SubscriptionPlans
- Id
- Name
- Period
- InvoicePeriod
- Price

### Subscriptions
- Id
- TenantId (> TenantId)
- PlanId (> SubscriptionPlans)
- CurrentPeriodStart
- CurrentPeriodEnd
- CancelAtPeriodEnd
- CancelledAt
- CreatedAt
- UpdatedAt
- InvoicedAmount ( removing this logic. We want to only directly charge at the start of the period and if failed, cancel subscription until user initiates a new subscription)
- PaidAmount
- Balance
- IsActive

### BillingRecords (Audit trail of the subscription records)
- Id
- TenantId
- TransactionDate
- TransactionType (Invoice, Billing, Cancellation, )

## CORE
### Country
- Id
- Name

### Brokers
- Id
- Name
- RegulatorId(e.g CMA ID)
- CountryId (> Country)
- Email
- ContactPersonName
- ContactPersonEmail

### BaseCurrency
- Id
- Code
- Name

### AssetClass ( e.g TBill, TBond, MMF)
- Id
- Code
- Name

### CouponFrequency (Month, Quarterly,etc) **
- Id
- Name

### Customer
- Id
- TenantId (> Tenant)
- Name
- EmailAddress
- PhoneNumber
- NextOfKin
- TaxPIN


### Portfolio (Record of a container)
- Id
- CustomerId (> Customer)
- Name
- BaseCurrencyId
- CreatedAt

### Instruments (For Analytics)
- Id
- Name
- ISIN
- AssetClassId (> AssetClass)
- CurrencyId (> BaseCurrency)
- IssueDate
- MaturityDate
- FaceValue
- CouponRate ( <> nullable for mmf and others)
- CouponFrequencyId (> CouponFrequency)
- IsTaxExempt
- ManagementFee
- IsActive

### Position
- Id
- PortfolioId (> Portfolio)
- InstrumentId (> Instrument)
- Quantity (Default 1)
- AverageCost
- AccruedInterest
- RealizedPnL
- CreatedAt

## ANALYTICS
### TransactionsType (Buy, Sells, Coupon Payment, Maturity, Dividend)
- Id
- Type


### Transactions
- Id
- TransactionTypeId(> TransactionType)
- PortfolioId (> Portfolio)
- InstrumentId (> Instrument)
- TransactionDate
- SettlementDate
- Quantity
- Price
- AccruedInterest
- Fees
- NetAmount
- CreatedBy (> User)
 
### InstrumentPriceHistory (Composite Key InstrumentId, PriceDate)
- InstrumentId
- PriceDate
- CleanPrice
- Yield


 # Anaylytics to add
✔ Yield to Maturity (YTM)
✔ Modified Duration
✔ Convexity
✔ Income Return vs Capital Return
✔ Portfolio Allocation %
✔ Weighted Average Duration
✔ Tax-adjusted return
✔ Currency exposure
✔ Broker exposure
✔ Asset class breakdown


