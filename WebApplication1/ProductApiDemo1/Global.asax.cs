using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Unity.AspNet.WebApi;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ProductApiDemo1
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            // Configure Unity as the Web API dependency resolver so controllers get their
            // dependencies (IProductService, etc.) injected.
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(UnityConfig.Container);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
