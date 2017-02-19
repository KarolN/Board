using System.Threading.Tasks;
using PgsBoard.Data.Entities;

namespace PgsBoard.Repositories
{
    public interface ICartsRepository : IRepository<Cart, long>
    {
        Task<int> GetCountCartsInList(long listId);
    }
}