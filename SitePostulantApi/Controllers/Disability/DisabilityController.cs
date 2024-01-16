using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.Postulant.Disability.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using SitePostulant.Application.Disability.IService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SitePostulantApi.Controllers.Disability
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisabilityController : BaseApiController
    {
        private readonly IDisabilityService disabilityService;
        private readonly AppSettings _appSettings;
        public DisabilityController(IDisabilityService disabilityService, IOptions<AppSettings> appSettings)
        {
            this.disabilityService = disabilityService;
            this._appSettings = appSettings.Value;
        }

        [HttpGet("getdisability/{idPerson}")]
        public async Task<IActionResult> GetDisability(int idPerson)
        {

            var result = await disabilityService.GetDisability(idPerson);

            return Ok(result);

        }

        [HttpPost("add")]
        public async Task<IActionResult> Add()
        {
            var dtoRequest = Request.Form["request"];
            var file = Request.Form.Files[0];
            var dto = JsonConvert.DeserializeObject<DisabilityDto>(dtoRequest);

            var result = await disabilityService.Add(dto, file);

            return Ok(result);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update(DisabilityDto dto)
        {
            var result = await disabilityService.Update(dto);

            return Ok(result);
        }

    }
}
