using HumanManagement.Application.Contact.Commands.Delete;
using HumanManagement.Application.Contact.IServices;
using HumanManagement.Application.Contact.Queries;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.Contact.Dto;
using HumanManagement.Domain.Contact.QueryFilter;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace HumanManagementApi.Controllers.Contact
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : BaseApiController
    {
        private readonly IContactService contactService;
        private readonly AppSettings _appSettings;

        public ContactController(IContactService contactService, IOptions<AppSettings> appSettings)
        {
            this.contactService = contactService;
            _appSettings = appSettings.Value;
        }

        [HttpGet("get")]
        public async Task<IActionResult> Get()
        {
            var result = await contactService.GetAll();
            if (result != null)
            {
                return Ok(result);

            }
            else
            {
                return NotFound();
            }
        }
        [HttpGet("getAllActive")]
        public async Task<IActionResult> GetAllActive()
        {
            var result = await contactService.GetAll();
            if (result != null)
            {
                return Ok(result.Where(i=>i.Active));

            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] ContactDto dto)
        {
            await contactService.Add(dto);
            return Ok();
        }

        [HttpPost("edit")]
        public async Task<IActionResult> Edit([FromBody] ContactDto dto)
        {
            await contactService.Update(dto);
            return Ok();
        }

        [HttpPost("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await mediator.Send(new DeleteContactCommand() { Id = id });
            return new OkObjectResult(result);
        }



        [HttpGet("getById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await contactService.GetById(id);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost("getlistpagination")]
        public async Task<IActionResult> GetListPagination([FromBody] ContactQueryFilter dto)
        {
            var listUser = await mediator.Send(new GetListContactsPaginationQuery() { contactQueryFilter = dto });

            return Ok(listUser);
        }

        [HttpPost("UploadFile")]
        public async Task<ActionResult> UploadFile()
        {
            string fullPath = string.Empty;
            try
            {
                var objJson = Request.Form["data"];
                ContactDto contactoDto = JsonConvert.DeserializeObject<ContactDto>(objJson);
                if (contactoDto.Id_Employee==0)
                {
                    if (Request.Form.Files.Count() > 0)
                    {
                        var file = Request.Form.Files[0];
                        string folderName = "Imagenes";
                        var folder = _appSettings.PathSaveFile;
                        var filenamefolder = folder + "Imagenes\\";
                        string newPath = filenamefolder;
                        if (!Directory.Exists(newPath))
                        {
                            Directory.CreateDirectory(newPath);
                        }
                        string ext = Path.GetExtension(ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"'));
                        string fileName = string.Format("{0}{1}", Path.GetRandomFileName(), ext);
                        fullPath = Path.Combine(newPath, fileName);
                        using (var stream = new FileStream(fullPath, FileMode.Create))
                        {
                            file.CopyTo(stream);
                        }
                        contactoDto.Photo_url = _appSettings.UrlFile + "Imagenes\\" + fileName;
                    }
                }
                
                if (contactoDto.Id == 0)
                {
                    await contactService.Add(contactoDto);
                }
                else {
                    await contactService.Update(contactoDto);
                }
                return Ok();
            }
            catch (System.Exception ex)
            {
                if (System.IO.File.Exists(fullPath))
                {
                    System.IO.File.Delete(fullPath);
                }
                return StatusCode(500);
            }
            
        }

    }
}
