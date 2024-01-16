using DocumentFormat.OpenXml.Office2010.Excel;
using HumanManagement.Application.InformationPostulant.Command;
using HumanManagement.Application.InformationPostulant.Queries;
using HumanManagement.Application.Utils.Queries;
using HumanManagement.Domain.InformationPostulant.Dto;
using HumanManagement.Domain.Utils.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HumanManagementApi.Controllers.InformationPostulant
{
    [Route("api/[controller]")]
    [ApiController]
    public class InformationPostulantController : BaseApiController
    {
        [HttpGet("getinfoperson/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetInfoPerson(int id)
        {
            var result = await mediator.Send(new GetInformationPersonQuery() { IdPerson = id });

            return Ok(result);
        }

        [HttpGet("getinfoall/{id}/{idEvaluation}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetInfoAll(int id, int idEvaluation)
        {
            var result = await mediator.Send(new GetInformationRegisterPostulantQuery() { IdPerson = id, IdEvaluation = idEvaluation });

            return Ok(result);
        }

        [HttpGet("getinfoallbyperson/{id}/")]
        [AllowAnonymous]
        public async Task<IActionResult> GetInfoAllByPerson(int id)
        {
            var result = await mediator.Send(new GetInformation2RegisterPostulantQuery() { IdPerson = id });

            return Ok(result);
        }

        [HttpPost("save")]
        [AllowAnonymous]
        public async Task<IActionResult> Save(InformationPostulantAllDto dto)
        {
            var result = await mediator.Send(new SaveInformationPostulantCommand() { dtos = dto });

            return Ok(result);
        }

        [HttpPost("saveaditionaldocuments")]
        [AllowAnonymous]
        public async Task<IActionResult> SaveAditionalDocuments(List<DocumentoAdicional> dto)
        {
            var result = await mediator.Send(new SaveInformationPostulantDocAditionalCommand() { dtos = dto });

            return Ok(result);
        }

        [HttpPost("saveinformationfamily")]
        [AllowAnonymous]
        public async Task<IActionResult> SaveInformationFamily(InformationFamilyDto dto)
        {
            var result = await mediator.Send(new SaveInformationFamilyPostulantCommand() { dto = dto });

            return Ok(result);
        }

        [HttpPost("saveinformationeducation")]
        [AllowAnonymous]
        public async Task<IActionResult> SaveInformationEducation(InformationEducationDto dto)
        {
            var result = await mediator.Send(new SaveInformationEducationPostulantCommand() { dtos = dto });

            return Ok(result);
        }
        [HttpPost("saveinformationwork")]
        [AllowAnonymous]
        public async Task<IActionResult> SaveInformationWork(InformationWorkDto dto)
        {
            var result = await mediator.Send(new SaveInformationWorkPostulantCommand() { dto = dto });

            return Ok(result);
        }

        [HttpPost("saveinformationlang")]
        [AllowAnonymous]
        public async Task<IActionResult> SaveInformationLang(InformationLangDto dto)
        {
            var result = await mediator.Send(new SaveInformationLangPostulantCommand() { dto = dto });

            return Ok(result);
        }

        [HttpPost("saveinformationskills")]
        [AllowAnonymous]
        public async Task<IActionResult> SaveInformationSkills(InformationComputerSkillsDto dto)
        {
            var result = await mediator.Send(new SaveInformationSkillsPostulantCommand() { dto = dto });

            return Ok(result);
        }

        [HttpGet("getinfoeducation/{id}/{idEvaluation}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetInfoEducation(int id, int idEvaluation)
        {
            var result = await mediator.Send(new GetInformationEducationPostulantQuery() { IdPerson = id, IdEvaluation = idEvaluation });

            return Ok(result);
        }

        [HttpGet("getinfowork/{id}/{idEvaluation}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetInfoWork(int id, int idEvaluation)
        {
            var result = await mediator.Send(new GetInformationWorkPostulantQuery() { IdPerson = id, IdEvaluation = idEvaluation });

            return Ok(result);
        }

        [HttpGet("getinfofamily/{id}/{idEvaluation}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetInfoFamily(int id, int idEvaluation)
        {
            var result = await mediator.Send(new GetInformationFamilyPostulantQuery() { IdPerson = id, IdEvaluation = idEvaluation });

            return Ok(result);
        }

        [HttpGet("getinfolang/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetInfoLang(int id)
        {
            var result = await mediator.Send(new GetInformationLangPostulantQuery() { IdPerson = id });

            return Ok(result);
        }

        [HttpGet("getinfoskills/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetInfoSkills(int id)
        {
            var result = await mediator.Send(new GetInformationSkillsPostulantQuery() { IdPerson = id });

            return Ok(result);
        }

        [HttpPost("saveinformationfiles")]
        [AllowAnonymous]
        public async Task<IActionResult> SaveInformationFiles(InformationFilesDto dto)
        {           
            var result = await mediator.Send(new GetSaveFiletQuery() { param = dto });
            return Ok(result);
        }

        
        [HttpPost("savepostulantrequest")]
        [AllowAnonymous]
        public async Task<IActionResult> SavePostulantRequest(InformationPostulantRequest dto)
        {
            var result = await mediator.Send(new SaveInformationPostulantRequestCommand() { dto = dto });
            return Ok(result);
        }

        [HttpPost("getpostulantrequest")]
        [AllowAnonymous]
        public async Task<IActionResult> GetPostulantRequest(FilterInformationPostulantRequest dto)
        {
            var result = await mediator.Send(new GetformationPostulantRequestQuery() { dto = dto });
            return Ok(result);
        }

        
        [HttpPost("saveinformationinternalexactus")]
        [AllowAnonymous]
        public async Task<IActionResult> SaveInformationInternalExactus(InformationExactusInternalDto dto)
        {
            var result = await mediator.Send(new SaveInformationInternalExactusCommand() { dto = dto });
            return Ok(result);
        }

        [HttpPost("getinformationinternalexactus")]
        [AllowAnonymous]
        public async Task<IActionResult> GetInformationInternalExactus(FilterInformationExactusInternalDto dto)
        {
            var result = await mediator.Send(new GetInformationInternalExactusQuery() { dto = dto });
            return Ok(result);
        }

    }
}
