using WebShop.DAL.Customers;
using WebShop.Domain.Customers;

namespace WebShop.BLL.Customers;

public class CustomerService
{
    private readonly CustomerRepository _repo = new();

    public Customer GetOrCreate(string name, int id)
    {
        return _repo.GetOrCreate(name, id);
    }

    public Customer? GetById(int id) => _repo.GetById(id);
    public Customer? GetByName(string name) => _repo.GetByName(name);
}
