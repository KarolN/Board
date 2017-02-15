using System.Collections.Generic;
using System.Threading.Tasks;
using PgsBoard.Data.Entities;

namespace PgsBoard.Repositories
{
    public interface IBoardsRepository : IRepository<Board, long>
    {
        Task<List<Board>> GetUserBoards(string currentUserId);
    }
}