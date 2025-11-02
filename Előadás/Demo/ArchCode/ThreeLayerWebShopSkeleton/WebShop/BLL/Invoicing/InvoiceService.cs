using WebShop.DAL.Invoicing;
using WebShop.Domain.Invoicing;

namespace WebShop.BLL.Invoicing;

public class InvoiceService
{
    private readonly InvoiceRepository _repo = new();

    public Invoice IssueInvoice(int orderId, decimal amount)
    {
        return _repo.Issue(orderId, amount);
    }

    public Invoice? GetInvoice(int invoiceId)
    {
        return _repo.GetById(invoiceId);
    }
}
