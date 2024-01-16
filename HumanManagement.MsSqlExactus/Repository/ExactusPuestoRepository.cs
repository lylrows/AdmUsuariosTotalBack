using Dapper;
using HumanManagement.Domain.Contracts;
using HumanManagement.Domain.WindowsService.Exactus.Contracts;
using HumanManagement.Domain.WindowsService.Exactus.Dto;
using HumanManagement.Domain.WindowsService.Exactus.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.MsSqlExactus.Repository
{
 

    public class ExactusPuestoRepository : IExactusPuestoRepository
    {
        private readonly IExactusReadDbConnection exactusReadDbConnection;
        public ExactusPuestoRepository(IExactusReadDbConnection exactusReadDbConnection)
        {
            this.exactusReadDbConnection = exactusReadDbConnection;
        }

        public async Task<List<ExactusPuesto>> GetAll(ExactusPuestoFilterDto filterDto)
        {
            string storename = $"[{filterDto.Scheme}].[EFITEC_LEERPUESTO]";

            var queryParameters = new DynamicParameters();

            var list = await exactusReadDbConnection.QueryAsync<ExactusPuesto>(
                 storename,queryParameters, commandType: CommandType.StoredProcedure);

            return list.ToList();
        }
    }
}
