using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using HumanManagement.Domain.MasterTable.Dto;
using HumanManagement.Application.MasterTable.Commands.Create;
using HumanManagement.Application.MasterTable.Commands.Delete;
using HumanManagement.Application.MasterTable.Queries;
using Microsoft.AspNetCore.Authorization;

namespace HumanManagementApi.Controllers.MasterTable
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasterTableController : BaseApiController
    {
        [HttpGet("getByIdFather/{id}/{idType}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetByIdFather(int id, int idType = 0)
        {
            var result = await mediator.Send(new GetByIdMasterTableQuery() { nid_father = id, nid_type = idType });

            return Ok(result);
            
        }
        
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] MasterTableDto dto)
        {
            var result = await mediator.Send(new CreateMasterTableCommand() { masterTableDto = dto });
            return new OkObjectResult(result);
        }
        [HttpPost("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await mediator.Send(new DeleteMasterTableCommand() { Id = id });
            return new OkObjectResult(result);
        }
    }
}
