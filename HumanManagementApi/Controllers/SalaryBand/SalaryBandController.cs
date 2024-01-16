using HumanManagement.Application.SalaryBand.Commands;
using HumanManagement.Application.SalaryBand.Queries;
using HumanManagement.Domain.SalaryBand.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HumanManagementApi.Controllers.SalaryBand
{
    public class SalaryBandController : BaseApiController
    {
        [HttpPost("getlistpaginationbandbox")]
        public async Task<IActionResult> GetListPagination([FromBody] SalaryBandQueryFilter dto)
        {
            
            var listUser = await mediator.Send(new GetSalaryBandPaginationQuery() { salaryQueryFilter = dto });

            return Ok(listUser);
        }
        [HttpGet("getsalarygroupcombo")]
        public async Task<IActionResult> GetSalaryGroupCombo()
        {

            var dropdownlist = await mediator.Send(new GetSalaryGroupComboQuery() { });

            return Ok(dropdownlist);

        }
        [HttpGet("getlistgroupsalary")]
        public async Task<IActionResult> GetListGroupSalary()
        {

            var result = await mediator.Send(new GetListGroupSalaryQuery() { });

            return Ok(result);

        }

        [HttpPost("savesalaryband")]
        
        public async Task<IActionResult> SaveSalaryBand([FromBody] SaveSalaryBandDto dto)
        {

            var listUser = await mediator.Send(new SaveSalaryBandCommand() {  newSalary = dto });

            return Ok(listUser);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            var del = await mediator.Send(new DeleteSalaryBandCommand() {IdBandBox = id});

            return Ok(del);
        }

        [HttpPost("getecoconditionlist")]
        public async Task<IActionResult> GetEcoConditionList([FromBody] EcoConditionFilter dto)
        {
            var listUser = await mediator.Send(new GetEcoConditionQuery() { ecoQueryFilter = dto });

            return Ok(listUser);
        }
        [HttpPost("getecoconditionlistxls")]
        public async Task<IActionResult> GetEcoConditionListXls([FromBody] EcoConditionFilter dto)
        {
            var stringfile = await mediator.Send(new GetEcoConditionXLSQuery() { ecoQueryFilter = dto });

            return Ok(stringfile);
        }

        [HttpGet("validexistbygroup/{id}")]
        public async Task<IActionResult> ValidExistByGroup(int id)
        {

            var del = await mediator.Send(new ValidExistSalaryBandQuery() { IdGroup= id });

            return Ok(del);
        }


        [HttpPost("getresumebudget")]
        public async Task<IActionResult> GetResumeBudget(BudgetFilterDto dto)
        {
            var list = await mediator.Send(new GetBudgetResumeQuery() { budgetFilter= dto});
            return Ok(list);
        }

        [HttpPost("getresumebudgetxls")]
        public async Task<IActionResult> GetResumeBudgetXls(BudgetFilterDto dto)
        {
            var excelstring = await mediator.Send(new GetBudgetResumeXLSQuery() { budgetFilter = dto });

            return Ok(excelstring);
        }


        [HttpPost("saveeconomiccondition")]
        public async Task<IActionResult> SaveEconomicCondition(SaveEconomicConditionDto dto)
        {

            var list = await mediator.Send(new SaveEcoConditionCommand() { newEconomicCondition = dto });

            return Ok(list);
        }

        [HttpPost("getsalarystructure")]
        public async Task<IActionResult> GetSalaryStructure(SalaryStructureFilter dto)
        {
            var list = await mediator.Send(new GetSalaryStructureQuery() { filter= dto });
            return Ok(list);
        }

        [HttpPost("getsalarystructurexls")]
        public async Task<IActionResult> GetSalaryStructureXls(SalaryStructureFilter dto)
        {
            var stringfile = await mediator.Send(new GetSalaryStructureXLSQuery() { filter = dto });
            return Ok(stringfile);
        }

        [HttpGet("getareagroup")]
        public async Task<IActionResult> GetAreaGroup()
        {
            var dropdownlist = await mediator.Send(new GetAreaGroupCboQuery() { });

            return Ok(dropdownlist);
        }

        [HttpGet("getareacentercost/{id}")]
        public async Task<IActionResult> GetAreaCenterCost(int id)
        {
            var dropdownlist = await mediator.Send(new GetAreaCenterCostCboQuery() {nid_areagroup= id });

            return Ok(dropdownlist);
        }

        [HttpGet("getareaccbygerencia/{id}")]
        public async Task<IActionResult> GetAreaCCByGerencia(int id)
        {
            var dropdownlist = await mediator.Send(new GetAreaCCByGerenciaCboQuery() { nid_gerencia = id });

            return Ok(dropdownlist);
        }

        [HttpPost("getsalarystructureexportxls")]
        public async Task<IActionResult> GetSalaryStructureExportXls(SalaryStructureFilter dto)
        {
            var stringfile = await mediator.Send(new GetSalaryStructureExportXLSQuery() { filter = dto });
            return Ok(stringfile);
        }

        [HttpPost("getecoconditionexportxls")]
        public async Task<IActionResult> GetEcoConditionReportXls([FromBody] EcoConditionFilter dto)
        {
            var stringfile = await mediator.Send(new GetEcoConditionExportXLSQuery() { ecoQueryFilter = dto });

            return Ok(stringfile);
        }
    }
}
