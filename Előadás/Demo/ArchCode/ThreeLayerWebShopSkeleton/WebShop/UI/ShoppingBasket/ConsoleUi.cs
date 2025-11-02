using WebShop.BLL.Auth;
using WebShop.BLL.Products;
using WebShop.BLL.ShoppingBasket;
using WebShop.Domain.ShoppingBasket;

namespace WebShop.UI.ShoppingBasket;

public class ConsoleUi
{
    private readonly AuthenticationService _auth = new();
    private readonly ProductService _productService = new();
    private readonly BasketService _basketService = new();

    public void Run()
    {
        Console.WriteLine("=== WebShop Demo (Three-Layer Architecture) ===");
        Console.Write("Enter your username: ");
        var userName = Console.ReadLine() ?? string.Empty;
        var userId = _auth.GetUserId(userName);
        Console.WriteLine($"Hello {userName}! Your user id is {userId}.");

        var basketId = userId; //1 basket per user for demo
        _basketService.GetOrCreateBasket(basketId, userName);

        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("Menu:");
            Console.WriteLine("1) Add item (by Product ID)");
            Console.WriteLine("2) Remove item");
            Console.WriteLine("3) View basket (items + totals)");
            Console.WriteLine("4) List catalog (IDs1..10)");
            Console.WriteLine("0) Exit");
            Console.Write("Choose: ");
            var choice = Console.ReadLine();
            Console.WriteLine();
            switch (choice)
            {
                case "1":
                    AddItemFlow(basketId, userName);
                    break;
                case "2":
                    RemoveItemFlow(basketId, userName);
                    break;
                case "3":
                    ViewBasketFlow(basketId, userName);
                    break;
                case "4":
                    ListCatalogFlow();
                    break;
                case "0":
                    Console.WriteLine("Bye!");
                    return;
                default:
                    Console.WriteLine("Unknown choice.");
                    break;
            }
        }
    }

    private void AddItemFlow(int basketId, string customerName)
    {
        Console.Write("Product id (1..10): ");
        var pid = (Console.ReadLine() ?? string.Empty).Trim();
        Console.Write("Quantity: ");
        var qtyStr = Console.ReadLine();
        if (!int.TryParse(qtyStr, out var qty) || qty <= 0)
        {
            Console.WriteLine("Invalid quantity.");
            return;
        }
        var product = _productService.Find(pid);
        if (product is null)
        {
            Console.WriteLine("Unknown product id.");
            return;
        }
        _basketService.AddItem(basketId, customerName, new BasketItem { ProductId = product.Id, Name = product.Name, UnitPrice = product.UnitPrice, Quantity = qty });
        Console.WriteLine($"Added {qty} x {product.Name} @ {product.UnitPrice:C}");
    }

    private void RemoveItemFlow(int basketId, string customerName)
    {
        Console.Write("Product id to remove: ");
        var pid = Console.ReadLine() ?? string.Empty;
        Console.Write("Quantity to remove: ");
        var qtyStr = Console.ReadLine();
        if (!int.TryParse(qtyStr, out var qty) || qty <= 0)
        {
            Console.WriteLine("Invalid quantity.");
            return;
        }
        var ok = _basketService.RemoveItem(basketId, customerName, pid, qty);
        Console.WriteLine(ok ? "Removed." : "Product not found.");
    }

    private void ViewBasketFlow(int basketId, string customerName)
    {
        var items = _basketService.ListItems(basketId);
        Console.WriteLine("Items:");
        if (items.Count == 0)
        {
            Console.WriteLine("Basket is empty.");
        }
        else
        {
            foreach (var i in items)
            {
                Console.WriteLine($"- {i.ProductId} | {i.Name} | {i.Quantity} x {i.UnitPrice:C} = {i.UnitPrice * i.Quantity:C}");
            }
        }

        var subtotal = _basketService.GetSubtotal(basketId);
        var discount = _basketService.GetDiscountPercentForCustomer(customerName);
        var total = _basketService.GetTotal(basketId);
        Console.WriteLine($"Subtotal: {subtotal:C}");
        Console.WriteLine($"Customer discount: {discount:P0} (extra bulk discount may apply if qty >=10)");
        Console.WriteLine($"Total: {total:C}");
    }

    private void ListCatalogFlow()
    {
        Console.WriteLine("Catalog:");
        foreach (var p in _productService.List())
        {
            Console.WriteLine($"- {p.Id}: {p.Name} @ {p.UnitPrice:C}");
        }
    }
}
