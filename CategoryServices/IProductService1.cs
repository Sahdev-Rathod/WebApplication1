using System.Collections.Generic;
using System.Threading.Tasks;

public interface IProductService1
{
    Task<List<ProductModel>> GetAllProducts();
    Task<ProductModel> GetProductById(int id);
    void AddProduct(ProductModel product);
    void UpdateProduct(int id, ProductModel product);
    void DeleteProduct(int id);
}