namespace WebShop.Domain.ShoppingBasket;

public class Basket
{
    public int Id { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public List<BasketItem> Items { get; set; } = new();
}
