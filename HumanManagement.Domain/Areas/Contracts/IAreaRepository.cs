using HumanManagement.Domain.Areas.Dto;
using HumanManagement.Domain.Areas.QueryFilter;
using HumanManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.Areas.Contracts
{
    public interface IAreaRepository
    {
        Task<ResultPaginationListDto<AreasDto>> GetAll(AreasQueryFilter contactQueryFilter);
        Task<List<AreasDto>> GetAreasAll();
        Task<List<AreasDto>> GetByEmpresa(int idEmpresa);
        Task<List<AreasDto>> GetManagementByCompany(int idEmpresa);
        Task<List<AreasDto>> GetAreaByManagement(int idManagement);
        Task<int> GetByIdUser(int idUser);
        Task<List<AreasDto>> GetSubAreaByIdArea(int idArea);
        Task<AreasByUserDto> GetAreaByIdUser(int idUser);

        Task<List<AreasComboDto>> GetGerenciasByUser(AreasComboQueryFilter filter);
        
        Task<List<AreasComboDto>> GetSubAreasByArea(SubAreasComboQueryFilter filter);
        Task<List<AreasComboDto>> GetSubAreasByAreaMultiple(string AreasIds);
        Task<List<CompanyComboDto>> GetCompanyByUser(CompanyComboQueryFilter filter);
        Task<List<AreasComboDto>> GetGerenciasByUserEvaluation(AreasComboQueryFilter filter);
        Task<List<AreasComboDto>> GetAreasByGerenciaEvaluation(AreasEvaluationComboQueryFilter filter);
        Task<List<AreasComboDto>> GetSubAreasByAreaEvaluation(SubAreasEvaluationComboQueryFilter filter);
        Task<List<AreasComboDto>> GetGerenciasByCompany(GerenciasComboQueryFilter filter);
        Task<List<JefesByAreaDto>> GetJefesByArea(JefesQueryFilter filter);
        


    }
}
