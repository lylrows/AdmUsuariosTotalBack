using HumanManagement.Domain.Campaign.Dto;
using HumanManagement.Domain.Campaign.Models;
using HumanManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.Campaign.Contracts
{
    public interface ICampaignRepository
    {
        Task<ResultPaginationListDto<CampaignListDto>> GetListUsersPagination(CampaignQueryFilterDto filter);
        Task<CampaignCountDto> GetCampaignCount(int IdCampaign);
        Task<ResultPaginationListDto<EmployeeByCampaignListDto>> GetEmployeeByCampaign(EmployeeByCampaignFilterDto filter);
        Task<CampaignEmployee> FindCampaignEmployee(int nIdCampaign, int nIdEmployee);
        Task<CampaignDto> FindCampaignById(int nIdCampaign);
        Task<List<ProficiencyByChargeListDto>> GetProficiencyByCharge(ProficiencyByChargeFilterDto filter);
        Task<ProficiencyCharge> FindProficiencyCharge(int nIdCampaign, int nIdcharge, int nIdProficiency);
        Task<int> GenerateEvaluations(int nIdCampaign);
        Task<ResultPaginationListDto<EvaluationListDto>> GetListEvaluationsPagination(EvaluationQueryFilterDto filter);
        Task<ResultPaginationListDto<EvaluationListDto>> GetListEvaluationsPaginationDeleted(EvaluationQueryFilterDto filter);
        Task<List<EvaluationListDto>> GetMyEvaluation(MyEvaluationFilter filter);
        Task<ResultPaginationListDto<EvaluationListDto>> GetMyEvaluation_Paginated(MyEvaluationFilter filter);
        Task<int> LaunchEvaluations(int nIdCampaign);
        Task<List<ProficiencyCharge>> ListProficienciesByCampaign(int nIdCampaign);
        Task<List<GetCampaingBorrador>> ListCampaingBorrador(int nidemployee);
        Task<LastCampaignByEmployee> LastCampaignByEmployee(int nidemployee);
        Task<List<ProficienciesByCampaignDto>> ListProficienciesByCampaignDto(int nIdCampaign);
        Task<List<NineBoxSPDto>> GetNineBox(NineBoxFilterDto filter);
        Task<ResultPaginationListDto<EvaluationListDto>> GetMyTeamEvaluation_Paginated(MyEvaluationFilter filter);
        Task<List<CampaingEvaluationListDto>> GetCampaingEvaluationAlert(int nidemployee);
        Task<List<CampaingByUserMyEvaluationDto>> GetCampaingByUserMyEvaluation(CampaingByUserMyEvaluationFilter filter);
        Task<List<CompanyByCampaingUserMyEvaluationDto>> GetCompanyByCampaingUserMyEvaluation(CompanyByCampaingUserMyEvaluationFilter filter);
        Task<List<GerenciasByCampaingUserMyEvaluationDto>> GetGerenciasByCampaingUserMyEvaluation(GerenciasByCampaingUserMyEvaluationFilter filter);
        Task<List<AreasByCampaingUserMyEvaluationDto>> GetAreasByCampaingUserMyEvaluation(AreasByCampaingUserMyEvaluationFilter filter);
        Task<List<SubAreasByCampaingUserMyEvaluationDto>> GetSubAreasByCampaingUserMyEvaluation(SubAreasByCampaingUserMyEvaluationFilter filter);
        Task<List<CollaboratorsByCampaingUserMyEvaluationDto>> GetCollaboratosByCampaingUserMyEvaluation(CollaboratorsByCampaingUserMyEvaluationFilter filter);
        Task<List<CampaingByEvaluationDto>> GetCampaingByEvaluation();

        Task<int> RegisterDetailCampaingLevelNineBox(int nIdCampaign);
        Task<List<ConfigLevelNineBoxDto>> GetConfigLevelNineBox();
        Task<List<ConfigLevelNineBoxDto>> GetConfigDetailLevelNineBoxByCampaign(ConfigDetailLevelNineBoxFilter filter);

        Task<List<CampaignProgressDto>> GetCampaignProgress(CampaignProgressFilterDto filter);
        Task<List<MyTeamResumeDto>> GetMyTeamResume(MyTeamResumeFilterDto filter);
        Task<List<MyTeamResumeCompDto>> GetMyTeamResumeComp(MyTeamResumeFilterDto filter);
        Task<List<MyTeamResumeObjDto>> GetMyTeamResumeObj(MyTeamResumeFilterDto filter);
        Task<List<CampaingByEvaluationDto>> GetCampaingByUser(CampaingByUserFilter filter);

        Task<List<MyTeamResumeListDto>> GetMyTeamResumeList(MyTeamResumeFilterDto filter);
        Task<List<ResumenEvaluationDto>> GetNineBoxCopy(MyTeamResultadoFilterDto filter);
    }
}
