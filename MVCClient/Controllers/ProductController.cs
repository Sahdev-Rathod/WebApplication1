using MVCClient.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Mvc;

namespace MVCClient.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product

        [HttpGet]
        public ActionResult Index()
        {
            List<Product> products1 = new List<Product>();

            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("https://localhost:44393/api/");

            HttpResponseMessage response = client.GetAsync("Product").Result;

            if (response.IsSuccessStatusCode)
            {
                // Deserialize the JSON response into a list of Product using JsonConvert.
                var json = response.Content.ReadAsStringAsync().Result;
                products1 = JsonConvert.DeserializeObject<List<Product>>(json);
            }

            return View(products1);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Create(Product product)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44393/api/");

            var json = JsonConvert.SerializeObject(product);

            StringContent content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PostAsync("Product", content).Result;

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(product);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            Product product1 = new Product();

            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("https://localhost:44393/api/");

            HttpResponseMessage response = client.GetAsync($"Product/{id}").Result;

            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;

                product1 = JsonConvert.DeserializeObject<Product>(json);
            }

            return View(product1);
        }

        [HttpGet]

        public ActionResult Edit(int id)
        {
            Product product1 = new Product();

            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("https://localhost:44393/api/");

            HttpResponseMessage response = client.GetAsync($"Product/{id}").Result;

            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;

                product1 = JsonConvert.DeserializeObject<Product>(json);
            }

            return View(product1);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("https://localhost:44393/api/");

            var json = JsonConvert.SerializeObject(product);

            StringContent content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PutAsync($"Product/{product.Id}", content).Result;

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(product);
        }

        [HttpGet]

        public ActionResult Delete(int id)
        {
            Product product1 = new Product();

            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("https://localhost:44393/api/");

            HttpResponseMessage response = client.GetAsync($"Product/{id}").Result;

            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;

                product1 = JsonConvert.DeserializeObject<Product>(json);
            }

            return View(product1);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int Id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44393/api/");
            HttpResponseMessage response = client.DeleteAsync($"Product/{Id}").Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}