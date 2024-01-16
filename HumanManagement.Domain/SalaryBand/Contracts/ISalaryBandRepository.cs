using HumanManagement.Domain.BaseDto;
using HumanManagement.Domain.Common;
using HumanManagement.Domain.SalaryBand.Dto;
using HumanManagement.Domain.SalaryBand.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.SalaryBand.Contracts
{
    public interface ISalaryBandRepository
    {
        Task<ResultPaginationListDto<SalaryBandListDto>> GetBandBoxPagination(SalaryBandQueryFilter contactQueryFilter);
        Task<List<DropDownListDto<int>>> ListGroupCombo();
        Task<List<ListGroupDto>> GetListGroupSalary();
        Task<List<DropDownListString>> GetListAreaGroupCenterCost(int nid_areagroup);
        Task<List<DropDownListString>> GetListAreaCCByGerencia(int nid_gerencia);
        Task<Domain.SalaryBand.Models.SalaryBand> FindSalaryBandByGroupActive(int nIdGroup);
        Task<List<EcoConditionListDto>> GetEcoConditionList(EcoConditionFilter filter);
        Task<Domain.SalaryBand.Models.SalaryBand> FindSalaryBandById(int id);
        Task<List<SalaryPayrollDet>> GetSalaryPayrollDets(string snomina, int nnumeronomina, int nidcompany);
        Task<int> RegisterNominaDetail(SalaryPayrollDet salaryPayrollDet);
        Task<List<LiquidacionCabDto>> GetLiquidacionCabList(int nid_company);
        Task<int> RegisterLiquidacionCab(LiquidacionCabDto dto);
        Task<int> RegisterLiquidacionDet(LiquidacionDetDto dto);
        Task<int> RegisterNominaCab(SalaryPayrollCab salaryPayrollcab);
    }
}
