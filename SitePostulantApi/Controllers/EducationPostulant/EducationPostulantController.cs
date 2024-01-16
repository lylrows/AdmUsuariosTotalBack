using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.Postulant.Education.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SitePostulant.Application.EducationPostulant.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SitePostulantApi.Controllers.EducationPostulant
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationPostulantController : BaseApiController
    {
        private readonly AppSettings appSettings;
        private readonly IEducationPostulantService educationPostulantService;
        public EducationPostulantController(IOptions<AppSettings> appSettings, IEducationPostulantService educationPostulantService)
        {
            this.appSettings = appSettings.Value;
            this.educationPostulantService = educationPostulantService;
        }

        [HttpGet("geteducationpostulant/{idPerson}")]
        public async Task<IActionResult> GetEducationPostulant(int idPerson)
        {

            var result = await educationPostulantService.GetEducationPostulant(idPerson);

            return Ok(result);

        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(EducationPostulantDto dto)
        {
            var result = await educationPostulantService.Add(dto);

            return Ok(result);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update(EducationPostulantDto dto)
        {
            var result = await educationPostulantService.Update(dto);

            return Ok(result);
        }
    }
}
