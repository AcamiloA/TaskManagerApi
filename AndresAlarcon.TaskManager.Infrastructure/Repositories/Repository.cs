using AndresAlarcon.TaskManager.Application.Repositories;
using AndresAlarcon.TaskManager.Domain.Entities.BaseEntity;
using AndresAlarcon.TaskManager.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AndresAlarcon.TaskManager.Infrastructure.Repositories
{
    public class Repository<T, TKey>(AppDbContext dbContext) : IRepository<T, TKey> where T : BaseEntity<TKey>
    {
        private readonly AppDbContext _dbContext = dbContext;
        private readonly DbSet<T> _entities = dbContext.Set<T>();

        public async Task<TKey> Add(T entity)
        {
            await _entities.AddAsync(entity);
            return entity.Id;
        }

        public async Task<bool> Any(Expression<Func<T, bool>> where)
        {
            var query = _dbContext.Set<T>().AnyAsync(where);

            return await query;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _entities.ToListAsync();
        }

        public async Task<T> GetById(TKey id)
        {
            return await _entities.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();
        }

        public async Task<T> GetByWhere(Expression<Func<T, bool>> where)
        {
            return await _dbContext.Set<T>().Where(where).FirstOrDefaultAsync();
        }

        public async Task<List<T>> GetListByWhere(Expression<Func<T, bool>> where)
        {
            var query = _dbContext.Set<T>().Where(where);

            return await query.ToListAsync();
        }

        public void Remove(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            _entities.Update(entity);
        }
    }
}
