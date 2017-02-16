using System.Threading.Tasks;
using System.Web.Mvc;
using PgsBoard.Dtos;
using PgsBoard.Services;

namespace PgsBoard.Controllers
{
    [Authorize]
    public class BoardController : Controller
    {
        private readonly IBoardsService _boardsService;

        public BoardController(IBoardsService boardsService)
        {
            _boardsService = boardsService;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var mainPageViewModel = await _boardsService.GetMainPageViewModel();
            return View(mainPageViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateBoardDto createBoardDto)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = await _boardsService.GetMainPageViewModel();
                viewModel.CreateBoardDto = createBoardDto;
                return View("Index", viewModel);
            }
            await _boardsService.CreateBoard(createBoardDto);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Show(string selectedBoard)
        {
            return View("Show");
        }
    }
}