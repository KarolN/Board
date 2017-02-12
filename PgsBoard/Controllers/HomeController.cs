using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using PgsBoard.Infrastructure;

namespace PgsBoard.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAuthInfrastructure _authInfrastructure;

        public HomeController(IAuthInfrastructure authInfrastructure)
        {
            _authInfrastructure = authInfrastructure;
        }

        public ActionResult Index()
        {
            var userId = _authInfrastructure.GetCurrentUserId();
            return View();
        }
    }
}