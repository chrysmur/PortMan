using PortMan.Domain.Helpers;

namespace PortMan.Domain.Entities;
public class Transactions
{
    public Guid Id { get; set; }
    public required TransactionType Type { get; set; }
    public string? Description { get; set; }
    public required Portfolio Portfolio { get; set; } 
    public required Instrument Instrument { get; set; }
    public DateTime TransactionDate { get; set; } = DateTime.Now;
    public decimal Quantity { get; set; }
    public decimal Price { get; set; }
    public decimal PriceTotal { get; set; }
    public required User createdBy { get; set; }
}


public class  InstrumentPriceHistory
{
    public required Portfolio Portfolio { get; set; }
    public required Instrument Instrument { get; set; }
    public DateTime PriceDate { get; set; } = DateTime.Now;
    public decimal Price { get; set; }
    public decimal Yield { get; set; }
}
