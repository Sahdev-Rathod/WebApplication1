using System.Collections.Generic;
using System.Threading.Tasks;

public interface IProductRepository
{
    Task<List<Product>> GetAll();
    void Create(Product product);
    Product GetAllProductsById(int id);
    void Update(int id, Product product);
    void Delete(int id);
}