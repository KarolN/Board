using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using PgsBoard.Data.Entities;

namespace PgsBoard.Repositories
{
    public class Repository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class, IEntity<TKey>
    {
        private readonly DbContext _context;

        public Repository(DbContext context)
        {
            _context = context;
        }

        private DbSet<TEntity> GetDbSet()
        {
            return _context.Set<TEntity>();
        }

        public async Task<TEntity> GetEntity(TKey id)
        {
            var set = GetDbSet();
            var entity = await set.SingleOrDefaultAsync(x => x.Id.Equals(id));
            return entity;
        }

        public TEntity Insert(TEntity entity)
        {
            var insertedEntity = GetDbSet().Add(entity);
            return insertedEntity;
        }

        public void Remove(TEntity entity)
        {
            GetDbSet().Remove(entity);
        }

        public void Update(TEntity entity)
        {
            GetDbSet().Attach(entity);
            var updated = _context.Entry(entity);
            updated.State = EntityState.Modified;
        }

        public async Task SaveChangesOnContext()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await GetDbSet().ToListAsync();
        }
    }
}