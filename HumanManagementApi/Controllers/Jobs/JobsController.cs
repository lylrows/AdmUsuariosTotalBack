using HumanManagement.Application.Jobs.Queries;
using HumanManagement.Application.Postulant.Queries;
using HumanManagement.Domain.Job.Dto;
using HumanManagement.Domain.Job.QueryFilter;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanManagementApi.Controllers.Jobs
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : BaseApiController
    {
        [HttpPost("getlist")]
        public async Task<IActionResult> GetListPagination(JobQueryFilter filter)
        {
            var list = await mediator.Send(new GetJobsByUserQuery() { filter = filter });

            return Ok(list);
        }

        [HttpGet("getkeyword/{idjob}")]
        public async Task<IActionResult> GetRequestFlow(int idjob)
        {
            var result = await mediator.Send(new GetListKeyWordJobQuery() { idJob = idjob });
            return result == null ? NotFound() : (IActionResult)Ok(result);
        }

        [HttpPost("addkeyword")]
        public async Task<IActionResult> AddKeyWord(JobKeyWordDto dto)
        {
            var list = await mediator.Send(new CreateKeyWordCommand() { jobKeyWordDto = dto });

            return Ok(list);
        }

        [HttpPost("deletekeyword")]
        public async Task<IActionResult> DeleteKeyWord(JobKeyWordDto dto)
        {
            var list = await mediator.Send(new DeleteKeyWordCommand() { jobKeyWordDto = dto });

            return Ok(list);
        }
    }
}
