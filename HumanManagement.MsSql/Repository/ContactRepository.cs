using Dapper;
using HumanManagement.Domain.Common;
using HumanManagement.Domain.Contact.Contracts;
using HumanManagement.Domain.Contact.Dto;
using HumanManagement.Domain.Contact.Models;
using HumanManagement.Domain.Contact.QueryFilter;
using HumanManagement.Domain.Contracts;
using HumanManagement.MsSql.Context;
using System;

using System.Data;
using System.Linq;

using System.Threading.Tasks;

namespace HumanManagement.MsSql.Repository
{
    public class ContactRepository : BaseRepository<Contact>, IContactRepository
    {
        private readonly IHumanManagementReadDbConnection humanManagementReadDbConnection;
        public ContactRepository(IHumanManagementReadDbConnection humanManagementReadDbConnection,
                              DbContextMsSql context)
            : base(context)
        {
            this.humanManagementReadDbConnection = humanManagementReadDbConnection;
        }

        public  async Task<ResultPaginationListDto<ContactListDto>> GetListUsersPagination(ContactQueryFilter contactQueryFilter)
        {
            var queryParameters = new DynamicParameters();
            
            queryParameters.Add("@ncurrentpage", contactQueryFilter.Pagination.CurrentPage);
            queryParameters.Add("@nitemsperPage", contactQueryFilter.Pagination.ItemsPerPage);
            
            queryParameters.Add("@nrecordcount", DbType.Int32, direction: ParameterDirection.Output);

            var listContacts = await humanManagementReadDbConnection.QueryAsync<ContactListDto>(
                 "sps_contacts_pagination",
                 queryParameters, commandType: CommandType.StoredProcedure);


            ResultPaginationListDto<ContactListDto> result = new ResultPaginationListDto<ContactListDto>();
            result.list = listContacts.ToList();
            
            result.TotalItems = Convert.ToInt32(queryParameters.Get<int>("@nrecordcount"));
            result.TotalPages = (int)Math.Ceiling((double)result.TotalItems / contactQueryFilter.Pagination.ItemsPerPage);

            return result;
        }
    }
}
