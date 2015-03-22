using System.Web.Mvc;

using App.Infrastructure.Logging;

namespace App.Web.UI.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(
            ILoggingService loggingService) 
            : base(loggingService)
        {
        }

        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Title = "Nedset";
            return View();
        }
    }
}