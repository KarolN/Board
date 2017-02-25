using System.Threading.Tasks;
using System.Web.Http.Results;
using System.Web.Mvc;
using PgsBoard.Dtos;
using PgsBoard.Services;

namespace PgsBoard.Controllers
{
    [System.Web.Mvc.Authorize]
    public class ListsController : Controller
    {
        private readonly IListsService _listsService;

        public ListsController(IListsService listsService)
        {
            _listsService = listsService;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateListDto createListDto)
        {
            var boardId = await _listsService.CreateNewList(createListDto);
            if (boardId == null)
            {
                return HttpNotFound();
            }
            return RedirectToAction("Show", "Boards", new {selectedBoard = boardId});
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Remove(long listId)
        {
            var result = await _listsService.RemoveList(listId);
            return result ? null : new HttpStatusCodeResult(400);
        }
    }
}