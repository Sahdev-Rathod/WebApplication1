using System.Collections.Generic;

public interface IProductRepository
{
    List<Product> GetAll();
    void Create(Product product);
    Product GetAllProductsById(int id);
    void Update(int id, Product product);
    void Delete(int id);
}