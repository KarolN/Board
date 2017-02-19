using System.Threading.Tasks;
using System.Web.Mvc;
using PgsBoard.Dtos;
using PgsBoard.Services;
using PgsBoard.ViewModels;

namespace PgsBoard.Controllers
{
    [Authorize]
    public class BoardsController : Controller
    {
        private readonly IBoardsService _boardsService;

        public BoardsController(IBoardsService boardsService)
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

        [HttpGet]
        public async Task<ActionResult> Show(string selectedBoard)
        {
            long selectedBoardId;
            if (!long.TryParse(selectedBoard, out selectedBoardId))
            {
                return new HttpNotFoundResult();
            }

            var viewModel = await _boardsService.GetBoard(selectedBoardId);
            if (viewModel == null)
            {
                return new HttpNotFoundResult();
            }
            return View(viewModel);
        }
    }
}