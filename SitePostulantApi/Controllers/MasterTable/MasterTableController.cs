using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SitePostulant.Application.MasterTable.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SitePostulantApi.Controllers.MasterTable
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasterTableController : BaseApiController
    {
        private readonly IMasterTableService masterTableService;

        public MasterTableController(IMasterTableService masterTableService)
        {
            this.masterTableService = masterTableService;
        }

        [HttpGet("getmastertabletype/{idType}")]
        public async Task<IActionResult> GetEducationPostulant(int idType)
        {

            var result = await masterTableService.GetByIdFather(idType);

            return Ok(result);

        }
        [HttpGet("getmastertabletypepublic/{idType}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetMasterPublic(int idType)
        {

            var result = await masterTableService.GetByIdFather(idType);

            return Ok(result);

        }

        [HttpGet("getCategoryEmploymentpublic")]
        [AllowAnonymous]
        public async Task<IActionResult> GetCategoryEmployment()
        {
            var departament = await masterTableService.GetCategoryEmployment();

            return Ok(departament);
        }

    }
}
