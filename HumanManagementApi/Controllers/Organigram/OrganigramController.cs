using HumanManagement.Application.Organigram.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HumanManagementApi.Controllers.Organigram
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganigramController : BaseApiController
    {
        [HttpGet("getorganigram/{idEmpresa}")]
        public async Task<IActionResult> GetOrganigram(int idEmpresa)
        {
            var organigram = await mediator.Send(new GetOrganigramQuery() { IdEmpresa = idEmpresa});

            return Ok(organigram);
        }

        [HttpGet("getorganigramcargo/{idArea}/{idEmpresa}/{idCargo}")]
        public async Task<IActionResult> GetOrganigramCargo(int idArea, int idEmpresa, int idCargo)
        {
            var organigram = await mediator.Send(new GetOrganigramCargoQuery() { IdArea= idArea, IdEmpresa = idEmpresa, IdCargo = idCargo});

            return Ok(organigram);
        }

        [HttpGet("getorganigramv2/{idEmpresa}")]
        public async Task<IActionResult> GetOrganigramV2(int idEmpresa)
        {
            var organigram = await mediator.Send(new GetOrganigramV2Query() { IdEmpresa = idEmpresa });

            return Ok(organigram);
        }
    }
}
