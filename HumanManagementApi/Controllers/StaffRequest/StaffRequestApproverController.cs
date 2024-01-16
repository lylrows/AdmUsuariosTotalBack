using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HumanManagement.Application.StaffRequest.Commands.Create;
using HumanManagement.Application.StaffRequest.Queries;
using HumanManagement.Domain.StaffRequest.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HumanManagementApi.Controllers.StaffRequest
{
    public class StaffRequestApproverController : BaseApiController
    {
        [HttpGet("getlistbyid/{id}")]
        public async Task<IActionResult> GetListById(int id)
        {
            var list = await mediator.Send(new GetListStaffRequestApproverQuery() { IdStaffRequest = id });

            return Ok(list);
        }

        [HttpGet("getaccsess/{id}")]
        public async Task<IActionResult> GetAccessApprover(int id)
        {
            var list = await mediator.Send(new GetApproverAccessQuery() { IdStaffRequest = id });

            return Ok(list);
        }

        [HttpPost("approve")]
        public async Task<IActionResult> approve(StaffRequestApproverDto staffRequestApproverDto)
        {
            var result = await mediator.Send(new ApproveStaffRequestCommand() { StaffRequestApprover = staffRequestApproverDto });

            return Ok(result);
        }
         
        [HttpPost("reject")]
        public async Task<IActionResult> Reject(StaffRequestApproverDto staffRequestApproverDto)
        {
            var result = await mediator.Send(new RejectStaffRequestCommand() { StaffRequestApprover = staffRequestApproverDto });

            return Ok(result);
        }
    }
}