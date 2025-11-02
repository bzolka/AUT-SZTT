namespace WebShop.Domain.Customers;

public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal LoyaltyDiscountPercent { get; set; } //0..1
}
