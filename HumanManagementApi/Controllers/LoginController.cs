using System.Threading.Tasks;
using HumanManagement.Application.Security.Queries;
using HumanManagement.Domain.Security.Dto;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HumanManagementApi.Controllers
{
    public class LoginController : BaseApiController
    {
        [HttpPost("authenticate")]
        [AllowAnonymous]
        public async Task<IActionResult> Authenticate([FromBody] LoginDto loginDto)
        {
            var profileUser = await mediator.Send(new GetLoginUserQuery() {Login = loginDto });
            return Ok(profileUser);
        }

    }
}
