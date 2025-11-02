using WebShop.DAL.Orders;
using WebShop.Domain.Orders;

namespace WebShop.BLL.Orders;

public class OrderService
{
    private readonly OrderRepository _repo = new();

    public Order CreateOrderFromBasket(int customerId, decimal total)
    {
        // delegate to DAL (mock persistence)
        return _repo.Create(customerId, total);
    }

    public void CancelOrder(int orderId)
    {
        _repo.Cancel(orderId);
    }

    public Order? GetOrder(int orderId)
    {
        return _repo.GetById(orderId);
    }
}
