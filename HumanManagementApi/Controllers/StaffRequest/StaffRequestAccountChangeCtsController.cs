using System.Threading.Tasks;
using HumanManagement.Application.StaffRequest.Commands.Create;
using HumanManagement.Application.StaffRequest.GeneratePdf;
using HumanManagement.Application.StaffRequest.Queries;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.StaffRequest.Dto;
using HumanManagementApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace HumanManagementApi.Controllers.StaffRequest
{
    public class StaffRequestAccountChangeCtsController : BaseApiController
    {
        private readonly AppSettings appSettings;
        public StaffRequestAccountChangeCtsController(IOptions<AppSettings> appSettings)
        {
            this.appSettings = appSettings.Value;
        }

        [HttpPost("add")]
        public async Task<IActionResult> add()
        {
            var objJson = Request.Form["data"];
            var staffRequestAccountChange = JsonConvert.DeserializeObject<StaffRequestAccountChangeDto>(objJson);

            FormFileStream formFileStream = new FormFileStream(appSettings,
                                                               Constants.StaffRequestAttachedDocument.FOLDER_ACCOUNT_CHANGE_CTS,
                                                               Request.Form.Files);
            formFileStream.Save();
            if (!string.IsNullOrEmpty(formFileStream.FullPath))
            {
                staffRequestAccountChange.PathFileDocument = formFileStream.FullPath;
            }
            var result = await mediator.Send(new CreateStaffRequestAccountChangeCtsCommand() { StaffRequestAccountChange = staffRequestAccountChange });

            return Ok(result);
        }

        [HttpGet("getbyid/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await mediator.Send(new GetStaffRequestAccountChangeCtsByIdQuery() { Id = id });

            return Ok(result);
        }

        [HttpGet("getforselect")]
        public async Task<IActionResult> GetForSelect()
        {
            var listTypeStaffRequestforSelect = await mediator.Send(new GetBankingEntityChangeCtsForSelectQuery());

            return Ok(listTypeStaffRequestforSelect);
        }

        [HttpGet("getpdf/{id}")]
        public async Task<IActionResult> GetPdf(int id)
        {
            var result = await mediator.Send(new StaffRequestAccountChangeCtsGeneratePdf() { Id = id });

            return Ok(result);
        }
    }
}