using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using HumanManagement.Application.NineBox.Queries;
using HumanManagement.Domain.NineBox.Dto;
using HumanManagement.Application.NineBox.Commands.Edit;
using HumanManagement.Domain.NineBox.QueryFilter;

namespace HumanManagementApi.Controllers.NineBox
{
    [Route("api/[controller]")]
    [ApiController]
    public class NineBoxController : BaseApiController
    {
        [HttpPost("getAll")]
        public async Task<IActionResult> GetAll(NineBoxQueryFilter dto)
        {
            var ninebox = await mediator.Send(new GetAllNineBoxQuery() { nineBoxQueryFilter=dto});
            return ninebox.Data == null ? NotFound() : (IActionResult)Ok(ninebox);
        }

        [HttpPost("edit")]
        public async Task<IActionResult> Edit( NineBoxDto dto)
        {
            var result = await mediator.Send(new EditNineBoxCommand() { nineBoxDto = dto });
            return new OkObjectResult(result);
        }



    }
   
}
