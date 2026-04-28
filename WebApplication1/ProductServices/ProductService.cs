
using System.Collections.Generic;
using System.Linq;

public class ProductService : IProductService
{
    IProductRepository _repo;
   
    public ProductService(IProductRepository repo)
    {
        _repo = repo;
    }

    public void Create(ProductModel product)
    {
        var Insert = new Product
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            Stock = product.Stock
        };

        _repo.Create(Insert);

    }

    public void Delete(int id)
    {
        var remove = _repo.GetAllProductsById(id);

        if(remove == null)
        {
            throw new System.Exception("Product not found");
        }

        _repo.Delete(id);
    }

    public List<ProductModel> GetAll()
    {
        return _repo.GetAll().Select(x =>
        {
            return new ProductModel
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                Stock = x.Stock
            };
        }).ToList();

        //return _mapper.Map<List<ProductModel>>(_repo.GetAll()).ToList();

    }

    public ProductModel GetAllProductsById(int id)
    {
        var product = _repo.GetAllProductsById(id);
        if (product == null)
        {
            throw new System.Exception("Product not found");
        }

        return new ProductModel
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            Stock = product.Stock
        };
    }

    public void Update(int id, ProductModel product)
    {
        _repo.Update(id, new Product
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            Stock = product.Stock
        });
    }
}