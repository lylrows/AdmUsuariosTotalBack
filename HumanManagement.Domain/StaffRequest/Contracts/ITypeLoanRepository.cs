using HumanManagement.Domain.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HumanManagement.Domain.StaffRequest.Contracts
{
    public interface ITypeLoanRepository
    {
        Task<List<ResultForSelectDto>> GetForSelect();
    }
}
