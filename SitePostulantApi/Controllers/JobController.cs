using HumanManagement.Domain.Job.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SitePostulant.Application.Job.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitePostulantApi.Controllers
{
 
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : BaseApiController
    {
        private readonly IJobService _jobService;

        public JobController( IJobService jobService)
        {
            
            this._jobService = jobService;
        }

        [HttpGet("getbyid/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _jobService.GetById(id);

            return Ok(result);
        }

        [HttpGet("isjobpostulated/{idjob}/{idpostulant}")]
        public async Task<IActionResult> IsJobPostulated(int idjob, int idpostulant)
        {
            var result = await _jobService.IsJobPostulated(idjob,idpostulant);

            return Ok(result);
        }
        [HttpPost("addjobpostulant")]
        public async Task<IActionResult> AddJobPostulant(JobPostulantDto dto)
        {
            var result = await _jobService.AddJobPostulant(dto.Id_Job, dto.Id_Postulant);

            return Ok(result);
        }

        [HttpGet("getrelatedjobs/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetRelatedJobs(int id)
        {
            var result = await _jobService.GetRelatedJobs(id);

            return Ok(result);
        }
        [HttpGet("getotherjobs")]
        [AllowAnonymous]
        public async Task<IActionResult> GetOtherJobs()
        {
            var result = await _jobService.GetOtherJobs();

            return Ok(result);
        }
        [HttpPost("getalljobs")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllJobs(JobFilterDto filter)
        {
            var result = await _jobService.GetAllJobs(filter);

            return Ok(result);
        }
    }
}
