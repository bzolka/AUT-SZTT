using WebShop.DAL.ShoppingBasket;
using WebShop.Domain.ShoppingBasket;

namespace WebShop.BLL.ShoppingBasket;

public class BasketService
{
    private readonly BasketRepository _repo = new();

    // Very simple discount logic: 5% base, plus extra 5% if total quantity >= 10
    public decimal GetDiscountPercentForCustomer(string customerName)
    {
        if (string.IsNullOrWhiteSpace(customerName)) return 0m;
        var baseDiscount = 0.05m;
        // VIP example
        if (customerName.Equals("vip", StringComparison.OrdinalIgnoreCase)) return 0.15m;
        return baseDiscount;
    }

    public Basket GetOrCreateBasket(int basketId, string customerName)
    {
        var basket = _repo.Load(basketId);
        if (basket == null)
        {
            basket = new Basket { Id = basketId, CustomerName = customerName };
            _repo.Save(basket);
        }
        else if (!string.Equals(basket.CustomerName, customerName, StringComparison.Ordinal))
        {
            // If basket was created for a different name, keep original owner but allow using it; in real apps enforce ownership.
        }
        return basket;
    }

    public void AddItem(int basketId, string customerName, BasketItem item)
    {
        var basket = GetOrCreateBasket(basketId, customerName);
        var existing = basket.Items.FirstOrDefault(i => i.ProductId == item.ProductId);
        if (existing != null)
        {
            // business rule: merging quantities, and use min unit price to avoid price increase on merge
            existing.Quantity += item.Quantity;
            existing.UnitPrice = Math.Min(existing.UnitPrice, item.UnitPrice);
            if (string.IsNullOrWhiteSpace(existing.Name)) existing.Name = item.Name;
        }
        else
        {
            basket.Items.Add(item);
        }
        _repo.Save(basket);
    }

    public bool RemoveItem(int basketId, string customerName, string productId, int quantity)
    {
        var basket = GetOrCreateBasket(basketId, customerName);
        var existing = basket.Items.FirstOrDefault(i => i.ProductId == productId);
        if (existing == null) return false;
        existing.Quantity -= quantity;
        if (existing.Quantity <= 0) basket.Items.Remove(existing);
        _repo.Save(basket);
        return true;
    }

    public IReadOnlyList<BasketItem> ListItems(int basketId)
    {
        var basket = _repo.Load(basketId) ?? new Basket { Id = basketId };
        return basket.Items.AsReadOnly();
    }

    public decimal GetSubtotal(int basketId)
    {
        var basket = _repo.Load(basketId);
        if (basket == null) return 0m;
        return basket.Items.Sum(i => i.UnitPrice * i.Quantity);
    }

    public decimal GetTotal(int basketId)
    {
        var basket = _repo.Load(basketId);
        if (basket == null) return 0m;
        var subtotal = GetSubtotal(basketId);
        // example additional business rule: bulk discount if total quantity >= 10 adds +5%
        var totalQty = basket.Items.Sum(i => i.Quantity);
        var discount = GetDiscountPercentForCustomer(basket.CustomerName);
        if (totalQty >= 10) discount += 0.05m;
        var total = subtotal * (1 - discount);
        return Math.Round(total, 2);
    }
}
