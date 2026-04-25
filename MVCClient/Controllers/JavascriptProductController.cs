using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCClient.Controllers
{
    public class JavascriptProductController : Controller
    {
        // GET: JavascriptProduct
        
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]

        public ActionResult Create()
        {
            return View();
        }
    }
}