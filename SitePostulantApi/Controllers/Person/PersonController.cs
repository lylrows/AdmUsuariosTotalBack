using HumanManagement.Domain.Postulant.Person.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SitePostulant.Application.Person.IServices;
using System.Threading.Tasks;

namespace SitePostulantApi.Controllers.Person
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : BaseApiController
    {
        private readonly IPersonService personService;
        public PersonController(IPersonService personService)
        {
            this.personService = personService;
        }

        [HttpPost("uploadimg")]
        public async Task<IActionResult> UploadImg()
        {
            var dtoRequest = Request.Form["request"];
            var file = Request.Form.Files[0];
            var dto = JsonConvert.DeserializeObject<PersonCvDto>(dtoRequest);

            var result = await personService.SaveImg(dto, file);
            return Ok(result);
        }
        
        [HttpGet("getperson/{idPerson}")]
        public async Task<IActionResult> GetPerson(int idPerson)
        {
            var result = await personService.GetById(idPerson);

            return Ok(result);
        }

        [HttpPost("uploadcv")]
        public async Task<IActionResult> UploadCv()
        {
            var dtoRequest = Request.Form["request"];
            var file = Request.Form.Files[0];
            var dto = JsonConvert.DeserializeObject<PersonCvDto>(dtoRequest);

            var result = await personService.SaveCv(dto, file);
            return Ok(result);
        }
        
        [HttpPatch("updatepersoninformation")]
        public async Task<IActionResult> UpdatePersonInformation(PersonDto personDto)
        {
            var result = await personService.UpdatePersonalInformation(personDto);

            return Ok(result);
        }

        [HttpPatch("updatecontactinformation")]
        public async Task<IActionResult> UpdateContactInformation(PersonDto personDto)
        {
            var result = await personService.UpdateContactInformation(personDto);

            return Ok(result);
        }

        [HttpGet("deletecv/{idPerson}")]
        public async Task<IActionResult> DeleteCv(int idPerson)
        {
            var result = await personService.DeleteCv(idPerson);

            return Ok(result);
        }
    }
}
