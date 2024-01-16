using HumanManagement.Domain.Common;
using HumanManagement.Domain.StaffRequest.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HumanManagement.Domain.StaffRequest.Contracts
{
    public interface ITypeStaffRequestRepository
    {
        Task<ResultPaginationListDto<TypeStaffRequestListDto>> GetListPagination(TypeStaffRequestQueryFilter typeStaffRequestQueryFilter);
        Task<TypeStaffRequestDto> GetById(int id);
        Task<List<ResultForSelectDto>> GetForSelect();
        Task<List<TypeStaffRequestForSelectDto>> GetOnlyEnabled();
    }
}
