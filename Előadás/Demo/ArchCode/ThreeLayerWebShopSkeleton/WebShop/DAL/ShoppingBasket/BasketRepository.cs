using System.Text.Json;
using WebShop.Domain.ShoppingBasket;

namespace WebShop.DAL.ShoppingBasket;

public class BasketRepository
{
    private readonly string _storageFolder;

    public BasketRepository()
    {
        _storageFolder = Path.Combine(AppContext.BaseDirectory, "data", "baskets");
        Directory.CreateDirectory(_storageFolder);
    }

    private string PathFor(int basketId) => System.IO.Path.Combine(_storageFolder, $"basket-{basketId}.json");

    public Basket? Load(int basketId)
    {
        var path = PathFor(basketId);
        if (!File.Exists(path)) return null;
        var json = File.ReadAllText(path);
        return JsonSerializer.Deserialize<Basket>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
    }

    public void Save(Basket basket)
    {
        var path = PathFor(basket.Id);
        var json = JsonSerializer.Serialize(basket, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(path, json);
    }

    public void Delete(int basketId)
    {
        var path = PathFor(basketId);
        if (File.Exists(path)) File.Delete(path);
    }
}
