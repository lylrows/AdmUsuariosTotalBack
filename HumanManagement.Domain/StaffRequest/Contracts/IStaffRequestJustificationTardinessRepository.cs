using HumanManagement.Domain.StaffRequest.Dto;
using System.Threading.Tasks;

namespace HumanManagement.Domain.StaffRequest.Contracts
{
    public interface IStaffRequestJustificationTardinessRepository
    {
        Task<StaffRequestJustificationTardinessDto> GetById(int id);
    }
}
