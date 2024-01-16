using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.Postulant.Skills.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SitePostulant.Application.Skills.IServices;
using SitePostulant.Application.SkillsPostulant.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SitePostulantApi.Controllers.SkillsPostulant
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsPostulantController : BaseApiController
    {
        private readonly AppSettings appSettings;
        private readonly ISkillsPostulantService skillsPostulantService;
        private readonly ISkillsService skillsService;
        public SkillsPostulantController(IOptions<AppSettings> appSettings, ISkillsPostulantService skillsPostulantService, ISkillsService skillsService)
        {
            this.appSettings = appSettings.Value;
            this.skillsPostulantService = skillsPostulantService;
            this.skillsService = skillsService;
        }

        [HttpGet("getskillspostulant/{idPerson}")]
        public async Task<IActionResult> GetSkillsPostulant(int idPerson)
        {

            var result = await skillsPostulantService.GetSkilssPostulant(idPerson);

            return Ok(result);

        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(List<SkillsPostulantDto> dto)
        {
            var result = await skillsPostulantService.Add(dto);

            return Ok(result);
        }

        [HttpPost("delete")]
        public async Task<IActionResult> Delete(SkillsPostulantDto dto)
        {
            var result = await skillsPostulantService.Delete(dto);

            return Ok(result);
        }

        [HttpGet("getskillsbyname/{description}")]
        public async Task<IActionResult> GetSkillsByDescription(string description)
        {
            var result = await skillsService.GetSkillsByDescription(description);

            return Ok(result);
        }
    }
}
