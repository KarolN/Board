using System.Collections.Generic;
using System.Threading.Tasks;
using PgsBoard.Data.Entities;

namespace PgsBoard.Repositories
{
    public interface IRepository<TEntity, TKey> where TEntity : IEntity<TKey>
    {
        Task<TEntity> GetEntity(TKey id);

        TEntity Insert(TEntity entity);

        void Remove(TEntity entity);

        void Update(TEntity entity);

        Task SaveChangesOnContext();

        Task<List<TEntity>> GetAll();
    }
}