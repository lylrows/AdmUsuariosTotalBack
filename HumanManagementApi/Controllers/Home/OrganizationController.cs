using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using HumanManagement.Application.Home.IServices;
using HumanManagement.Domain.Home.Dto;
using System.IO;
using Newtonsoft.Json;
using HumanManagement.CrossCutting.Utils;
using Microsoft.Extensions.Options;
using HumanManagement.Domain.Home.QueryFilter;
using HumanManagement.Application.Home.Queries;

namespace HumanManagementApi.Controllers.Home
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationController : BaseApiController
    {
        private readonly IOrganizationService organizationService;
        private readonly AppSettings _appSettings;
        public OrganizationController(IOrganizationService organizationService, 
                                        IOptions<AppSettings> appSettings)
        {
            this.organizationService = organizationService;
            _appSettings = appSettings.Value;
        }
        [HttpGet("get")]
        public async Task<IActionResult> Get()
        {
            var result = await organizationService.GetAll();
            if (result != null)
            {
                return Ok(result);

            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var dtoGet = organizationService.GetById(id).Result;
            dtoGet.Active = false;
            await organizationService.Update(dtoGet);
            return Ok();
        }
        [HttpGet("getById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await organizationService.GetById(id);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add()
        {
            var dtoRequest = Request.Form["dtoRequest"];
            var file = Request.Form.Files[0];
            var folder = _appSettings.PathSaveFile;
            var filenamefolder = folder + "Organization\\";
            var dto = JsonConvert.DeserializeObject<OrganizationDto>(dtoRequest);
            
            dto.Filename = file.FileName;
            dto.Filenamefolder = filenamefolder;
            dto.UserRegister = 1;
            
            if (!Directory.Exists(filenamefolder))
            {
                Directory.CreateDirectory(filenamefolder);
            }

            await organizationService.Add(dto);
            var dtoUpdate = organizationService.GetAll().Result.Last();
            var newfilename = dtoUpdate.Id + "-" + file.FileName;
            var pathDocument = filenamefolder + newfilename;
            using (var stream = new FileStream(pathDocument, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            dtoUpdate.UserUpdate = 1;
            dtoUpdate.Filename = newfilename;
            dtoUpdate.Filenamefolder = _appSettings.UrlFile + "Organization/";
            await organizationService.Update(dtoUpdate);

            return Ok();
        }
        [HttpPost("edit")]
        public async Task<IActionResult> Edit()
        {
            var dtoRequest = Request.Form["dtoRequest"];

            var dto = JsonConvert.DeserializeObject<OrganizationDto>(dtoRequest);
            var dtoGet = organizationService.GetById(dto.Id);
            var dtoUpdate = dtoGet.Result;
            if (Request.Form.Files.Count == 0)
            {
                dtoUpdate.UserUpdate = 1;
                dtoUpdate.Active = dto.Active;
                dtoUpdate.Description = dto.Description;
                dtoUpdate.Title = dto.Title;
                await organizationService.Update(dtoUpdate);
                return Ok();
            }
            var file = Request.Form.Files[0];

            var folder = _appSettings.PathSaveFile;
            var filenamefolder = folder + "Organization\\";

            if (!Directory.Exists(filenamefolder))
            {
                Directory.CreateDirectory(filenamefolder);
            }

            if (file != null)
            {
                var newfilename = dtoUpdate.Id + "-" + file.FileName;
                var pathDocument = filenamefolder + newfilename;
                using (var stream = new FileStream(pathDocument, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                dtoUpdate.UserUpdate = 1;
                dtoUpdate.Filename = newfilename;
                dtoUpdate.Active = dto.Active;
                dtoUpdate.Description = dto.Description;
                dtoUpdate.Title = dto.Title;
                dtoUpdate.Filenamefolder = _appSettings.UrlFile + "Organization/";
                await organizationService.Update(dtoUpdate);
            }

            return Ok();

            
        }
        [HttpPost("getlistpagination")]
        public async Task<IActionResult> GetListPagination([FromBody] OrganizationQueryFilter dto)
        {
            var result = await mediator.Send(new GetOrganizationQuery() { organizationQueryFilter = dto });
            return result.Data == null ? NotFound() : (IActionResult)Ok(result);
        }

    }
}
