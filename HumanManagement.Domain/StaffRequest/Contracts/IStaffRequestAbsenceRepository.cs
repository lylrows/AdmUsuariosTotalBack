using HumanManagement.Domain.StaffRequest.Dto;
using System.Threading.Tasks;

namespace HumanManagement.Domain.StaffRequest.Contracts
{
    public interface IStaffRequestAbsenceRepository
    {
        Task<StaffRequestAbsenceDto> GetById(int id);
    }
}
