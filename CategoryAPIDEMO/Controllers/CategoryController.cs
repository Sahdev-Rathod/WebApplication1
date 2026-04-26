using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace CategoryAPIDEMO.Controllers
{
    public class CategoryController : ApiController
    {
        ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IHttpActionResult> Regester(UserModel user)
        {
            try
            {
                var result = await _service.Regester(user);

                if (result)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest("Regester Failed");
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPut]
        public async Task<IHttpActionResult> Authenticate(CreadencialRequestModel creadencial)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = await _service.Login(creadencial.Email, creadencial.Password);

                    if (user != null)
                    {
                        return Ok(user);
                    }
                    else
                    {
                        return Unauthorized();
                    }
                }
                else
                {
                    return BadRequest();
                }
              
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}