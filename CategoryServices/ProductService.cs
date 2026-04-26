using CategoryDAL;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

public class ProductService : IProductService1
{
    IProductRepository _productRepository;
    
    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public void AddProduct(ProductModel product)
    {
        var entity = new Product
        {
            Id = product.Id,
            Name = product.Name,
            price = product.price,
            Stock = product.Stock,
            productCompany = product.productCompany
        };

        _productRepository.AddProduct(entity);
    }

    public void DeleteProduct(int id)
    {
       _productRepository.DeleteProduct(id);
    }

    public async Task<List<ProductModel>> GetAllProducts()
    {
        var result = await _productRepository.GetAllProducts();

        return result.Select(r => new ProductModel
        {
            Id = r.Id,
            Name = r.Name,
            price = r.price,
            Stock = r.Stock,
            productCompany = r.productCompany
        }).ToList();
    }

    public async Task<ProductModel> GetProductById(int id)
    {
        var p = await _productRepository.GetProductById(id);

        if (p == null) return null;

        return new ProductModel
        {
            Id = p.Id,
            Name = p.Name,
            price = p.price,
            Stock = p.Stock,
            productCompany = p.productCompany
        };

      }
    public void UpdateProduct(int id, ProductModel product)
    {
       _productRepository.UpdateProduct(id, new Product
        {
            Name = product.Name,
            price = product.price,
            Stock = product.Stock,
            productCompany = product.productCompany
        });
    }
}