using System.Data.Entity;
using System.Threading.Tasks;
using PgsBoard.Data.Entities;

namespace PgsBoard.Repositories
{
    public class CartsRepository : Repository<Cart, long>, ICartsRepository
    {
        public CartsRepository(DbContext context) : base(context)
        {
        }

        public async Task<int> GetCountCartsInList(long listId)
        {
            var count = await _context.Set<Cart>().CountAsync(x => x.ListId == listId);
            return count;
        }
    }
}