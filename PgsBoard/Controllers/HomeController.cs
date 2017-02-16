using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using PgsBoard.Infrastructure;
using PgsBoard.Services;

namespace PgsBoard.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBoardsService _boardsService;

        public HomeController(IBoardsService boardsService)
        {
            _boardsService = boardsService;
        }

        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Board");
            }
            return View();
        }
    }
}