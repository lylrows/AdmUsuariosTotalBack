using HumanManagement.Domain.StaffRequest.Dto;
using System.Threading.Tasks;

namespace HumanManagement.Domain.StaffRequest.Contracts
{
    public interface IStaffRequestVacationRepository
    {
        Task<StaffRequestVacationDto> GetById(int id);
    }
}
