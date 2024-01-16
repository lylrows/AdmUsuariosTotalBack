using HumanManagement.Application.Empresa.Queries;
using HumanManagement.Application.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HumanManagementApi.Controllers.Empresa
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : BaseApiController
    {
        protected readonly SessionManager sessionManager;

        public EmpresaController(SessionManager sessionManager)
        {
            this.sessionManager = sessionManager;
        }
        [HttpGet("getempresas")]
        public async Task<IActionResult> GetEmpresas()
        {
            var organigram = await mediator.Send(new GetEmpresaQuery());

            return Ok(organigram);
        }


        [HttpGet("getcompanybyuser")]
        public async Task<IActionResult> GetCompanyByUser()
        {
            int nIdUser = sessionManager.User == null ? 1 : sessionManager.User.IdUser;

            var campaign = await mediator.Send(new GetEmpresaByUserQuery() { IdUser = nIdUser });

            return Ok(campaign);
        }
    }
}
