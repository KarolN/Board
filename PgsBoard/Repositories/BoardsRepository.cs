using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using PgsBoard.Data.Entities;

namespace PgsBoard.Repositories
{
    public class BoardsRepository : Repository<Board, long>, IBoardsRepository

    {
        public BoardsRepository(DbContext context) : base(context)
        {
        }

        public async Task<List<Board>> GetUserBoards(string currentUserId)
        {
            var boards = await _context.Set<Board>().Where(x => x.OwnerId == currentUserId).ToListAsync();
            return boards;
        }

        public async Task<Board> GetBoardWithListsAndCarts(long selectedBoardId)
        {
            var board = await _context.Set<Board>()
                .Include(x => x.Lists)
                .Include(x => x.Lists.Select(l => l.Carts))
                .SingleOrDefaultAsync(x => x.Id == selectedBoardId);
            return board;
        }
    }
}