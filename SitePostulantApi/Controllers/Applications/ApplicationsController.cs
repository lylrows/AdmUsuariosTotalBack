using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.Applicants.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SitePostulant.Application.Applications.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SitePostulantApi.Controllers.Applications
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationsController : BaseApiController
    {
        private readonly AppSettings appSettings;
        private readonly IApplicantService _applicantService;
        public ApplicationsController(IOptions<AppSettings> appSettings, IApplicantService applicantService)
        {
            this.appSettings = appSettings.Value;
            this._applicantService = applicantService;
        }

        [HttpPost()]
        public async Task<IActionResult> GetListMyApplicants(FilterApplicants filters)
        {

            var result = await _applicantService.GetListMyApplicants(filters);

            return Ok(result);

        }

        [HttpGet("getstatelist/{IdUser}")]
        public async Task<IActionResult> GetStateApplicants(int IdUser)
        {

            var result = await _applicantService.GetStateApplicants(IdUser);

            return Ok(result);

        }

        [HttpGet("getjobs/{IdUser}")]
        public async Task<IActionResult> GetListJob(int IdUser)
        {

            var result = await _applicantService.GetListJob(IdUser);

            return Ok(result);

        }
    }
}
