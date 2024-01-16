using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace HumanManagement.Domain.Contracts
{
  
    public interface IExactusReadDbConnection
    {
        Task<IReadOnlyList<T>> QueryAsync<T>(string sql, object param = null, CommandType commandType = CommandType.Text, IDbTransaction transaction = null, CancellationToken cancellationToken = default);
        Task<T> QueryFirstOrDefaultAsync<T>(string sql, object param = null, IDbTransaction transaction = null, CancellationToken cancellationToken = default);
        Task<T> QuerySingleAsync<T>(string sql, object param = null, IDbTransaction transaction = null, CancellationToken cancellationToken = default);
        IDataReader ExecuteReader(string sql, object param = null, CommandType commandType = CommandType.Text, IDbTransaction transaction = null, CancellationToken cancellationToken = default);
        GridReader QueryMultiple(string sql, object param = null, CommandType commandType = CommandType.Text, IDbTransaction transaction = null, CancellationToken cancellationToken = default);
    }
}
