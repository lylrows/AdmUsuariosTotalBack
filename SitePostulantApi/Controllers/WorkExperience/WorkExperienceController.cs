using HumanManagement.Domain.Postulant.WorkExperience.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SitePostulant.Application.WorkExperience.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SitePostulantApi.Controllers.WorkExperience
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkExperienceController : BaseApiController
    {
        private readonly IWorkExperienceService workExperienceService;
        public WorkExperienceController(IWorkExperienceService workExperienceService)
        {
            this.workExperienceService = workExperienceService;
        }

        [HttpGet("getworkexperience/{idPerson}")]
        public async Task<IActionResult> GetLanguagePostulant(int idPerson)
        {

            var result = await workExperienceService.GetWorkExperience(idPerson);

            return Ok(result);

        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(WorkExperienceDto dto)
        {
            var result = await workExperienceService.Add(dto);

            return Ok(result);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update(WorkExperienceDto dto)
        {
            var result = await workExperienceService.Update(dto);

            return Ok(result);
        }
    }
}
