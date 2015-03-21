using System.Web.Mvc;
using App.Infrastructure.Logging;

namespace App.Web.NedSet.Controllers
{
    public class UserController : BaseController
    {
        public UserController(ILoggingService loggingService) : base(loggingService)
        {
        }

        [HttpGet, AllowAnonymous]
        public ActionResult Login()
        {
            ViewBag.Title = "Nedset User Login";
            return View();
        }
    }
}