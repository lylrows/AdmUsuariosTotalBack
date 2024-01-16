using HumanManagement.Application.Areas.Commands.Create;
using HumanManagement.Application.Areas.Commands.Delete;
using HumanManagement.Application.Areas.Commands.Edit;
using HumanManagement.Application.Areas.Commands.Validar;
using HumanManagement.Application.Areas.Queries;
using HumanManagement.Application.Response;
using HumanManagement.Domain.Areas.Dto;
using HumanManagement.Domain.Areas.QueryFilter;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanManagementApi.Controllers.Areas
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreasController : BaseApiController
    {
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] AreasDto dto)
        {
            var result = await mediator.Send(new CreateAreaCommand() { areasDto = dto});
            return new OkObjectResult(result);
        }

        [HttpPost("edit")]
        public async Task<IActionResult> Edit([FromBody] AreasDto dto)
        {
            var result = await mediator.Send(new EditAreaCommand() { areasDto = dto });
            return new OkObjectResult(result);
        }

        [HttpPost("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await mediator.Send(new DeleteAreaCommand() { Id = id });
            return new OkObjectResult(result);
        }

        [HttpPost("validar/{id}/{active}")]
        public async Task<IActionResult> ValidarArea(int id, bool active)
        {
            var result = await mediator.Send(new ValidarEditCommand() { Id = id, Active = active });
            return new OkObjectResult(result);
        }

        [HttpGet("getById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok();
        }

        [HttpPost("get")]
        public async Task<IActionResult> Get([FromBody] AreasQueryFilter dto)
        {
           var areas = await mediator.Send(new GetAreaQuery() { areaQueryFilter = dto});
           return areas.Data == null ? NotFound() : (IActionResult)Ok(areas);
        }
        

       [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var areas = await mediator.Send(new GetAllAreaQuery());
            return areas.Data == null ? NotFound() : (IActionResult)Ok(areas);
        }
        [HttpGet("getareabycompany/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAreaByCompany(int id)
        {
            var listArea = await mediator.Send(new GetAreaByCompanyQuery() { IdCompany = id });

            return Ok(listArea);
        }

        [HttpGet("getmanagementbycompany/{id}")]
        public async Task<IActionResult> GetManagmentByCompany(int id)
        {
            var listManagement = await mediator.Send(new GetManagementByCompanyQuery() { IdCompany = id });

            return Ok(listManagement);
        }

        [HttpGet("getareabymanagement/{id}")]
        public async Task<IActionResult> GetAreaByManagement(int id)
        {
            var listAreas = await mediator.Send(new GetAreaByManagementQuery() { IdManagement = id });

            return Ok(listAreas);
        }

        [HttpGet("getsubareabyidarea/{id}")]
        public async Task<IActionResult> GetSubAreaByIdArea(int id)
        {
            var listSubareas = await mediator.Send(new GetSubAreaByIdAreaQuery() { IdArea = id });

            return Ok(listSubareas);
        }

        [HttpGet("getareabyiduser/{id}")]
        public async Task<IActionResult> GetAreaByIdUser(int id)
        {
            var listAreas = await mediator.Send(new GetAreaByUserQuery() { IdUser = id });

            return Ok(listAreas);
        }

        [HttpPost("getgerenciasbyuser")]
        public async Task<IActionResult> GetGerenciasByUser(AreasComboQueryFilter dto)
        {
            var areas = await mediator.Send(new GetGerenciasByUserQuery() { areasComboQueryFilter = dto });
            return areas.Data == null ? NotFound() : (IActionResult)Ok(areas);
        }

        [HttpPost("getsubareasbyarea")]
        public async Task<IActionResult> GetSubAreasByArea(SubAreasComboQueryFilter dto)
        {
            var areas = await mediator.Send(new GetSubAreasByAreaQuery() { subAreasComboQueryFilter = dto });
            return areas.Data == null ? NotFound() : (IActionResult)Ok(areas);
        }

        [HttpPost("getsubareasbyareamultiple")]
        public async Task<IActionResult> GetSubAreasByAreaMultiple(SubAreasComboMultipleQueryFilter dto)
        {
            var areas = await mediator.Send(new GetSubAreasByAreaMultipleQuery() {  subAreasComboQueryFilter = dto});
            return areas.Data == null ? NotFound() : (IActionResult)Ok(areas);
        }
        [HttpPost("getcompanybyuser")]
        public async Task<IActionResult> GetCompanyByUser(CompanyComboQueryFilter dto)
        {
            var areas = await mediator.Send(new GetCompanyByUserQuery() { companyComboQueryFilter = dto });
            return areas.Data == null ? NotFound() : (IActionResult)Ok(areas);
        }

        [HttpPost("getgerenciasbyuserevaluation")]
        public async Task<IActionResult> GetGerenciasByUserEvaluation(AreasComboQueryFilter dto)
        {
            var areas = await mediator.Send(new GetGerenciasByUserEvaluationQuery() { areasComboQueryFilter = dto });
            return areas.Data == null ? NotFound() : (IActionResult)Ok(areas);
        }

        [HttpPost("getareasbygerenciaevaluation")]
        public async Task<IActionResult> GetAreasByGerenciaEvaluation(AreasEvaluationComboQueryFilter dto)
        {
            var areas = await mediator.Send(new GetAreasByGerenciaEvaluationQuery() { areasEvaluationComboQueryFilter = dto });
            return areas.Data == null ? NotFound() : (IActionResult)Ok(areas);
        }

        [HttpPost("getsubareasbyareaevaluation")]
        public async Task<IActionResult> GetSubAreasByAreaEvaluation(SubAreasEvaluationComboQueryFilter dto)
        {
            var areas = await mediator.Send(new GetSubAreasByAreaEvaluationQuery() { subAreasEvaluationComboQueryFilter = dto });
            return areas.Data == null ? NotFound() : (IActionResult)Ok(areas);
        }

        [HttpPost("getgerenciasbycompany")]
        public async Task<IActionResult> GetGerenciasByCompany(GerenciasComboQueryFilter dto)
        {
            var gerencias = await mediator.Send(new GetGerenciasByCompanyQuery() { gerenciasComboQueryFilter = dto });
            return gerencias.Data == null ? NotFound() : (IActionResult)Ok(gerencias);
        }

        [HttpPost("getjefesbyarea")]
        public async Task<IActionResult> GetJefesByArea(JefesQueryFilter dto)
        {
            var areas = await mediator.Send(new GetJefesByAreaQuery() { jefesQueryFilter = dto });
            return areas.Data == null ? NotFound() : (IActionResult)Ok(areas);
        }


    }
}
