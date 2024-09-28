
using AndresAlarcon.TaskManager.Application.Repositories;
using AndresAlarcon.TaskManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AndresAlarcon.TaskManager.Infrastructure.Repositories.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<User, Guid> UserRepository { get; }

        #region Methods
        Task SaveChangesAsync();
        Task BeginTransactionAsync();
        Task CommitAsync();
        Task RollbackAsync();
        #endregion
    }
}
