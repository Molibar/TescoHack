using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Molibar.Framework.IoC.StructureMap;
using TescoHack.Api.Controllers;
using TescoHack.Api.IoC;

namespace TescoHack.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //new LogEvent("Global").Raise();
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            IoCConfig.InitializeContainer(GlobalConfiguration.Configuration, new WebRegistry());
        }
    }
}
