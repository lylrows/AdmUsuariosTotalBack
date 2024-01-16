using HumanManagement.Application.JobsInternal.Command;
using HumanManagement.Application.JobsInternal.Queries;
using HumanManagement.Domain.Job.Dto;
using HumanManagement.Domain.Job.QueryFilter;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanManagementApi.Controllers.JobInternal
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobInternalController : BaseApiController
    {
        [HttpPost("get")]
        public async Task<IActionResult> Get([FromBody] JobInternalQueryFilter dto)
        {
            var areas = await mediator.Send(new GetJobsInternalQuery() { filter = dto });
            return areas.Data == null ? NotFound() : (IActionResult)Ok(areas);
        }

        [HttpGet("getareas")]
        public async Task<IActionResult> GetAreaList()
        {
            var areas = await mediator.Send(new GetJobsAreaQuery() { });
            return areas.Data == null ? NotFound() : (IActionResult)Ok(areas);
        }

        [HttpGet("getjobbyid/{idjob}")]
        public async Task<IActionResult> GetJobById(int idjob)
        {
            var dto = await mediator.Send(new GetJobByIdQuery() { IdJob = idjob });
            return dto.Data == null ? NotFound() : (IActionResult)Ok(dto);
        }


        [HttpPost("addJobPostulant")]
        public async Task<IActionResult> AddJobPostulant(JobOffersInternalPostulantDto obj)
        {
            var dto = await mediator.Send(new CreateJobPostulantCommand() { dto = obj });
            return Ok(dto);
        }

        [HttpGet("validatejobpostulant/{iduser}/{idjob}")]
        public async Task<IActionResult> ValidateJobPostulant(int IdUser, int IdJob)
        {
            var dto = await mediator.Send(new ValidatePostulantJobCommand() { IdUser = IdUser, IdJob = IdJob });
            return Ok(dto);
        }

        [HttpPost("loadcv")]
        public async Task<IActionResult> LoadCv()
        {
            var file = Request.Form.Files[0];
            var dto = await mediator.Send(new LoadCurriculumCommand() { FileCv = file });
            return Ok(dto);
        }

        [HttpGet("getcv")]
        public async Task<IActionResult> GetCv()
        {
            var dto = await mediator.Send(new GetCvPostulantQuery() { });
            return Ok(dto);
        }

        [HttpPost("deletecv")]
        public async Task<IActionResult> DeleteCv()
        {
            var dto = await mediator.Send(new DeleteCvPostulantCommand() { });
            return Ok(dto);
        }

        [HttpPost("getjobsbyuser")]
        public async Task<IActionResult> GetJobsByUserQuery(JobQueryFilter filter)
        {
            var dto = await mediator.Send(new GetJobsByUserQuery() { filter = filter});
            return Ok(dto);
        }
    }
}
