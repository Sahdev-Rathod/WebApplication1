using CategoryDAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

public class ProductRepository : IProductRepository
{
    CategoryAuthenticationDbContext _context;

    public ProductRepository(CategoryAuthenticationDbContext context)
    {
        _context = context;
    }

    public void AddProduct(Product product)
    {
       if(product == null)
        {
            throw new ArgumentNullException(nameof(product));
        }
        _context.Products.Add(product);
        _context.SaveChanges();
    }

    public void DeleteProduct(int id)
    {
       var product =  _context.Products.Find(id);

       if (product == null)
       {
           throw new ArgumentNullException(nameof(product));
       }
       _context.Products.Remove(product);
       _context.SaveChanges();
    }

    public async Task<List<Product>> GetAllProducts()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task<Product> GetProductById(int id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product == null)
        {
            throw new ArgumentNullException(nameof(product));
        }
        return product;
    }
    public void UpdateProduct( int id , Product product)
    {
        if (product == null)
        {
            throw new ArgumentNullException(nameof(product));
        }
         product.Id = id;
        _context.Products.Attach(product);
        _context.Entry(product).State = EntityState.Modified;
        _context.SaveChanges();
    }
}