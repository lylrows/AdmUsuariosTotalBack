using HumanManagement.Application.Person.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HumanManagementApi.Controllers.Person
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : BaseApiController
    {
        [HttpGet("{Id}")]
        public async Task<IActionResult> getPerson(int Id)
        {
            var person = await mediator.Send(new GetPersonQuery() { Id = Id });

            return Ok(person);
        }

        [HttpGet("Phone/{Id}")]
        public async Task<IActionResult> GetListPhone(int Id)
        {
            var listphone = await mediator.Send(new GetListPhoneByPersonQuery() { Id = Id });

            return Ok(listphone);
        }
    }
}
