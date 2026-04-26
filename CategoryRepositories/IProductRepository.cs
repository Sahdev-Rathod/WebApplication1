using CategoryDAL;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IProductRepository
{
    Task<List<Product>> GetAllProducts();
    Task<Product> GetProductById(int id);
    void AddProduct(Product product);
    void UpdateProduct( int id , Product product);
    void DeleteProduct(int id);
}