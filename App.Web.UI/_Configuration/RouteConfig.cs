using System.Web.Mvc;
using System.Web.Routing;

namespace App.Web.UI._Configuration
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapRoute("Default", 
                            "{controller}/{action}/{id}", 
                            new { controller = "Home", action = "Index", id = UrlParameter.Optional });
        }
    }
}
