using System.Threading.Tasks;
using PgsBoard.Data.Entities;
using PgsBoard.Dtos;
using PgsBoard.Infrastructure;
using PgsBoard.Repositories;

namespace PgsBoard.Services.Implementation
{
    public class ListsService : IListsService
    {
        private readonly IListsRepository _listsRepository;
        private readonly IBoardsRepository _boardsRepository;
        private readonly IAuthInfrastructure _authInfrastructure;

        public ListsService(IListsRepository listsRepository,
            IBoardsRepository boardsRepository,
            IAuthInfrastructure authInfrastructure)
        {
            _listsRepository = listsRepository;
            _boardsRepository = boardsRepository;
            _authInfrastructure = authInfrastructure;
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

        public async Task<bool> RemoveList(long listId)
        {
            var list = await _listsRepository.GetEntity(listId);
            if (list == null)
            {
                return false;
            }
            var board = await _boardsRepository.GetEntity(list.BoardId);
            var currentUserId = _authInfrastructure.GetCurrentUserId();
            if (currentUserId != board.OwnerId)
            {
                return false;
            }

            _listsRepository.Remove(list);
            await _listsRepository.SaveChangesOnContext();
            return true;
        }
    }
}