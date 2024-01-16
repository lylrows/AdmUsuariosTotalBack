using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Domain.Contracts
{
    public interface IHumanManagementWriteDbConnection
    {
        Task<int> ExecuteAsync(string sql, object param = null, IDbTransaction transaction = null, CancellationToken cancellationToken = default);

    }
}
