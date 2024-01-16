using HumanManagement.Domain.StaffRequest.Dto;
using HumanManagement.Domain.StaffRequest.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HumanManagement.Domain.StaffRequest.Contracts
{
    public interface ITypeStaffRequestApproverRepository
    {
        Task<List<TypeStaffRequestApproverDto>> GetListById(int id);
        Task DeleteById(int id);
        Task<TypeStaffRequestApproverDto> GetByLevel(int id, int level);
        Task InsertLoanDetail(StaffRequestLoanDto payload, int id);
        Task<int> GetTotalLevels(int id);
        Task InsertLevelRequest (StaffRequestModel request);
        Task AproveLevelRequest(StaffRequestApprover request);
    }
}
