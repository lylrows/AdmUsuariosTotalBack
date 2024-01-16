using HumanManagement.Application.Proficiency.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagementApi.Controllers.Proficiency
{
    public class ProficiencyController : BaseApiController
    {

        [HttpGet("getdropdownlist")]
        [AllowAnonymous]
        public async Task<IActionResult> GetDropDownList()
        {

            var dropdownlist = await mediator.Send(new GetProficiencyComboQuery() { });

            return Ok(dropdownlist);

        }

        [HttpGet("getlistcompetences")]
        [AllowAnonymous]
        public async Task<IActionResult> getlistcompetences()
        {

            var dropdownlist = await mediator.Send(new GetListCompetencesQuery() { });

            return Ok(dropdownlist);

        }
    }
}
