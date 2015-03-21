using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

using App.Web.UI._Configuration;

using Castle.Windsor;
using Castle.Windsor.Installer;

namespace App.Web.UI
{
    public class Global : HttpApplication
    {
        protected void Application_Start()
        {
            MvcHandler.DisableMvcResponseHeader = true;

            RouteConfig.RegisterRoutes(RouteTable.Routes);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);

            PrepareIocContainer();
            //LogConfiguration();
        }

        private static void PrepareIocContainer()
        {
            var container = new WindsorContainer().Install(FromAssembly.This());
            ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(container.Kernel));
        }
    }
}