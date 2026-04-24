using System.Collections.Generic;

public interface IProductService
{
    List<ProductModel> GetAll();
    void Create(ProductModel product);
    ProductModel GetAllProductsById(int id);
    void Update(int id, ProductModel product);
    void Delete(int id);
}