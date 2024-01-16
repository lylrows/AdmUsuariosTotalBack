using HumanManagement.Application.EvaluationPostulantsInternal.Command;
using HumanManagement.Application.EvaluationPostulantsInternal.Queries;

using HumanManagement.CrossCutting.Utils;

using HumanManagement.Domain.EvaluationPostulantInternal.Dto;
using HumanManagement.Domain.EvaluationPostulantInternal.QueryFilter;
using HumanManagement.Domain.InformationPostulant.Dto;
using HumanManagement.Domain.Utils.Dto;

using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using EvaluationPostulantDto = HumanManagement.Domain.EvaluationPostulantInternal.Dto.EvaluationPostulantDto;

namespace HumanManagementApi.Controllers.EvaluationPostulantInternal
{
    [Route("api/[controller]")]
    [ApiController]
    public class EvaluationPostulantInternalController : BaseApiController
    {
        [HttpPost("createevaluation")]
        public async Task<IActionResult> CreateEvaluation(List<EvaluationPostulantDto> dto)
        {
            var result = await mediator.Send(new CreateEvaluationPostulantsInternalCommand() { Dto = dto });

            return Ok(result);
        }

        [HttpGet("getevaluation/{id}")]
        public async Task<IActionResult> GetEvaluation(int id)
        {
            var result = await mediator.Send(new GetEvaluationQuery() { IdEvaluation = id });

            return Ok(result);
        }

        [HttpGet("getevaluationexport/{id}")]
        public async Task<IActionResult> GetEvaluationExport(int id)
        {
            string fullPath = string.Empty;
            string randmname = "Postulantes_" + DateTime.Now.ToString("ddMMyyyy") + DateTime.Now.ToString("hhmmss") + ".xlsx";
            fullPath = Path.Combine(Directory.GetCurrentDirectory(), "Files", randmname);

            var result = await mediator.Send(new GetListEvaluationExportQuery() { IdEvaluation = id });
            var listPostulants = new List<EvaluationPostulantDto>();
            listPostulants = (List<EvaluationPostulantDto>)result.Data;

            DataTable dt = new DataTable("Postulantes");
            dt.Columns.Add("Nombre");
            dt.Columns.Add("Correo");
            dt.Columns.Add("NroContacto");
            dt.Columns.Add("Estado");

            foreach (var item in listPostulants)
            {
                DataRow row = dt.NewRow();
                row[0] = item.FullNamePostulant;
                row[1] = item.EmailPostulant;
                row[2] = item.PhoneNumberPostulant;
                row[3] = item.DescripcionState;

                dt.Rows.Add(row);

            }

            Functions.DataTableToExcelWithStyle(dt, fullPath);
            Byte[] bytes5 = System.IO.File.ReadAllBytes(fullPath);
            String file5 = Convert.ToBase64String(bytes5);

            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
            }


            return Ok(file5);
        }

        [HttpGet("getidevaluation/{id}")]
        public async Task<IActionResult> GetIdEvaluation(int id)
        {
            var result = await mediator.Send(new GetIdEvaluatioInternQuery() { IdJob = id });

            return Ok(result);
        }

        [HttpPost("getevaluationlist")]
        public async Task<IActionResult> GetEvaluationList(EvaluationInternQueryFilter filter)
        {
            var result = await mediator.Send(new GetEvaluationInterListQuery() { Filter = filter });

            return Ok(result);
        }

        [HttpGet("getinfopostulant/{id}")]
        public async Task<IActionResult> GetInfoPostulant(int id)
        {
            var result = await mediator.Send(new GetInformationPostulantQuery() { IdEvaluationPostulant = id });

            return Ok(result);
        }

        [HttpPost("updatevaluation")]
        public async Task<IActionResult> UpdateEvaluationPostulant()
        {
            var dtoRequest = Request.Form["request"];
            var dto = JsonConvert.DeserializeObject<EvaluationPostulantDto>(dtoRequest);

            var dtoMultitest = Request.Form["multitest"];
            var dtoMulti = JsonConvert.DeserializeObject<List<FactorDto>>(dtoMultitest);
            var result = await mediator.Send(new UpdateEvaluationPostulantInternalCommand() { dto = dto, factorDtos = dtoMulti});

            return Ok(result);
        }

        [HttpPost("updatevaluationprocess")]
        public async Task<IActionResult> UpdateEvaluationCurriculum(EvaluationVacantInternalDto dto)
        {
            var result = await mediator.Send(new UpdateEvaluationProcessInternCommand() { dto = dto });

            return Ok(result);
        }

        [HttpPost("createnotes")]
        public async Task<IActionResult> CreateNotes(NotesEvaluationInternalDto obj)
        {
            var result = await mediator.Send(new CreateNotesEvaluationInternalCommand() { dto = obj });

            return Ok(result);
        }

        [HttpGet("getnotes/{id}")]
        public async Task<IActionResult> GetNotes(int id)
        {
            var result = await mediator.Send(new GetNotesEvaluationInternalQuery() { IdEvaluationPostulant = id });

            return Ok(result);
        }

        [HttpGet("getevaluationposition/{id}")]
        public async Task<IActionResult> GetEvaluationPosition(int id)
        {
            var result = await mediator.Send(new GetEvaluationPostulantPositionQuery() { IdEvaluation = id });

            return Ok(result);
        }

        [HttpGet("getevaluationcurriculum/{id}")]
        public async Task<IActionResult> GetEvaluationCurriculum(int id)
        {
            var result = await mediator.Send(new GetEvaluationPostulantCurriculumQuery() { IdEvaluation = id });

            return Ok(result);
        }

        [HttpPost("updatevaluationcurriculum")]
        public async Task<IActionResult> UpdateEvaluationCurriculum(EvaluationPostulantInfoCurriculumDto dto)
        {
            var result = await mediator.Send(new UpdateEvaluationPostulantCurriculum() { dto = dto });

            return Ok(result);
        }

        [HttpPost("updatevaluationposition")]
        public async Task<IActionResult> UpdateEvaluationPosition(EvaluationPostulantPositionDto dto)
        {
            var result = await mediator.Send(new UpdateEvaluationPostulantPosition() { dto = dto });

            return Ok(result);
        }

        [HttpGet("getevaluationproficiencyintern/{id}/{idpostulant}/{flag}")]
        public async Task<IActionResult> GetEvaluationProficiency(int id, int idpostulant, int flag)
        {
            var result = await mediator.Send(new GetEvaluationPostulantProficiencyInternQuery() { IdEvaluation = id, IdPostulant = idpostulant, Flag = flag });

            return Ok(result);
        }

        [HttpGet("getevaluationfortalezas/{id}/{idpostulant}")]
        public async Task<IActionResult> GetEvaluationRating(int id, int idpostulant)
        {
            var result = await mediator.Send(new GetEvaluationFortalezasQuery() { IdEvaluation = id, IdPostulant = idpostulant });

            return Ok(result);
        }

        [HttpPost("updateevaluationproficiencyintern")]
        public async Task<IActionResult> UpdateEvaluationProficiency(EvaluationProficiencyInternDto dto)
        {
            var result = await mediator.Send(new UpdateEvaluationProficiencyInternCommand() { dto = dto });

            return Ok(result);
        }

        [HttpPost("updateevaluationrating")]
        public async Task<IActionResult> UpdateEvaluationRating(EvaluationFortalezasInternDto dto)
        {
            var result = await mediator.Send(new UpdateEvaluationFortalezasInternCommand() { dto = dto });

            return Ok(result);
        }

        [HttpPost("updatevaluationlogros")]
        public async Task<IActionResult> UpdateEvaluationLogros(EvaluationPostulantInternalLogrosDto dto)
        {
            var result = await mediator.Send(new CreateEvaluationPostulantLogrosCommand() { dto = dto });

            return Ok(result);
        }

        [HttpGet("getevaluationlogros/{id}")]
        public async Task<IActionResult> GetEvaluationLogros(int id)
        {
            var result = await mediator.Send(new GetEvaluationPostulantLogrosQuery() { IdEvaluationPostulant = id });

            return Ok(result);
        }

        [HttpGet("generateinforme/{id}")]
        public async Task<IActionResult> GenerateInforme(int id)
        {
            var result = await mediator.Send(new GenerateInformeEvaluationCommand() { IdEvaluation = id });

            return Ok(result);
        }

        [HttpGet("generatereportpostulant/{id}")]
        public async Task<IActionResult> GenerateReportPostulant(int id)
        {
            var result = await mediator.Send(new GenerateEvaluationReportInternCommand() { IdEvaluationPostulant = id });

            return Ok(result);
        }

        [HttpPost("getpostulantsinformation")]
        public async Task<IActionResult> GetEvaluationPostulantsAll(FilterParamDto filter)
        {
            var result = await mediator.Send(new GetPortulantInformationQuery() { filter = filter });
            return Ok(result);
        }

        [HttpGet("informationfilesdelete/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> InformationFilesDelete(int id)
        {
            var result = await mediator.Send(new PortulantFileDeleteQuery() { nidinformationfile = id });

            return Ok(result);
        }
    }
}
