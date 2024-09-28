using AndresAlarcon.TaskManager.Application.Repositories;
using AndresAlarcon.TaskManager.Domain.Entities;
using AndresAlarcon.TaskManager.Infrastructure.Data;
using AndresAlarcon.TaskManager.Infrastructure.Repositories.Contracts;
using Microsoft.EntityFrameworkCore.Storage;

namespace AndresAlarcon.TaskManager.Infrastructure.Repositories
{
    public class UnitOfWork(AppDbContext dbContext) : IUnitOfWork
    {
        private readonly AppDbContext _dbContext = dbContext;
        private IDbContextTransaction _transaction;


        public IRepository<User, Guid> UserRepository => new Repository<User, Guid>(_dbContext);
        public IRepository<Board, int> BoardRepository => new Repository<Board, int>(_dbContext);

        #region Methods        

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

        #endregion
    }
}
