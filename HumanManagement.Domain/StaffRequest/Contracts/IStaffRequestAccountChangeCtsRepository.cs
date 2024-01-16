using HumanManagement.Domain.StaffRequest.Dto;
using System.Threading.Tasks;

namespace HumanManagement.Domain.StaffRequest.Contracts
{
    public interface IStaffRequestAccountChangeCtsRepository
    {
        Task<StaffRequestAccountChangeDto> GetById(int id);
    }
}
