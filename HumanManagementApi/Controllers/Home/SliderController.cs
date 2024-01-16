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
    public class SliderController : BaseApiController
    {
        private readonly ISliderService sliderService;
        private readonly AppSettings _appSettings;
        public SliderController(ISliderService sliderService, 
                                IOptions<AppSettings> appSettings)
        {
            this.sliderService = sliderService;
            _appSettings = appSettings.Value;
        }
        [HttpPost("add")]
        public async Task<IActionResult> Add()
        {
            var dtoRequest = Request.Form["dtoRequest"];
            var file = Request.Form.Files[0];
            var folder = _appSettings.PathSaveFile;
            var filenamefolder = folder + "Slider\\";
            var dto = JsonConvert.DeserializeObject<SliderDto>(dtoRequest);
            dto.Filename = file.FileName;
            dto.Filenamefolder = filenamefolder;
            dto.UserRegister = 1;
            if (!Directory.Exists(filenamefolder))
            {
                Directory.CreateDirectory(filenamefolder);
            }
            
            await sliderService.Add(dto);
            var dtoUpdate = sliderService.GetAll().Result.Last();
            var newfilename = dtoUpdate.Id + "-" + file.FileName;
            var pathDocument = filenamefolder + newfilename;
            using (var stream = new FileStream(pathDocument, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            
            dtoUpdate.UserUpdate = 1;
            dtoUpdate.Filename = newfilename;
            dtoUpdate.Filenamefolder = _appSettings.UrlFile +"Slider/";
            await sliderService.Update(dtoUpdate);

            return Ok();
        }
        [HttpPost("edit")]
        public async Task<IActionResult> Edit()
        {
            var dtoRequest = Request.Form["dtoRequest"];
            
            var dto = JsonConvert.DeserializeObject<SliderDto>(dtoRequest);
            var dtoGet = sliderService.GetById(dto.Id);
            var dtoUpdate = dtoGet.Result;
            if (Request.Form.Files.Count==0)
            {
                dtoUpdate.IdType = dto.IdType;
                dtoUpdate.UserUpdate = 1;
                dtoUpdate.Active = dto.Active;
                dtoUpdate.Order = dto.Order;
                dtoUpdate.UrlImage = dto.UrlImage;
                await sliderService.Update(dtoUpdate);
                return Ok();
            }
            var file = Request.Form.Files[0];
            
            var folder = _appSettings.PathSaveFile;
            var filenamefolder = folder + "Slider\\";
            
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

                dtoUpdate.IdType = dto.IdType;
                dtoUpdate.UserUpdate = 1;
                dtoUpdate.Filename = newfilename;
                dtoUpdate.Active = dto.Active;
                dtoUpdate.Order = dto.Order;
                dtoUpdate.IsImage = dto.IsImage;
                dtoUpdate.UrlImage = dto.UrlImage;
                dtoUpdate.Filenamefolder = _appSettings.UrlFile + "Slider/";
                await sliderService.Update(dtoUpdate);
            }
            
            return Ok();
        }

        [HttpGet("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var dtoGet = sliderService.GetById(id).Result;
            dtoGet.Active = false;
            await sliderService.Update(dtoGet);
            return Ok();
        }
        [HttpGet("getById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await sliderService.GetById(id);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("get")]
        public async Task<IActionResult> Get()
        {
            var result = await sliderService.GetAll();
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
        public async Task<IActionResult> GetListPagination([FromBody] SliderQueryFilter dto)
        {
            var result = await mediator.Send(new GetSliderQuery() { sliderQueryFilter = dto });
            return result.Data == null ? NotFound() : (IActionResult)Ok(result);
        }

    }
}
