using HumanManagement.Domain.Postulant.JobObjective.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SitePostulant.Application.JobObjective.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SitePostulantApi.Controllers.JobObjective
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobObjectiveController : BaseApiController
    {
        private readonly IJobObjectiveService jobObjectiveService;
        public JobObjectiveController(IJobObjectiveService jobObjectiveService)
        {
            this.jobObjectiveService = jobObjectiveService;
        }

        [HttpGet("getjobobjective/{idPerson}")]
        public async Task<IActionResult> GetJobObjective(int idPerson)
        {

            var result = await jobObjectiveService.GetObjectivesByPostulant(idPerson);

            return Ok(result);

        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(JobObjectiveDto dto)
        {
            var result = await jobObjectiveService.Add(dto);

            return Ok(result);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update(JobObjectiveDto dto)
        {
            var result = await jobObjectiveService.Update(dto);

            return Ok(result);
        }
    }
}
