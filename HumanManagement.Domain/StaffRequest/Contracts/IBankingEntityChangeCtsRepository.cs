using HumanManagement.Domain.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HumanManagement.Domain.StaffRequest.Contracts
{
    public interface IBankingEntityChangeCtsRepository
    {
        Task<List<ResultForSelectDto>> GetForSelect();
    }
}
