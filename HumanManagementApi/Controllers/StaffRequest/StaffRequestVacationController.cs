using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HumanManagement.Application.StaffRequest.Commands.Create;
using HumanManagement.Application.StaffRequest.GeneratePdf;
using HumanManagement.Application.StaffRequest.Queries;
using HumanManagement.Domain.StaffRequest.Dto;
using HumanManagement.Domain.WindowsService.Exactus.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace HumanManagementApi.Controllers.StaffRequest
{
    public class StaffRequestVacationController : BaseApiController
    {
        public StaffRequestVacationController()
        {
        }
        [HttpPost("add")]
        public async Task<IActionResult> add(StaffRequestVacationDto staffRequestVacationDto)
        {
            var result = await mediator.Send(new CreateStaffRequestVacationCommand() { StaffRequestVacation = staffRequestVacationDto });
            return Ok(result);
        }

        [HttpGet("getbyid/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await mediator.Send(new GetStaffRequestVacationByIdQuery() { Id = id });

            return Ok(result);
        }

        [HttpGet("getpdf/{id}")]
        public async Task<IActionResult> GetPdf(int id)
        {
            var result = await mediator.Send(new StaffRequestVacationGeneratePdf() { Id = id });

            return Ok(result);
        }

        [HttpPost("getvacationday")]
        public async Task<IActionResult> GetVacationDay(VacationDayCalculatorFilter vacationDayCalculatorFilter)
        {
            var result = await mediator.Send(new GetVacationDayCalculatorQuery() { VacationDayCalculatorFilter = vacationDayCalculatorFilter });

            return Ok(result);
        }

        [HttpPost("getvacationsdays")]
        public async Task<IActionResult> GetVacationDay(RequestExactusDiasVacacionesDto _request)
        {
            var result = await mediator.Send(new GetVacationsDaysQuery() { scode_employee = _request.scode_employee, idcompany = _request.idcompany });

            return Ok(result);
        }
    }
}