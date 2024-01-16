using HumanManagement.Domain.Postulant.SalaryPreference.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SitePostulant.Application.SalaryPreference.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SitePostulantApi.Controllers.SalaryPreference
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaryPreferenceController : BaseApiController
    {
        private readonly ISalaryPreferenceService salaryPreferenceService;
        public SalaryPreferenceController(ISalaryPreferenceService salaryPreferenceService)
        {
            this.salaryPreferenceService = salaryPreferenceService;
        }

        [HttpGet("getsalarypreference/{idPerson}")]
        public async Task<IActionResult> GetSalaryPreference(int idPerson)
        {

            var result = await salaryPreferenceService.GetSalaryByPostulant(idPerson);

            return Ok(result);

        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(SalaryPreferenceDto dto)
        {
            var result = await salaryPreferenceService.Add(dto);

            return Ok(result);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update(SalaryPreferenceDto dto)
        {
            var result = await salaryPreferenceService.Update(dto);

            return Ok(result);
        }
    }
}
