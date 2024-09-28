using AndresAlarcon.TaskManager.Domain.Entities.BaseEntity;
using System.Linq.Expressions;

namespace AndresAlarcon.TaskManager.Application.Repositories
{
    public interface IRepository<T, TKey> where T : BaseEntity<TKey>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(TKey id);
        Task<TKey> Add(T entity);
        void Update(T entity);
        Task<List<T>> GetListByWhere(Expression<Func<T, bool>> where);
        Task<T> GetByWhere(Expression<Func<T, bool>> where);
        Task<bool> Any(Expression<Func<T, bool>> where);
        void Remove(T entity);
    }
}
