using System.Web.Mvc;

using App.Infrastructure.Logging;

namespace App.Web.NedSet.Controllers
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
            ViewBag.Title = "NedSet home index";
            return View();
        }
    }
}