using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using PgsBoard.Data.Entities;

namespace PgsBoard.Repositories
{
    public class ListsRepository : Repository<List, long>, IListsRepository
    {
        public ListsRepository(DbContext context) : base(context)
        {
        }

        public async Task<int> GetCountListsInBoard(long boardId)
        {
            var count = await _context.Set<List>().CountAsync(x => x.BoardId == boardId);
            return count;
        }

        public async Task<List> GetListWithCarts(long cartListId)
        {
            var list = await _context.Set<List>().Include(x => x.Carts).SingleAsync(x => x.Id == cartListId);
            return list;
        }
    }
}