using HumanManagement.Application.Mof.Queries;
using HumanManagement.Domain.Mof.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagementApi.Controllers.Mof
{
    public class MofController : BaseApiController
    {

        [HttpPost("getmofdetailprof")]
        [AllowAnonymous]
        public async Task<IActionResult> GetMofDetailProf([FromBody] MofFilter filter)
        {

            var listUser = await mediator.Send(new GetMofDetailProfQuery() { filter = filter });

            return Ok(listUser);
        }
    }
}
