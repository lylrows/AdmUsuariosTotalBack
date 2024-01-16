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
    public class StaffRequestAbsenceController : BaseApiController
    {
        private readonly AppSettings appSettings;
        public StaffRequestAbsenceController(IOptions<AppSettings> appSettings)
        {
            this.appSettings = appSettings.Value;
        }
        [HttpPost("add")]
        public async Task<IActionResult> add()
        {
            var objJson = Request.Form["data"];
            var staffRequestAbsenceDto = JsonConvert.DeserializeObject<StaffRequestAbsenceDto>(objJson);

            FormFileStream formFileStream = new FormFileStream(appSettings,
                                                               appSettings.PathSaveFile,
                                                               Request.Form.Files);
            formFileStream.Save();
            if (!string.IsNullOrEmpty(formFileStream.FullPath))
            {
                staffRequestAbsenceDto.PathFileDocument = formFileStream.FullPath;
            }





            var result = await mediator.Send(new CreateStaffRequestAbsenceCommand() { StaffRequestAbsence = staffRequestAbsenceDto });
            return Ok(result);
        }

        [HttpGet("getbyid/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await mediator.Send(new GetStaffRequestAbsenceByIdQuery() { Id = id });

            return Ok(result);
        }

        [HttpGet("getforselect")]
        public async Task<IActionResult> GetForSelect()
        {
            var listTypeStaffRequestforSelect = await mediator.Send(new GetTypeAbsenceForSelectQuery());

            return Ok(listTypeStaffRequestforSelect);
        }

        [HttpGet("getpdf/{id}")]
        public async Task<IActionResult> GetPdf(int id)
        {
            var result = await mediator.Send(new StaffRequestAbsenceGeneratePdf() { Id = id });

            return Ok(result);
        }
    }
}