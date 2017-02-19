using System.Threading.Tasks;
using PgsBoard.Data.Entities;
using PgsBoard.Dtos;
using PgsBoard.Repositories;

namespace PgsBoard.Services.Implementation
{
    public class ListsService : IListsService
    {
        private readonly IListsRepository _listsRepository;
        private readonly IBoardsRepository _boardsRepository;

        public ListsService(IListsRepository listsRepository, IBoardsRepository boardsRepository)
        {
            _listsRepository = listsRepository;
            _boardsRepository = boardsRepository;
        }

        public async Task<long?> CreateNewList(CreateListDto createListDto)
        {
            var count = await _listsRepository.GetCountListsInBoard(createListDto.BoardId);

            var list = new List()
            {
                Name = createListDto.Name,
                BoardId = createListDto.BoardId,
                Position = count
            };
            _listsRepository.Insert(list);
            await _listsRepository.SaveChangesOnContext();

            return createListDto.BoardId;
        }
    }
}