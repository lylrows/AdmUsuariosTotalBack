using HumanManagement.Application.HMExactus.Queries;
using HumanManagement.Application.InformationPostulant.Command;
using HumanManagement.Application.InformationPostulant.Queries;
using HumanManagement.Domain.Postulant.Person.Dto;
using Microsoft.AspNetCore.Mvc;

using System.Threading.Tasks;

namespace HumanManagementApi.Controllers.InformationPostulant
{

    [Route("api/[controller]")]
    [ApiController]
    public class PostulantFileController : BaseApiController
    {
        

        [HttpGet("getexactusbank")]
        public async Task<IActionResult> GetExactusBank()
        {
            var result = await mediator.Send(new GetHMExactusBankQuery() { });

            return Ok(result);
        }

        [HttpGet("getexactusafp")]
        public async Task<IActionResult> GetExactusAfp()
        {
            var result = await mediator.Send(new GetHMExactusAfpQuery() { });

            return Ok(result);
        }

        [HttpGet("getexactuslocation")]
        public async Task<IActionResult> GetExactusLocation()
        {
            var result = await mediator.Send(new GetHMExactusLocationQuery() { });

            return Ok(result);
        }
        [HttpGet("getexactuspayroll")]
        public async Task<IActionResult> GetExactusPayroll()
        {
            var result = await mediator.Send(new GetHMExactusPayrollQuery() { });

            return Ok(result);
        }


        [HttpGet("getinfopersonexactus/{id}")]
        public async Task<IActionResult> GetInfoPersonExactus(int id)
        {
            var result = await mediator.Send(new GetInformationExactusQuery() { IdPerson = id });

            return Ok(result);
        }

        [HttpPost("save")]
        public async Task<IActionResult> Save(PersonExactusDto dto)
        {
            var result = await mediator.Send(new SaveInformationExactusCommand() { dto = dto });

            return Ok(result);
        }

        [HttpPost("sendinfoexactus")]
        public async Task<IActionResult> SendInfoExactus(SendExactusDto dto)
        {
            var result = await mediator.Send(new SendInfoToExactusCommand() { nid_evaluation = dto.nid_evaluation,nid_person = dto.nid_person});

            return Ok(result);
        }

    }
}
