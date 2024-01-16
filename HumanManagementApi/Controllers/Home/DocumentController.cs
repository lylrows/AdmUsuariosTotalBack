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
    public class DocumentController : BaseApiController
    {
        private readonly IDocumentService documentService;
        private readonly AppSettings _appSettings;
        public DocumentController(IDocumentService documentService, 
                                    IOptions<AppSettings> appSettings)
        {
            this.documentService = documentService;
            _appSettings = appSettings.Value;
        }

        [HttpGet("get")]
        public async Task<IActionResult> Get()
        {
            var result = await mediator.Send(new GetAllDocumentQuery());
            return result == null ? NotFound() : (IActionResult)Ok(result);
        }
        [HttpGet("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var dtoGet = documentService.GetById(id).Result;
            dtoGet.Active = false;
            await documentService.Update(dtoGet);
            return Ok();
        }
        [HttpGet("getById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await documentService.GetById(id);
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
            var filenamefolder = folder + "Document\\";
            var dto = JsonConvert.DeserializeObject<DocumentDto>(dtoRequest);
            dto.Filename = file.FileName;
            dto.Filenamefolder = filenamefolder;
            dto.UserRegister = 1;

            if (!Directory.Exists(filenamefolder))
            {
                Directory.CreateDirectory(filenamefolder);
            }

            await documentService.Add(dto);
            var dtoUpdate = mediator.Send(new GetAllDocumentQuery()).Result.OrderBy(x=>x.Id).Last();
            var newfilename = dtoUpdate.Id + "-" + file.FileName;
            var pathDocument = filenamefolder + newfilename;
            using (var stream = new FileStream(pathDocument, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            dtoUpdate.UserUpdate = 1;
            dtoUpdate.Filename = newfilename;
            dtoUpdate.Filenamefolder = _appSettings.UrlFile + "Document/";
            await documentService.Update(dtoUpdate);

            return Ok();
        }
        [HttpPost("edit")]
        public async Task<IActionResult> Edit()
        {
            var dtoRequest = Request.Form["dtoRequest"];

            var dto = JsonConvert.DeserializeObject<DocumentDto>(dtoRequest);
            var dtoGet = documentService.GetById(dto.Id);
            var dtoUpdate = dtoGet.Result;
            if (Request.Form.Files.Count == 0)
            {
                dtoUpdate.UserUpdate = 1;
                dtoUpdate.IdCompany = dto.IdCompany;
                dtoUpdate.IdCategory = dto.IdCategory;
                dtoUpdate.IdSubCategory = dto.IdSubCategory;
                dtoUpdate.UserUpdate = 1;
                dtoUpdate.Active = dto.Active;
                dtoUpdate.Description = dto.Description;
                await documentService.Update(dtoUpdate);
                return Ok();
            }
            var file = Request.Form.Files[0];

            var folder = _appSettings.PathSaveFile;
            var filenamefolder = folder + "Document\\";

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

                dtoUpdate.IdCompany = dto.IdCompany;
                dtoUpdate.IdCategory = dto.IdCategory;
                dtoUpdate.IdSubCategory = dto.IdSubCategory;
                dtoUpdate.UserUpdate = 1;
                dtoUpdate.Filename = newfilename;
                dtoUpdate.Active = dto.Active;
                dtoUpdate.Description = dto.Description;
                dtoUpdate.Filenamefolder = _appSettings.UrlFile + "Document/";
                await documentService.Update(dtoUpdate);
            }

            return Ok();
        }
        [HttpPost("getlistpagination")]
        public async Task<IActionResult> GetListPagination([FromBody] DocumentQueryFilter dto)
        {
            var result = await mediator.Send(new GetDocumentQuery() { documentQueryFilter = dto });
            return result.Data == null ? NotFound() : (IActionResult)Ok(result);
        }

    }
}
