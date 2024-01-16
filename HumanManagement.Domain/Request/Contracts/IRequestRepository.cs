using HumanManagement.Domain.Common;
using HumanManagement.Domain.Recruitment.Dto;
using HumanManagement.Domain.Recruitment.QueryFilter;
using System.Threading.Tasks;

namespace HumanManagement.Domain.Request.Contracts
{
    public interface IRequestRepository
    {
        Task<ResultPaginationListDto<RequestDto>> GetAll(RequestQueryFilter contactQueryFilter);
    }
}
