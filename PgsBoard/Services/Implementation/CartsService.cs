using System.Threading.Tasks;
using PgsBoard.Data.Entities;
using PgsBoard.Dtos;
using PgsBoard.Repositories;

namespace PgsBoard.Services.Implementation
{
    public class CartsService : ICartsService
    {
        private readonly ICartsRepository _cartsRepository;
        private readonly IListsRepository _listsRepository;

        public CartsService(ICartsRepository cartsRepository, IListsRepository listsRepository)
        {
            _cartsRepository = cartsRepository;
            _listsRepository = listsRepository;
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
    }
}