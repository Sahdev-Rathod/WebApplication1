using ProductDal;
using System.Collections.Generic;
using System.Linq;

public class ProductRepository : IProductRepository
{
    ProductDbContext _context;

    public ProductRepository(ProductDbContext context)
    {
        _context = context;
    }

    public List<Product> GetAll()
    {
        return _context.Products.ToList();
    }

    public void Create(Product product)
    {
        _context.Products.Add(product);
        _context.SaveChanges();
    }
    public Product GetAllProductsById(int id)
    {
        return _context.Products.FirstOrDefault(p => p.Id == id);
    }
    
    public void Update( int id , Product product)
    {
         var products = _context.Products.Find(id);

        _context.Entry(products).State = System.Data.Entity.EntityState.Modified;

        _context.SaveChanges();
    }

    public void Delete(int id)
    {
         _context.Products.Remove(GetAllProductsById(id));
        _context.SaveChanges();
    }
}