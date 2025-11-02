using WebShop.Domain.Orders;

namespace WebShop.DAL.Orders;

public class OrderRepository
{
    private static readonly Dictionary<int, Order> _orders = new();

    public Order Create(int customerId, decimal total)
    {
        var order = new Order
        {
            Id = Random.Shared.Next(1, 1_000_000),
            CustomerId = customerId,
            CreatedAt = DateTime.UtcNow,
            Total = total
        };
        _orders[order.Id] = order;
        return order;
    }

    public void Cancel(int orderId)
    {
        // mock: remove it if exists
        _orders.Remove(orderId);
    }

    public Order? GetById(int orderId)
    {
        _orders.TryGetValue(orderId, out var order);
        return order;
    }
}
