using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PgsBoard.Data.Entities;
using PgsBoard.Dtos;
using PgsBoard.Infrastructure;
using PgsBoard.Repositories;

namespace PgsBoard.Services.Implementation
{
    public class CartsService : ICartsService
    {
        private readonly ICartsRepository _cartsRepository;
        private readonly IListsRepository _listsRepository;
        private readonly IBoardsRepository _boardsRepository;
        private readonly IAuthInfrastructure _authInfrastructure;

        public CartsService(ICartsRepository cartsRepository,
            IListsRepository listsRepository,
            IBoardsRepository boardsRepository,
            IAuthInfrastructure authInfrastructure)
        {
            _cartsRepository = cartsRepository;
            _listsRepository = listsRepository;
            _boardsRepository = boardsRepository;
            _authInfrastructure = authInfrastructure;
        }

        public async Task<long> CreateCart(CreateCartDto createCartDto)
        {
            var count = await _cartsRepository.GetCountCartsInList(createCartDto.ListId);

            var cart = new Cart()
            {
                Name = createCartDto.Name,
                Description = createCartDto.Description,
                ListId = createCartDto.ListId,
                Position = count
            };

            _cartsRepository.Insert(cart);
            await _cartsRepository.SaveChangesOnContext();

            var list = await _listsRepository.GetEntity(createCartDto.ListId);
            return list.BoardId;
        }

        public async Task<bool> RemoveCart(long cartId)
        {
            var cart = await _cartsRepository.GetEntity(cartId);
            if (cart == null)
            {
                return false;
            }
            var list = await _listsRepository.GetEntity(cart.ListId);
            var board = await _boardsRepository.GetEntity(list.BoardId);
            var currentUserId = _authInfrastructure.GetCurrentUserId();
            if (currentUserId != board.OwnerId)
            {
                return false;
            }

            _cartsRepository.Remove(cart);
            await _cartsRepository.SaveChangesOnContext();
            return true;
        }

        public async Task UpdateCartPosition(UpdateCartPositionDto updateCartPositionDto)
        {
            var cart = await _cartsRepository.GetEntity(updateCartPositionDto.CartId);
            if (cart == null)
            {
                return;
            }
            var list = await _listsRepository.GetListWithCarts(cart.ListId);

            var cartInNewPosition = list.Carts.Single(x => x.Position == updateCartPositionDto.NewPosition);
            cartInNewPosition.Position = cart.Position;
            cart.Position = updateCartPositionDto.NewPosition;
            await _cartsRepository.SaveChangesOnContext();
        }

        public async Task MoveCart(MoveCartDto moveCartDto)
        {
            var cart = await _cartsRepository.GetEntity(moveCartDto.CartId);
            if (cart == null)
            {
                return;
            }
            var oldList = await _listsRepository.GetListWithCarts(cart.ListId);
            var newList = await _listsRepository.GetListWithCarts(moveCartDto.NewListId);

            cart = oldList.Carts.Single(x => x.Id == cart.Id);
            oldList.Carts.Remove(cart);

            this.NormalizeCartsPositionNumeration(oldList.Carts);

            newList.Carts.Add(cart);
            cart.Position = moveCartDto.NewPosition - 1;
            this.NormalizeCartsPositionNumeration(newList.Carts);

            await _cartsRepository.SaveChangesOnContext();
        }

        private void NormalizeCartsPositionNumeration(ICollection<Cart> carts)
        {
            var orderedCarts = carts.OrderBy(x => x.Position).ToList();
            for (int i = 0; i < orderedCarts.Count; i++)
            {
                orderedCarts[i].Position = i;
            }
        }
    }
}