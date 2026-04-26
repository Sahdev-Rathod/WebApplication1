using System;
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

        // Login Api Using Email And Password Which is Registerd By User
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
                        //string token = JwtHelper.GenerateToken(user.Email , user.RoleName);

                        //return Ok(token);

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
