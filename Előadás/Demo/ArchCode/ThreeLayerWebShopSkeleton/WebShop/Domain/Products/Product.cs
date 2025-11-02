namespace WebShop.Domain.Products;

public class Product
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public decimal UnitPrice { get; set; }
}
