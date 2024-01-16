using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.Postulant.Languages.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SitePostulant.Application.LanguagePostulant.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SitePostulantApi.Controllers.LanguagePostulant
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguagePostulantController : BaseApiController
    {
        private readonly AppSettings appSettings;
        private readonly ILanguagePostulantService languagePostulantService;
        public LanguagePostulantController(IOptions<AppSettings> appSettings, ILanguagePostulantService languagePostulantService)
        {
            this.appSettings = appSettings.Value;
            this.languagePostulantService = languagePostulantService;
        }

        [HttpGet("getlanguagepostulant/{idPerson}")]
        public async Task<IActionResult> GetLanguagePostulant(int idPerson)
        {

            var result = await languagePostulantService.GetLanguagePostulant(idPerson);

            return Ok(result);

        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(LanguagePostulantDto dto)
        {
            var result = await languagePostulantService.Add(dto);

            return Ok(result);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update(LanguagePostulantDto dto)
        {
            var result = await languagePostulantService.Update(dto);

            return Ok(result);
        }
    }
}
