using WebShop.Domain.Invoicing;

namespace WebShop.DAL.Invoicing;

public class InvoiceRepository
{
    private static readonly Dictionary<int, Invoice> _invoices = new();
    private static int _seq = 1;

    public Invoice Issue(int orderId, decimal amount)
    {
        var inv = new Invoice { Id = _seq++, OrderId = orderId, Amount = amount, IssuedAt = DateTime.UtcNow };
        _invoices[inv.Id] = inv;
        return inv;
    }

    public Invoice? GetById(int invoiceId)
    {
        _invoices.TryGetValue(invoiceId, out var inv);
        return inv;
    }
}
