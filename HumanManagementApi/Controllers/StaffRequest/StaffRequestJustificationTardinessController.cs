using System.Threading.Tasks;
using HumanManagement.Application.StaffRequest.Commands.Create;
using HumanManagement.Application.StaffRequest.GeneratePdf;
using HumanManagement.Application.StaffRequest.Queries;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.StaffRequest.Dto;
using HumanManagementApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace HumanManagementApi.Controllers.StaffRequest
{
    public class StaffRequestJustificationTardinessController : BaseApiController
    {
        private readonly AppSettings appSettings;
        public StaffRequestJustificationTardinessController(IOptions<AppSettings> appSettings)
        {
            this.appSettings = appSettings.Value;
        }
        [HttpPost("add")]
        public async Task<IActionResult> add()
        {
            var objJson = Request.Form["data"];
            var staffRequestJustificationTardinessDto = JsonConvert.DeserializeObject<StaffRequestJustificationTardinessDto>(objJson);

            FormFileStream formFileStream = new FormFileStream(appSettings,
                                                               Constants.StaffRequestAttachedDocument.FOLDER_JUSTIFICATION_TARDINESS,
                                                               Request.Form.Files);
            formFileStream.Save();
            if (!string.IsNullOrEmpty(formFileStream.FullPath))
            {
                staffRequestJustificationTardinessDto.PathFileDocument = formFileStream.FullPath;
            }
            var result = await mediator.Send(new CreateStaffRequestJustificationtardinessCommand() { StaffRequestJustificationTardiness = staffRequestJustificationTardinessDto });
            return Ok(result);
        }

        [HttpGet("getbyid/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await mediator.Send(new GetStaffRequestJustificationTardinessByIdQuery() { Id = id });

            return Ok(result);
        }

        [HttpGet("getpdf/{id}")]
        public async Task<IActionResult> GetPdf(int id)
        {
            var result = await mediator.Send(new StaffRequestJustificationTardinessGeneratePdf() { Id = id });

            return Ok(result);
        }
    }
}