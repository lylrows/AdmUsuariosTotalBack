using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SitePostulant.Application.RecruitmentArea.IServices;

using System.Threading.Tasks;

namespace SitePostulantApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecruitmentAreaController : BaseApiController
    {
        private readonly IRecruitmentAreaService _recruitmentAreaService;

        public RecruitmentAreaController(IRecruitmentAreaService recruitmentAreaService)
        {

            this._recruitmentAreaService= recruitmentAreaService;
        }

        [HttpGet("getall/{idEmpresa}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll(int idEmpresa)
        {
            var result = await _recruitmentAreaService.GetAll(idEmpresa);

            return Ok(result);
        }

        
    }
}
