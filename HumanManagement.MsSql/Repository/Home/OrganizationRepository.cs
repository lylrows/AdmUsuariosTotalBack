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
    public class OrganizationRepository : IOrganizationRepository
    {
        private readonly DbContextMsSql context;
        private readonly IHumanManagementReadDbConnection humanManagementReadDbConnection;

        public OrganizationRepository(DbContextMsSql context, IHumanManagementReadDbConnection humanManagementReadDbConnection)
        {
            this.context = context;
            this.humanManagementReadDbConnection = humanManagementReadDbConnection;
        }
        public async Task<ResultPaginationListDto<OrganizationDto>> GetListOrganizationPagination(OrganizationQueryFilter contactQueryFilter)
        {
            var queryParameters = new DynamicParameters();
            
            queryParameters.Add("@sdescription", contactQueryFilter.Description);
            queryParameters.Add("@ncurrentpage", contactQueryFilter.Pagination.CurrentPage);
            queryParameters.Add("@nitemsperPage", contactQueryFilter.Pagination.ItemsPerPage);
            queryParameters.Add("@nrecordcount", DbType.Int32, direction: ParameterDirection.Output);

            var listContacts = await humanManagementReadDbConnection.QueryAsync<OrganizationDto>(
                 "sps_home_organization_pagination",
                 queryParameters, commandType: CommandType.StoredProcedure);


            ResultPaginationListDto<OrganizationDto> result = new ResultPaginationListDto<OrganizationDto>();
            result.list = listContacts.ToList();

            result.TotalItems = Convert.ToInt32(queryParameters.Get<int>("@nrecordcount"));
            result.TotalPages = (int)Math.Ceiling((double)result.TotalItems / contactQueryFilter.Pagination.ItemsPerPage);

            return result;
        }
    }
}
