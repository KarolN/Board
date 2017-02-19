using System.Threading.Tasks;
using System.Web.Mvc;
using PgsBoard.Dtos;
using PgsBoard.Services;

namespace PgsBoard.Controllers
{
    [Authorize]
    public class ListsController : Controller
    {
        private readonly IListsService _listsService;

        public ListsController(IListsService listsService)
        {
            _listsService = listsService;
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateListDto createListDto)
        {
            var boardId = await _listsService.CreateNewList(createListDto);
            if (boardId == null)
            {
                return HttpNotFound();
            }
            return RedirectToAction("Show", "Boards", new {selectedBoard = boardId});
        }
    }
}