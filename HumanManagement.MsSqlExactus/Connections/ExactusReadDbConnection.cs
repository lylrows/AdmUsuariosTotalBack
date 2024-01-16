using HumanManagement.Domain.Contracts;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using System.Threading;
using static Dapper.SqlMapper;

namespace HumanManagement.MsSqlExactus.Connections
{
    public class ExactusReadDbConnection : IExactusReadDbConnection, IDisposable
    {
        private readonly IDbConnection connection;

        public ExactusReadDbConnection(IConfiguration configuration)
        {
            connection = new SqlConnection(configuration.GetConnectionString("ConnectionStringExactusBd"));
        }
        public async Task<IReadOnlyList<T>> QueryAsync<T>(string sql, object param = null, CommandType CommandType = CommandType.Text, IDbTransaction transaction = null, CancellationToken cancellationToken = default)
        {
            return (await connection.QueryAsync<T>(sql, param, transaction, null, CommandType)).AsList();
        }
        public async Task<T> QueryFirstOrDefaultAsync<T>(string sql, object param = null, IDbTransaction transaction = null, CancellationToken cancellationToken = default)
        {
            return await connection.QueryFirstOrDefaultAsync<T>(sql, param, transaction);
        }
        public async Task<T> QuerySingleAsync<T>(string sql, object param = null, IDbTransaction transaction = null, CancellationToken cancellationToken = default)
        {
            return await connection.QuerySingleAsync<T>(sql, param, transaction);
        }

        public IDataReader ExecuteReader(string sql, object param = null, CommandType commandType = CommandType.Text, IDbTransaction transaction = null, CancellationToken cancellationToken = default)
        {
            return  connection.ExecuteReader(sql, param, transaction, null, commandType);
        }

        public GridReader QueryMultiple(string sql, object param = null, CommandType commandType = CommandType.Text, IDbTransaction transaction = null, CancellationToken cancellationToken = default)
        {
            return connection.QueryMultiple(sql, param, transaction, null, commandType);
        }

        public void Dispose()
        {
            connection.Dispose();
        }
    }
}
