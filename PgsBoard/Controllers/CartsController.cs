using System.Threading.Tasks;
using System.Web.Mvc;
using PgsBoard.Dtos;
using PgsBoard.Services;

namespace PgsBoard.Controllers
{
    [Authorize]
    public class CartsController : Controller
    {
        private readonly ICartsService _cartsService;

        public CartsController(ICartsService cartsService)
        {
            _cartsService = cartsService;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateCartDto createCartDto)
        {
            var boardId = await _cartsService.CreateCart(createCartDto);
            return RedirectToAction("Show", "Boards", new {selectedBoard = boardId});
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Remove(long cartId)
        {
            var result = await _cartsService.RemoveCart(cartId);
            return result ? null : new HttpStatusCodeResult(400);
        }

        [HttpPost]
        public async Task<ActionResult> UpdatePosition(UpdateCartPositionDto updateCartPositionDto)
        {
            await _cartsService.UpdateCartPosition(updateCartPositionDto);
            return new HttpStatusCodeResult(200);
        }

        [HttpPost]
        public async Task<ActionResult> Move(MoveCartDto moveCartDto)
        {
            await _cartsService.MoveCart(moveCartDto);
            return new HttpStatusCodeResult(200);
        }
    }
}