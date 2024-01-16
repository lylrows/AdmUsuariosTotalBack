using HumanManagement.Domain.StaffRequest.Dto;
using System.Threading.Tasks;

namespace HumanManagement.Domain.StaffRequest.Contracts
{
    public interface IStaffRequestPermitRepository
    {
        Task<StaffRequestPermitDto> GetById(int id);
    }
}
