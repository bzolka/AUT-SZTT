using WebShop.Domain.Payments;

namespace WebShop.DAL.Payments;

public class PaymentRepository
{
    private static readonly Dictionary<int, Payment> _payments = new();
    private static int _seq = 1;

    public Payment Authorize(int orderId, decimal amount)
    {
        var p = new Payment { Id = _seq++, OrderId = orderId, Amount = amount, Status = PaymentStatus.Authorized };
        _payments[p.Id] = p;
        return p;
    }

    public Payment Capture(int paymentId)
    {
        if (_payments.TryGetValue(paymentId, out var p))
        {
            p.Status = PaymentStatus.Captured;
            return p;
        }
        return new Payment { Id = paymentId, OrderId = 0, Amount = 0, Status = PaymentStatus.Failed };
    }

    public void Refund(int paymentId)
    {
        if (_payments.TryGetValue(paymentId, out var p))
        {
            p.Status = PaymentStatus.Failed; // mock change
        }
    }
}
