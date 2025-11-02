using WebShop.Domain.Customers;

namespace WebShop.DAL.Customers;

public class CustomerRepository
{
    private static readonly Dictionary<int, Customer> _customersById = new();
    private static readonly Dictionary<string, int> _idByName = new(StringComparer.OrdinalIgnoreCase);

    public Customer GetOrCreate(string name, int id)
    {
        if (string.IsNullOrWhiteSpace(name)) name = $"Customer{id}";
        if (_customersById.TryGetValue(id, out var existing))
        {
            return existing;
        }
        var discount = name.Equals("vip", StringComparison.OrdinalIgnoreCase) ? 0.10m : 0.02m;
        var c = new Customer { Id = id, Name = name, LoyaltyDiscountPercent = discount };
        _customersById[id] = c;
        _idByName[name] = id;
        return c;
    }

    public Customer? GetById(int id) => _customersById.TryGetValue(id, out var c) ? c : null;

    public Customer? GetByName(string name)
    {
        if (_idByName.TryGetValue(name, out var id)) return GetById(id);
        return null;
    }
}
