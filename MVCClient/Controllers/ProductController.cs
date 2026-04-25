using MVCClient.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MVCClient.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product

        private readonly HttpClient _client;

        public ProductController()
        {
            string url = ConfigurationManager.AppSettings["URL"];

            _client = new HttpClient
            {
                BaseAddress = new Uri(url)
            };
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            List<Product> products1 = new List<Product>();

            //HttpClient client = new HttpClient();

            //client.BaseAddress = new Uri("https://localhost:44393/api/");

            using (HttpResponseMessage response = await _client.GetAsync("Product"))
            {
                if (response.IsSuccessStatusCode)
                {
                    // Deserialize the JSON response into a list of Product using JsonConvert.
                    var json = response.Content.ReadAsStringAsync().Result;
                    products1 = JsonConvert.DeserializeObject<List<Product>>(json);
                }

            }

            return View(products1);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public async Task<ActionResult> Create(Product product)
        {
            //HttpClient client = new HttpClient();
            //client.BaseAddress = new Uri("https://localhost:44393/api/");

            var json = JsonConvert.SerializeObject(product);

            StringContent content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _client.PostAsync("Product", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(product);
        }

        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            Product product1 = new Product();

            //HttpClient client = new HttpClient();

            //client.BaseAddress = new Uri("https://localhost:44393/api/");

            HttpResponseMessage response = await _client.GetAsync($"Product/{id}");

            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;

                product1 = JsonConvert.DeserializeObject<Product>(json);
            }

            return View(product1);
        }

        [HttpGet]

        public async Task<ActionResult> Edit(int id)
        {
            Product product1 = new Product();

            //HttpClient client = new HttpClient();

            //client.BaseAddress = new Uri("https://localhost:44393/api/");

            HttpResponseMessage response = await _client.GetAsync($"Product/{id}");

            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;

                product1 = JsonConvert.DeserializeObject<Product>(json);
            }

            return View(product1);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Product product)
        {
            //HttpClient client = new HttpClient();

            //client.BaseAddress = new Uri("https://localhost:44393/api/");

            var json = JsonConvert.SerializeObject(product);

            StringContent content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _client.PutAsync($"Product/{product.Id}", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(product);
        }

        [HttpGet]

        public async Task<ActionResult> Delete(int id)
        {
            Product product1 = new Product();

            //HttpClient client = new HttpClient();

            //client.BaseAddress = new Uri("https://localhost:44393/api/");

            HttpResponseMessage response = await _client.GetAsync($"Product/{id}");

            if (response.IsSuccessStatusCode)
            {
                var json = response.Content.ReadAsStringAsync().Result;

                product1 = JsonConvert.DeserializeObject<Product>(json);
            }

            return View(product1);
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed(int Id)
        {
            //HttpClient client = new HttpClient();
            //client.BaseAddress = new Uri("https://localhost:44393/api/");

            using (HttpResponseMessage response = await _client.DeleteAsync($"Product/{Id}"))
            {
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }           
            return View();
        }
    }
}