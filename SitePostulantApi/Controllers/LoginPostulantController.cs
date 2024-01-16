using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.Postulant.Security.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SitePostulant.Application.Security.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SitePostulantApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginPostulantController : BaseApiController
    {
        private readonly AppSettings _appSettings;
        private readonly ILoginService loginService;
        public LoginPostulantController(IOptions<AppSettings> appSettings, ILoginService loginService)
        {
            this.loginService = loginService;
        }

        [HttpPost("authenticate")]
        [AllowAnonymous]
        public async Task<IActionResult> Authenticate([FromBody] LoginDto loginDto)
        {
            var profileUser = await loginService.GetLoginUserQuery(loginDto);
            return Ok(profileUser);
        }
    }
}
