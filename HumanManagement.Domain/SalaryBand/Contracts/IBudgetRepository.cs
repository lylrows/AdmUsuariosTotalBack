using HumanManagement.Domain.SalaryBand.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.SalaryBand.Contracts
{
    public interface IBudgetRepository
    {
        Task<List<BudgetListDto>> GetBudgetList(BudgetFilterDto filter);
    }
}
