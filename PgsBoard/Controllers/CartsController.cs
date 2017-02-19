using System.Threading.Tasks;
using System.Web.Mvc;
using PgsBoard.Dtos;
using PgsBoard.Services;

namespace PgsBoard.Controllers
{
    public class CartsController : Controller
    {
        private readonly ICartsService _cartsService;

        public CartsController(ICartsService cartsService)
        {
            _cartsService = cartsService;
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateCartDto createCartDto)
        {
            var boardId = await _cartsService.CreateCart(createCartDto);
            return RedirectToAction("Show", "Boards", new {selectedBoard = boardId});
        }
    }
}