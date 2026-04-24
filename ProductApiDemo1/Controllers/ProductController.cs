using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProductApiDemo1.Controllers
{
    public class ProductController : ApiController
    {
        IProductService _service;

        // Parameterless constructor so Web API can create the controller without a DI container.
        // This constructs the default concrete implementations. For production consider
        // configuring a DI container instead.

        //public ProductController()
        //{
        //    // create concrete dependencies manually
        //    var dbContext = new ProductDal.ProductDbContext();
        //    var repo = new ProductRepository(dbContext);
        //    _service = new ProductService(repo);
        //}

        public ProductController(IProductService service)
        {
            _service = service;
        }
        [HttpGet]
        public List<ProductModel> GetAll()
        {
            return _service.GetAll();
        }
         [HttpPost]
        public void Create(ProductModel product)
        {
            _service.Create(product);
        }
         [HttpGet]
        public ProductModel GetAllProductsById(int id)
        {
            return _service.GetAllProductsById(id);
        }
         [HttpPut]
        public void Update(int id, ProductModel product)
        {
            _service.Update(id, product);
        }
         [HttpDelete]
        public void Delete(int id)
        {
            _service.Delete(id);
        }
    }
}
