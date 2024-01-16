using HumanManagement.Domain.Common;
using HumanManagement.Domain.Contracts;
using HumanManagement.Domain.StaffRequest.Contracts;
using HumanManagement.Domain.StaffRequest.Dto;
using HumanManagement.Domain.StaffRequest.Models;
using HumanManagement.MsSql.Context;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Dapper;
using System.Data;
using System.Collections.Generic;

namespace HumanManagement.MsSql.Repository.StaffRequest
{
    public class TypeStaffRequestRepository : BaseRepository<TypeStaffRequest>, ITypeStaffRequestRepository
    {
        private readonly IHumanManagementReadDbConnection humanManagementReadDbConnection;
        public TypeStaffRequestRepository(IHumanManagementReadDbConnection humanManagementReadDbConnection,
                                          DbContextMsSql context) : base(context)
        {
            this.humanManagementReadDbConnection = humanManagementReadDbConnection;
        }
        public async Task<TypeStaffRequestDto> GetById(int id)
        {
            var result = await (from r in context.tb_type_staff_request
                               where r.Id == id
                               select new TypeStaffRequestDto
                               {
                                   Id = r.Id,
                                   Name = r.Name,
                                   Description = r.Description,
                                   Url = r.Url,
                                   Active = r.Active,
                                   CategoryId = r.CategoryId
                               }).SingleOrDefaultAsync();

            return result;
        }

        public async Task<ResultPaginationListDto<TypeStaffRequestListDto>> GetListPagination(TypeStaffRequestQueryFilter typeStaffRequestQueryFilter)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@sname", typeStaffRequestQueryFilter.Name);
            queryParameters.Add("@ncurrentpage", typeStaffRequestQueryFilter.Pagination.CurrentPage);
            queryParameters.Add("@nitemsperPage", typeStaffRequestQueryFilter.Pagination.ItemsPerPage);
            queryParameters.Add("@nrecordcount", DbType.Int32, direction: ParameterDirection.Output);

            var listContacts = await humanManagementReadDbConnection.QueryAsync<TypeStaffRequestListDto>(
                 "sps_type_staff_request_get_list_pagination",
                 queryParameters, commandType: CommandType.StoredProcedure);


            ResultPaginationListDto<TypeStaffRequestListDto> result = new ResultPaginationListDto<TypeStaffRequestListDto>();
            result.list = listContacts.ToList();

            result.TotalItems = Convert.ToInt32(queryParameters.Get<int>("@nrecordcount"));
            result.TotalPages = (int)Math.Ceiling((double)result.TotalItems / typeStaffRequestQueryFilter.Pagination.ItemsPerPage);

            return result;
        }
        public async Task<List<ResultForSelectDto>> GetForSelect()
        {
            var result = await (from r in context.tb_type_staff_request
                               where r.Active == true
                               select new ResultForSelectDto
                               {
                                   Id = r.Id,
                                   Description = r.Name
                               }).ToListAsync();

            return result;
        }
        public async Task<List<TypeStaffRequestForSelectDto>> GetOnlyEnabled()
        {
            var result = await (from r in context.tb_type_staff_request
                                where r.Active == true
                                select new TypeStaffRequestForSelectDto
                                {
                                    Id = r.Id,
                                    Name = r.Name,
                                    Url = r.Url
                                }).ToListAsync();

            return result;
        }
    }
}
