using HumanManagement.Domain.General.Dto;
using System.Threading.Tasks;

namespace HumanManagement.Domain.General.Contracts
{
    public interface ICoreParameterRepository
    {
        Task<ParameterResultDto> GetValue(ParameterFilterDto parameterFilterDto);
    }
}
