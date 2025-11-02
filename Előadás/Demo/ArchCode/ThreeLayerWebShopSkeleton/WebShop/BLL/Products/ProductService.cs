using WebShop.DAL.Products;
using WebShop.Domain.Products;

namespace WebShop.BLL.Products;

public class ProductService
{
    private readonly ProductRepository _repo = new();

    public Product? Find(string id) => _repo.GetById(id);
    public IEnumerable<Product> List() => _repo.GetAll();
}
