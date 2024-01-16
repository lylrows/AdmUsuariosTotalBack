using HumanManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HumanManagement.Domain.Recruitment.Dto;
using HumanManagement.Domain.Recruitment.QueryFilter;

namespace HumanManagement.Domain.Recruitment.Contracts
{
    public interface IRequestRepository
    {
        Task<ResultPaginationListDto<ListRequestDto>> GetListRequestPagination(RequestQueryFilter contactQueryFilter);
        Task<RequestById> GetRequestById(int id);
        Task<int> AddRequest(RequestDto requestQueryFilter);
        Task<EmployeeChargeDto> GetEmployeeChargeByUser(int idUser);
        Task<IEnumerable<ListRequestFlowDto>> GetRequestFlow(int idRequest);
        Task<int> AddRequestFlow(RequestFlowDto requestQueryFilter);
        Task<int> UpdateRequest(RequestUpdatedDto requestQueryFilter);
        Task<int> UpdateRequestPre(RequestDto requestQueryFilter);

    }
}
