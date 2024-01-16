using System;
using System.Threading.Tasks;
using HumanManagement.Application.StaffRequest.Commands.Create;
using HumanManagement.Application.StaffRequest.Commands.Update;
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
    public class StaffRequestLoanController : BaseApiController
    {
        private readonly AppSettings appSettings;
        public StaffRequestLoanController(IOptions<AppSettings> appSettings)
        {
            this.appSettings = appSettings.Value;
        }

        [HttpPost("add")]
        public async Task<IActionResult> add()
        {
            var objJson = Request.Form["data"];
            var staffRequestLoanDto = JsonConvert.DeserializeObject<StaffRequestLoanDto>(objJson);

            var file = Request.Form.Files[0];

            var result = await mediator.Send(new CreateStaffRequestLoanCommand() { StaffRequestLoan = staffRequestLoanDto, file = file });
            return Ok(result);
        }

        [HttpPost("update")]
        public async Task<IActionResult> update()
        {
            var objJson = Request.Form["data"];
            var staffRequestLoanDto = JsonConvert.DeserializeObject<StaffRequestLoanDto>(objJson);

            FormFileStream formFileStream = new FormFileStream(appSettings,
                                                               Constants.StaffRequestAttachedDocument.FOLDER_LOAN,
                                                               Request.Form.Files);
            formFileStream.Save();
            if (!string.IsNullOrEmpty(formFileStream.FullPath))
            {
                staffRequestLoanDto.PathFileDocument = formFileStream.FullPath;
            }

            var result = await mediator.Send(new UpdateStaffRequestLoanCommand() { StaffRequestLoan = staffRequestLoanDto });

            return Ok(result);
        }

        [HttpGet("getbyid/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await mediator.Send(new GetStaffRequestLoanByIdQuery() { Id = id });

            return Ok(result);
        }

        [HttpGet("getforselect")]
        public async Task<IActionResult> GetForSelect()
        {
            var listTypeStaffRequestforSelect = await mediator.Send(new GetTypeLoanForSelectQuery());

            return Ok(listTypeStaffRequestforSelect);
        }

        [HttpGet("getpdf/{id}")]
        public async Task<IActionResult> GetPdf(int id)
        {
            var result = await mediator.Send(new StaffRequestLoanGeneratePdf() { Id = id });

            return Ok(result);
        }

        [HttpPost("calculatetimeline")]
        public async Task<IActionResult> calculatetimeline()    
        {
            var objJson = Request.Form["data"];
            var staffRequestLoanDto = JsonConvert.DeserializeObject<StaffRequestLoanDto>(objJson);

            if (staffRequestLoanDto.DateLoan == null || staffRequestLoanDto.DateLoan == DateTime.MinValue) {
                staffRequestLoanDto.DateLoan = DateTime.Now.AddDays(appSettings.DaysTimeLine);
            }
            var result = await mediator.Send(new CalculateTimelineCommand() { StaffRequestLoan = staffRequestLoanDto });

            return Ok(result);
        }
    }
}