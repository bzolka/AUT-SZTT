namespace WebShop.Domain.Invoicing;

public class Invoice
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public DateTime IssuedAt { get; set; }
    public decimal Amount { get; set; }
}
