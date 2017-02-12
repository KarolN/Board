using System.Data.Entity;
using PgsBoard.Data.Entities;

namespace PgsBoard.Repositories
{
    public class BoardsRepository : Repository<Board, long>, IBoardsRepository

    {
        public BoardsRepository(DbContext context) : base(context)
        {
        }
    }
}