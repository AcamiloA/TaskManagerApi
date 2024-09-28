
namespace AndresAlarcon.TaskManager.Infrastructure.Repositories.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        #region Methods
        Task SaveChangesAsync();
        Task BeginTransactionAsync();
        Task CommitAsync();
        Task RollbackAsync();
        #endregion
    }
}
