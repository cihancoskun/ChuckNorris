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

        [HttpGet]
        public ActionResult Product()
        {
            ViewBag.Title = "Nedset - Ürün Hakkında";
            return View();
        }

        [HttpGet]
        public ActionResult Retail()
        {
            ViewBag.Title = "Nedset - Perakendecilik";
            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            ViewBag.Title = "Nedset - İletişim";
            return View();
        }

        [HttpGet]
        public ActionResult Benefits()
        {
            ViewBag.Title = "Nedset - Faydaları";
            return View();
        }

        [HttpGet]
        public ActionResult Loging()
        {
            ViewBag.Title = "Nedset - Kullanıcı Girişi";
            return View();
        }
    }
}