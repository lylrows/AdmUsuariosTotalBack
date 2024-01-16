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
    public class StaffRequestPermitController : BaseApiController
    {
        private readonly AppSettings appSettings;

        public StaffRequestPermitController(IOptions<AppSettings> appSettings)
        {
            this.appSettings = appSettings.Value;
        }
        [HttpPost("add")]
        public async Task<IActionResult> add()
        {
            var objJson = Request.Form["data"];
            var staffRequestPermitDto = JsonConvert.DeserializeObject<StaffRequestPermitDto>(objJson);

            FormFileStream formFileStream = new FormFileStream(appSettings,
                                                               appSettings.PathSaveFile,
                                                               Request.Form.Files);
            formFileStream.Save();
            if (!string.IsNullOrEmpty(formFileStream.FullPath))
            {
                staffRequestPermitDto.PathFileDocument = formFileStream.FullPath;
            }
            var result = await mediator.Send(new CreateStaffRequestPermitCommand() { StaffRequestPermit = staffRequestPermitDto });
            return Ok(result);
        }

        [HttpGet("getbyid/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await mediator.Send(new GetStaffRequestPermitByIdQuery() { Id = id });

            return Ok(result);
        }
        [HttpGet("getforselect")]
        public async Task<IActionResult> GetForSelect()
        {
            var listTypeStaffRequestforSelect = await mediator.Send(new GetTypePermitForSelectQuery());

            return Ok(listTypeStaffRequestforSelect);
        }

        [HttpGet("getpdf/{id}")]
        public async Task<IActionResult> GetPdf(int id)
        {
            var result = await mediator.Send(new StaffRequestPermitGeneratePdf() { Id = id });

            return Ok(result);
        }
    }
}