using System.Web.Mvc;

using App.Infrastructure.Logging;

namespace App.Web.NedSet.Controllers
{
    public class BaseController : Controller
    {
        public HtmlHelper _htmlHelper;

        public readonly ILoggingService _loggingService;
        //public readonly IUserService _userService;
        //public readonly IFormsAuthenticationService _formsAuthenticationService;

        public BaseController(
            ILoggingService loggingService
            //IUserService userService,
            //IFormsAuthenticationService formsAuthenticationService
            )
        {
            _loggingService = loggingService;
            //_userService = userService;
            //_formsAuthenticationService = formsAuthenticationService;

            _htmlHelper = new HtmlHelper(new ViewContext(), new ViewPage());
        }

        public ActionResult RedirectToHome()
        {
            return Redirect("/");
        }

        //private UserModel _currentUser;
        //public UserModel CurrentUser
        //{
        //    get
        //    {
        //        if (_currentUser != null) return _currentUser;

        //        if (User.Identity.IsAuthenticated)
        //        {
        //            var work = _userService.GetByUserName(User.Identity.GetUserName());
        //            var user = work.Result;
        //            work.Wait();

        //            _currentUser = UserModel.MapUserToUserModel(user);
        //        }

        //        return _currentUser;
        //    }
        //}
    }
}