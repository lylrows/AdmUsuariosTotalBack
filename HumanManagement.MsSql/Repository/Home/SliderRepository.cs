using HumanManagement.Domain.Home.Contracts;
using HumanManagement.Domain.Home.Dto;
using HumanManagement.MsSql.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using HumanManagement.Domain.Home.QueryFilter;
using HumanManagement.Domain.Contracts;
using HumanManagement.Domain.Common;
using Dapper;
using System.Data;

namespace HumanManagement.MsSql.Repository.Home
{
    public class SliderRepository : ISliderRepository
    {
        private readonly DbContextMsSql context;
        private readonly IHumanManagementReadDbConnection humanManagementReadDbConnection;

        public SliderRepository(DbContextMsSql context, IHumanManagementReadDbConnection humanManagementReadDbConnection)
        {
            this.context = context;
            this.humanManagementReadDbConnection = humanManagementReadDbConnection;
        }
        public async Task<ResultPaginationListDto<SliderDto>> GetListSliderPagination(SliderQueryFilter contactQueryFilter)
        {
            var queryParameters = new DynamicParameters();

            queryParameters.Add("@nid_type", contactQueryFilter.IdType);
            queryParameters.Add("@ncurrentpage", contactQueryFilter.Pagination.CurrentPage);
            queryParameters.Add("@nitemsperPage", contactQueryFilter.Pagination.ItemsPerPage);
            queryParameters.Add("@nrecordcount", DbType.Int32, direction: ParameterDirection.Output);

            var listContacts = await humanManagementReadDbConnection.QueryAsync<SliderDto>(
                 "sps_home_slider_pagination",
                 queryParameters, commandType: CommandType.StoredProcedure);


            ResultPaginationListDto<SliderDto> result = new ResultPaginationListDto<SliderDto>();
            result.list = listContacts.ToList();

            result.TotalItems = Convert.ToInt32(queryParameters.Get<int>("@nrecordcount"));
            result.TotalPages = (int)Math.Ceiling((double)result.TotalItems / contactQueryFilter.Pagination.ItemsPerPage);

            return result;
        }
    }
}
