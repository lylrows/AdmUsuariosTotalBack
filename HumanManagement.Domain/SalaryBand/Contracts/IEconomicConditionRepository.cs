using HumanManagement.Domain.SalaryBand.Dto;
using HumanManagement.Domain.SalaryBand.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.SalaryBand.Contracts
{
    public interface IEconomicConditionRepository
    {
        Task<EconomicCondition> FindById(int id);
        Task<List<SalaryStructureList>> GetSalaryStructure(SalaryStructureFilter filter);
    }
}
