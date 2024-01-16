using System.Threading.Tasks;
using HumanManagement.Application.StaffRequest.Commands.Create;
using HumanManagement.Application.StaffRequest.Commands.Update;
using HumanManagement.Application.StaffRequest.Queries;
using HumanManagement.Domain.StaffRequest.Dto;
using Microsoft.AspNetCore.Mvc;

namespace HumanManagementApi.Controllers.StaffRequest
{
    public class TypeStaffRequestController : BaseApiController
    {
        [HttpPost("add")]
        public async Task<IActionResult> add(TypeStaffRequestDto typeStaffRequestDto)
        {
            var result = await mediator.Send(new CreateTypeStaffRequestCommand() { TypeStaffRequest = typeStaffRequestDto });

            return Ok(result);
        }

        [HttpPut("edit")]
        public async Task<IActionResult> edit(TypeStaffRequestDto typeStaffRequestDto)
        {
            var result = await mediator.Send(new UpdateTypeStaffRequestCommand() { TypeStaffRequest = typeStaffRequestDto });

            return Ok(result);
        }

        [HttpPost("getlistpagination")]
        public async Task<IActionResult> GetListPagination(TypeStaffRequestQueryFilter typeStaffRequestQueryFilter)
        {
            var list = await mediator.Send(new GetTypeStaffRequestListPaginationQuery() { TypeStaffRequestQueryFilter = typeStaffRequestQueryFilter });

            return Ok(list);
        }

        [HttpGet("getbyid/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var typeStaffRequest = await mediator.Send(new GetTypeStaffRequestByIdQuery() { Id = id });

            return Ok(typeStaffRequest);
        }

        [HttpGet("getforselect")]
        public async Task<IActionResult> GetForSelect()
        {
            var listTypeStaffRequestforSelect = await mediator.Send(new GetTypeStaffRequestForSelectQuery());

            return Ok(listTypeStaffRequestforSelect);
        }

        [HttpGet("getonlyenabled")]
        public async Task<IActionResult> GetOnlyEnabled()
        {
            var listTypeStaffRequestforSelect = await mediator.Send(new GetTypeStaffRequestEnabledQuery());

            return Ok(listTypeStaffRequestforSelect);
        }

    }
}