using HumanManagement.Application.Campaign.Commands.Create;
using HumanManagement.Application.Campaign.Queries;
using HumanManagement.Application.Evaluation.Queries;
using HumanManagement.Domain.Campaign.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagementApi.Controllers.Campaign
{
    public class CampaignController : BaseApiController
    {

        public CampaignController()
        {
        }


        [HttpPost("getlistpagination")]
        public async Task<IActionResult> GetListPagination([FromBody] CampaignQueryFilterDto dto)
        {
            
            var listUser = await mediator.Send(new GetListCampaignPaginationQuery() { campaignQueryFilter= dto });

            return Ok(listUser);
        }
        [HttpGet("getdropdownlist")]
        public async Task<IActionResult> GetDropDownList()
        {

            var dropdownlist = await mediator.Send(new GetListCampaignComboQuery() { });

            return Ok(dropdownlist);
            
        }

        [HttpGet("getcampaingborrador/{id}")]
        public async Task<IActionResult> GetCampaignBorrador(int id)
        {

            var dropdownlist = await mediator.Send(new GetCampaingBorradorQuery() { IdEmployee = id });

            return Ok(dropdownlist);

        }


        [HttpPost("getemployeebycampaign")]
        public async Task<IActionResult> GetEmployeeByCampaign([FromBody] EmployeeByCampaignFilterDto dto)
        {

            var listUser = await mediator.Send(new GetEmployeeByCampaignQuery() { campaignQueryFilter = dto });

            return Ok(listUser);
        }

        [HttpPost("assignemployees")]
        public async Task<IActionResult> AssignEmployees([FromBody] AssignEmployeeDto dto)
        {

            var listUser = await mediator.Send(new AssingEmployeeCommand() { IdUsuario=1 , assignEmployee = dto });

            return Ok(listUser);
        }

        [HttpGet("getcampaignbyid/{id}")]
        public async Task<IActionResult> GetCampaignById(int id)
        {

            var campaign = await mediator.Send(new GetCampaignQuery() { IdCampaing= id });

            return Ok(campaign);
        }
        [HttpPost("getproficiencybycharge")]
        public async Task<IActionResult> GetEmployeeByCampaign([FromBody] ProficiencyByChargeFilterDto dto)
        {

            var listUser = await mediator.Send(new GetListProficiencyByChargeQuery() {proficiencyQueryFilter= dto });

            return Ok(listUser);
        }

        [HttpPost("assignproficiencies")]
        public async Task<IActionResult> AssignProficiencies([FromBody] AssignProficiencyDto dto)
        {   

            var listUser = await mediator.Send(new AssignProficiencyCommand() { IdUsuario = 1, assignProficiency = dto });

            return Ok(listUser);
        }


        [HttpPost("savecampaign")]
        public async Task<IActionResult> SaveCampaign([FromBody] SaveCampaignDto dto)
        {

            var listUser = await mediator.Send(new SaveCampaignCommand() { IdUsuario = 1, saveCampaign= dto });

            return Ok(listUser);
        }

        [HttpPost("generateevaluations")]
        public async Task<IActionResult> GenerateEvaluations([FromBody] GenerateEvaluationsInputDto dto)
        {

            var listUser = await mediator.Send(new GenerateEvaluationsCommand() { IdCampaign = dto.nIdCampaign, nIdPerson = dto.nIdPerson });

            return Ok(listUser);
        }

        [HttpPost("resetT0campaign")]
        public async Task<IActionResult> ResetT0Campaign([FromBody] GenerateEvaluationsInputDto dto)
        {

            var listUser = await mediator.Send(new ReinitCampaignCommand() { IdCampaign = dto.nIdCampaign });

            return Ok(listUser);
        }

        [HttpPost("resetT1campaign")]
        public async Task<IActionResult> ResetT1Campaign([FromBody] GenerateEvaluationsInputDto dto)
        {

            var listUser = await mediator.Send(new RsetT1CampaignCommand() { IdCampaign = dto.nIdCampaign });

            return Ok(listUser);
        }
         
        [HttpPost("getevaluationpaginationlist")]
        public async Task<IActionResult> GetEvaluationPaginationList([FromBody] EvaluationQueryFilterDto dto)
        {

            var listUser = await mediator.Send(new GetListEvaluationPaginationQuery() { evaluationQueryFilter= dto });

            return Ok(listUser);
        }

        [HttpPost("myevaluationslist")]
        public async Task<IActionResult> MyEvaluations([FromBody] MyEvaluationFilter dto)
        {
            var listUser = await mediator.Send(new GetMyEvaluationQuery() { evaluationQueryFilter  = dto });

            return Ok(listUser);
        }
        [HttpPost("myteamevaluationslist")]
        public async Task<IActionResult> MyTeamEvaluations([FromBody] MyEvaluationFilter dto)
        {
            var listUser = await mediator.Send(new GetMyTeamEvaluationQuery() { evaluationQueryFilter = dto });

            return Ok(listUser);
        }


        [HttpPost("myteamresumecomp")]
        public async Task<IActionResult> MyTeamResumeComp([FromBody] MyTeamResumeFilterDto dto)
        {
            var listUser = await mediator.Send(new GetMyTeamResumeQuery() { filter = dto });

            return Ok(listUser);
        }

        [HttpPost("myteamresumecomp-v2")]
        public async Task<IActionResult> MyTeamResumeCompV2([FromBody] MyTeamResumeFilterDto dto)
        {
            var listUser = await mediator.Send(new GetMyTeamResumeV2Query() { filter = dto });

            return Ok(listUser);
        }




        [HttpPost("getninebox")]
        public async Task<IActionResult> GetNineBox([FromBody] NineBoxFilterDto dto)
        {
            var listUser = await mediator.Send(new GetNineBoxQuery() { dtofilter = dto });

            return Ok(listUser);
        }

        [HttpPost("getcampaingevaluationlist")]
        public async Task<IActionResult> GetCampaingEvaluationPaginationList(EvaluationQueryFilterDto dto)
        {

            var listUser = await mediator.Send(new GetListEvaluationPaginationQuery() { evaluationQueryFilter = dto ,active = 1});

            return Ok(listUser);
        }
        [HttpPost("getcampaingevaluationlistdeleted")]
        [AllowAnonymous]
        public async Task<IActionResult> GetCampaingEvaluationPaginationListDeleted(EvaluationQueryFilterDto dto)
        {

            var listUser = await mediator.Send(new GetListEvaluationPaginationQuery() { evaluationQueryFilter = dto ,active = 0});

            return Ok(listUser);
        }

        [HttpGet("getcampaingevaluationalert/{id}")]
        public async Task<IActionResult> GetCampaingEvaluationAlert(int id)
        {
            var listCampaing = await mediator.Send(new GetCampaingEvaluationAlertQuery() { nid_employee = id });

            return Ok(listCampaing);
        }

        [HttpPost("getcampaingbyusermyevaluations")]
        public async Task<IActionResult> GetCampaingByUserMyEvaluations(CampaingByUserMyEvaluationFilter dto)
        {
            var listCampaing = await mediator.Send(new GetCampaingByUserMyEvaluationQuery() { campaingByUserMyEvaluationFilter = dto });

            return Ok(listCampaing);
        }
        

       [HttpPost("getcompanybycampaingusermyevaluations")]
        public async Task<IActionResult> GetCompanyByCampaingUserMyEvaluations(CompanyByCampaingUserMyEvaluationFilter dto)
        {
            var listCompany = await mediator.Send(new GetCompanyByCampaingUserMyEvaluationQuery() { companyByCampaingUserMyEvaluationFilter = dto });

            return Ok(listCompany);
        }

        [HttpPost("getgerenciasbycampaingusermyevaluations")]
        public async Task<IActionResult> GetGerenciasByCampaingUserMyEvaluations(GerenciasByCampaingUserMyEvaluationFilter dto)
        {
            var listGerencias = await mediator.Send(new GetGerenciasByCampaingUserMyEvaluationQuery() { gerenciasByCampaingUserMyEvaluationFilter = dto });

            return Ok(listGerencias);
        }

        [HttpPost("getareasbycampaingusermyevaluations")]
        public async Task<IActionResult> GetAreasByCampaingUserMyEvaluations(AreasByCampaingUserMyEvaluationFilter dto)
        {
            var listAreas = await mediator.Send(new GetAreasByCampaingUserMyEvaluationQuery() { areasByCampaingUserMyEvaluationFilter = dto });

            return Ok(listAreas);
        }

        [HttpPost("getsubareasbycampaingusermyevaluations")]
        public async Task<IActionResult> GetSubAreasByCampaingUserMyEvaluations(SubAreasByCampaingUserMyEvaluationFilter dto)
        {
            var listAreas = await mediator.Send(new GetSubAreasByCampaingUserMyEvaluationQuery() { subAreasByCampaingUserMyEvaluationFilter = dto });

            return Ok(listAreas);
        }

        [HttpPost("getcollaboratorsbycampaingusermyevaluations")]
        public async Task<IActionResult> GetCollaboratorsByCampaingUserMyEvaluations(CollaboratorsByCampaingUserMyEvaluationFilter dto)
        {
            var listCollaborators = await mediator.Send(new GetCollaboratorsByCampaingUserMyEvaluationQuery() { collaboratorsByCampaingUserMyEvaluationFilter = dto });

            return Ok(listCollaborators);
        }

        [HttpPost("getcampaingbyevaluation")]
        public async Task<IActionResult> GetCampaingByEvaluations()
        {
            var listCampaing = await mediator.Send(new GetCampaingByEvaluationQuery());

            return Ok(listCampaing);
        }

        [HttpPost("getconfiglevelninebox")]
        public async Task<IActionResult> GetConfigLevelNineBox()
        {
            var listCampaing = await mediator.Send(new GetConfigLevelNineBoxQuery());

            return Ok(listCampaing);
        }

        [HttpPost("getconfiglevelnineboxbycampaign")]
        public async Task<IActionResult> GetConfigDetailLevelNineBox(ConfigDetailLevelNineBoxFilter dto)
        {
            var listCampaing = await mediator.Send(new GetConfigDetailLevelNineBoxQuery() { configDetailLevelNineBoxFilter=dto});

            return Ok(listCampaing);
        }

        [HttpPost("getcampaignprogressxls")]
        public async Task<IActionResult> GetCampaignProgressXLS(CampaignProgressFilterDto dto)
        {
            var listCampaing = await mediator.Send(new GetCampaignProgressXLSQuery() { filter= dto });

            return Ok(listCampaing);
        }

        [HttpPost("getcampaingbyuser")]
        public async Task<IActionResult> GetCampaingByEvaluations(CampaingByUserFilter dto)
        {
            var listCampaing = await mediator.Send(new GetCampaingByUserQuery() { filter = dto });

            return Ok(listCampaing);
        }

    }
}
