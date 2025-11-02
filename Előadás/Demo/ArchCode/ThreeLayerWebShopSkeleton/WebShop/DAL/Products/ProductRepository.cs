using WebShop.Domain.Products;

namespace WebShop.DAL.Products;

public class ProductRepository
{
    // For demo: in-memory catalog of10 products with ids1..10
    private readonly Dictionary<string, Product> _products;

    public ProductRepository()
    {
        _products = Enumerable.Range(1, 10)
        .ToDictionary(
        i => i.ToString(),
        i => new Product
        {
            Id = i.ToString(),
            Name = $"Product {i}",
            UnitPrice = 2.5m * i // deterministic pricing
        });
    }

    public Product? GetById(string id)
    {
        if (string.IsNullOrWhiteSpace(id)) return null;
        _products.TryGetValue(id.Trim(), out var p);
        return p;
    }

    public IEnumerable<Product> GetAll()
    {
        return _products.Values.OrderBy(p => p.Id);
    }
}
