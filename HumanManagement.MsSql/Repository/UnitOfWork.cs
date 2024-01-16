using HumanManagement.Domain.Contracts;
using HumanManagement.MsSql.Context;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.MsSql.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HumanManagementDbContext dbContext;
        private bool disposed;
        public UnitOfWork(HumanManagementDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<int> Commit(CancellationToken cancellationToken)
        {
            return await dbContext.SaveChangesAsync(cancellationToken);
        }
        public async Task<int> Commit()
        {
            return await dbContext.SaveChangesAsync();
        }

        public Task Rollback()
        {
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    dbContext.Dispose();
                }
            }
            disposed = true;
        }
    }
}
