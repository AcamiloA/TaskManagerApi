using AndresAlarcon.TaskManager.Application.Contracts;
using AndresAlarcon.TaskManager.Infrastructure.Data;
using AndresAlarcon.TaskManager.Infrastructure.Repositories.Contracts;
using Microsoft.EntityFrameworkCore.Storage;

namespace AndresAlarcon.TaskManager.Infrastructure.Repositories
{
    public class UnitOfWork(AppDbContext dbContext) : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;
        private IDbContextTransaction _transaction;

        public async void Dispose()
        {
            _transaction?.Dispose();

            if (_dbContext != null)
            {
                await _dbContext.DisposeAsync();
                GC.SuppressFinalize(this);
            }
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task BeginTransactionAsync()
        {
            _transaction = await _dbContext.Database.BeginTransactionAsync();
        }

        public async Task CommitAsync()
        {
            await _transaction.CommitAsync();
        }

        public async Task RollbackAsync()
        {
            await _transaction.RollbackAsync();
        }
    }
}
