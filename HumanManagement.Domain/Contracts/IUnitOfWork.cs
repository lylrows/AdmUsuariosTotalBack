using System;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Domain.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> Commit(CancellationToken cancellationToken);
        Task<int> Commit();
        Task Rollback();
    }
}
