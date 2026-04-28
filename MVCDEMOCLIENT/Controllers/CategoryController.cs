using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Text;
using System.Web.Security;

namespace MVCDEMOCLIENT.Controllers
{
    public class CategoryController : Controller
    {

        HttpClient _client;

        public CategoryController()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri(ConfigurationManager.AppSettings["APIURL"]);
        }
        // GET: Category

        [HttpGet]
        public ActionResult Regester()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Regester(UserModel model)
        {
            try
            {

                var Json = JsonConvert.SerializeObject(model);

                StringContent content = new StringContent(Json, System.Text.Encoding.UTF8, "application/json");

                HttpResponseMessage responce = _client.PostAsync("Category", content).Result;

                if (responce.IsSuccessStatusCode)
                {
                    var result = responce.Content.ReadAsStringAsync().Result;

                    var user = JsonConvert.DeserializeObject<bool>(result);

                    return RedirectToAction("Login");
                }
                else
                {
                    ViewBag.Error = responce.ReasonPhrase;
                    return View(model);
                }

            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;

                return View(model);
            }
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(CreadencialRequestModel model)
        {

            try
            {
                var Json = JsonConvert.SerializeObject(model);

                StringContent content = new StringContent(Json,
                    Encoding.UTF8, "application/json");

                HttpResponseMessage responce = _client.PutAsync("Category", content).Result;

                FormsAuthentication.SetAuthCookie(model.Email, false);

                if (responce.IsSuccessStatusCode)
                {
                    var result = responce.Content.ReadAsStringAsync().Result;

                    var user = JsonConvert.DeserializeObject<UserModel>(result);

                    // Session["User"] = user;

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Error = responce.ReasonPhrase;
                    return View(model);
                }

            }
            catch (Exception ex)
            {
                return View(model);
            }
        }

        [HttpGet]

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}