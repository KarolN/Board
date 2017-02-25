using System.Threading.Tasks;
using PgsBoard.Data.Entities;

namespace PgsBoard.Repositories
{
    public interface IListsRepository : IRepository<List, long>
    {
        Task<int> GetCountListsInBoard(long boardId);
        Task<List> GetListWithCarts(long cartListId);
    }
}