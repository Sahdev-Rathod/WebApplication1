using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace CategoryAPIDEMO.Controllers
{
    // [Authorize] When you want to secure the API and allow only authenticated users to access it,
    // you can use the [Authorize] attribute on the controller or specific actions.
    // This will ensure that only users who have been authenticated can access the endpoints of the ProductController.
  
    public class ProductController : ApiController
    {
        IProductService1 _service;

        public ProductController(IProductService1 service)
        {
            _service = service;
        }

        [HttpGet]

        public async Task<IHttpActionResult> GetAllProducts()
        {
            try
            {
                var result = await _service.GetAllProducts();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetProductById(int id)
        {
            try
            {
                if (id > 0)
                {
                    var result = await _service.GetProductById(id);
                    return Ok(result);
                }
                else
                {
                    return BadRequest("Id is required");
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]

        public IHttpActionResult AddProduct(ProductModel product)
        {
            try
            {
                if (product != null)
                {
                    _service.AddProduct(product);

                    return Ok(product);
                }
                else
                {
                    return BadRequest("Product is required");
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPut]
        public IHttpActionResult UpdateProduct(int id, ProductModel product)
        {
            try
            {
                if (id > 0 && product != null)
                {
                    _service.UpdateProduct(id, product);
                    return Ok(product);
                }
                else
                {
                    return BadRequest("Id and Product are required");
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpDelete]
        public IHttpActionResult DeleteProduct(int id)
        {
            try
            {
                if (id > 0)
                {
                    _service.DeleteProduct(id);
                    return Ok($"Product with Id {id} has been deleted");
                }
                else
                {
                    return BadRequest("Id is required");
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
