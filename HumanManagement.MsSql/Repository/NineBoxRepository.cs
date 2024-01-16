using Dapper;
using HumanManagement.Domain.Contracts;
using HumanManagement.Domain.NineBox.Contracts;
using HumanManagement.Domain.NineBox.Dto;
using HumanManagement.MsSql.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Data;
using HumanManagement.Domain.NineBox.QueryFilter;
using HumanManagement.Domain.Common;

namespace HumanManagement.MsSql.Repository
{
    public class NineBoxRepository: INineBoxRepository
    {
        private readonly DbContextMsSql context;
        private readonly IHumanManagementReadDbConnection humanManagementReadDbConnection;

        public NineBoxRepository(DbContextMsSql context, IHumanManagementReadDbConnection humanManagementReadDbConnection)
        {
            this.context = context;
            this.humanManagementReadDbConnection = humanManagementReadDbConnection;
        }
        public async Task<ResultPaginationListDto<ListNineBoxDto>> GetListNineBox(NineBoxQueryFilter filter)
        {
            var queryParameters = new DynamicParameters();

            queryParameters.Add("@ncurrentpage", filter.Pagination.CurrentPage);
            queryParameters.Add("@nitemsperPage", filter.Pagination.ItemsPerPage);
            queryParameters.Add("@nrecordcount", DbType.Int32, direction: ParameterDirection.Output);

            var listNineBox = await humanManagementReadDbConnection.QueryAsync<ListNineBoxDto>(
                 "campaign.sps_get_list_ninebox",
                 queryParameters, commandType: CommandType.StoredProcedure);


            ResultPaginationListDto<ListNineBoxDto> result = new ResultPaginationListDto<ListNineBoxDto>();
            result.list = listNineBox.ToList();

            result.TotalItems = Convert.ToInt32(queryParameters.Get<int>("@nrecordcount"));
            result.TotalPages = (int)Math.Ceiling((double)result.TotalItems / filter.Pagination.ItemsPerPage);

            return result;
        }

        public async Task<int> EditConfigNineBox(NineBoxDto dto)
        {
            try
            {
                var queryParameters = new DynamicParameters();

                queryParameters.Add("@nid_config", dto.Id);
                queryParameters.Add("@nid_group", dto.IdGroup);
                queryParameters.Add("@snamegroup", dto.NameGroup);
                queryParameters.Add("@scode_config", dto.CodeConfig);
                queryParameters.Add("@sdescription", dto.Description);
                queryParameters.Add("@nmin_level", dto.MinLevel);
                queryParameters.Add("@nmax_level", dto.MaxLevel);
                queryParameters.Add("@bactive", dto.Active);
                queryParameters.Add("@nresult", DbType.Int32, direction: ParameterDirection.Output);
               
                var queryresult = await humanManagementReadDbConnection.QueryAsync<int>(
                     "campaign.spu_update_config_ninebox",
                     queryParameters, commandType: CommandType.StoredProcedure);
               
                int res= Convert.ToInt32(queryParameters.Get<int>("@nresult"));

            }
            catch (Exception ex)
            {
                var resultado = ex;
            }
            return 1;
        }

    }
}
