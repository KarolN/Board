using System.Threading.Tasks;
using PgsBoard.Dtos;

namespace PgsBoard.Services
{
    public interface ICartsService
    {
        Task<long> CreateCart(CreateCartDto createCartDto);
        Task<bool> RemoveCart(long cartId);
        Task UpdateCartPosition(UpdateCartPositionDto updateCartPositionDto);
        Task MoveCart(MoveCartDto moveCartDto);
    }
}