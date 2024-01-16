using System.Threading.Tasks;
using HumanManagement.Application.Recruitment.Queries;
using Microsoft.AspNetCore.Mvc;

namespace HumanManagementApi.Controllers.Recruitment
{
    public class RecruitmentAreaController : BaseApiController
    {
        [HttpGet("getlistforselect")]
        public async Task<IActionResult> GetListForSelect()
        {
            var listArea = await mediator.Send(new RecruitmentAreaGetForSelectQuery());

            return Ok(listArea);
        }
    }
}