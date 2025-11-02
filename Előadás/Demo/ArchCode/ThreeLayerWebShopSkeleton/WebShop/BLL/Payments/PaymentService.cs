using WebShop.DAL.Payments;
using WebShop.Domain.Payments;

namespace WebShop.BLL.Payments;

public class PaymentService
{
    private readonly PaymentRepository _repo = new();

    public Payment Authorize(int orderId, decimal amount)
    {
        return _repo.Authorize(orderId, amount);
    }

    public Payment Capture(int paymentId)
    {
        return _repo.Capture(paymentId);
    }

    public void Refund(int paymentId)
    {
        _repo.Refund(paymentId);
    }
}
