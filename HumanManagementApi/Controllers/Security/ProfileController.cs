using System.Threading.Tasks;
using HumanManagement.Application.Security.Queries;
using Microsoft.AspNetCore.Mvc;

namespace HumanManagementApi.Controllers.Security
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : BaseApiController
    {
        [HttpGet("getprofilelist")]
        public async Task<IActionResult> GetProfile()
        {
            var result = await mediator.Send(new GetListPerfilQuery());

            return Ok(result);
        }

    }
}