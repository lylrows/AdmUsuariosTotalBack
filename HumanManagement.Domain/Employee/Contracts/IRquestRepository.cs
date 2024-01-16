using HumanManagement.Domain.Common;
using HumanManagement.Domain.Employee.Dto;
using HumanManagement.Domain.Security.QueryFilter;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.Employee.Contracts
{
    public interface IRquestRepository
    {
        Task<int> InsertRequestEmployee(RequestInsDto request, IFormFile file);
        Task AcceptRequest(AcceptRequest request);
        Task RejectRequest(RejectRequest request);
        Task<List<ListRequestDto>> ListRequest(RequestFilterDto entity);
        Task<RequestDetailDto> RequestDetail(int id);
        Task<List<GetPersonByRolAdminPersnDto>> GetPersonByAdminPerson();
        Task<ResultPaginationListDto<ListRequestDto>> ListRequestPagination(EmployeeQueryFilter employeeQueryFilter);
        Task<int> InsertRequestDocument(InsertRequestDocumentDto payload);
        Task<ResultPaginationListDto<ListRequestDto>> ListRequestByUser(EmployeeQueryFilter employeeQueryFilter);

        Task<RequestDto> RequestById(int id);


    }
}
