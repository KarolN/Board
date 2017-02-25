using System.Threading.Tasks;
using System.Web.Mvc;
using PgsBoard.Dtos;
using PgsBoard.Services;
using PgsBoard.ViewModels;

namespace PgsBoard.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthService _authService;

        public AccountController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View(new RegisterViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register([Bind(Prefix = "RegisterUserDto")] RegisterUserDto registerUserDto)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new RegisterViewModel()
                {
                    RegisterUserDto = registerUserDto
                };
                return View(viewModel);
            }
            await _authService.RegisterUser(registerUserDto);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public async Task<ActionResult> Login([Bind(Prefix = "LoginDto")] LoginDto loginDto)
        {
            if (ModelState.IsValid)
            {
                if (await _authService.Login(loginDto))
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("LoginDto.Username", "Nieprawidłowa nazwa użytkownika lub hasło");
            }

            var viewModel = new LoginViewModel()
            {
                LoginDto = loginDto
            };
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Logout()
        {
            _authService.Logout();
            return RedirectToAction("Index", "Home");
        }
    }
}