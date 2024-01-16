using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SitePostulant.Application.Util.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SitePostulantApi.Controllers.Utils
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtilsController : BaseApiController
    {
        private readonly IUtilService utilService;
        public UtilsController(IUtilService utilService)
        {
            this.utilService = utilService;
        }

        [HttpGet("departament")]
        public async Task<IActionResult> GetDepartament()
        {
            var departament = await utilService.GetDepartament();

            return Ok(departament);
        }

        [HttpGet("province/{Id}")]
        public async Task<IActionResult> GetProvince(int Id)
        {
            var province = await utilService.GetProvince(Id);

            return Ok(province);
        }

        [HttpGet("district/{Id}")]
        public async Task<IActionResult> GetDistrict(int Id)
        {
            var district = await utilService.GetDistrict(Id);

            return Ok(district);
        }
    }
}
