using HumanManagement.Application.EvaluationPostulants.Command;
using HumanManagement.Application.EvaluationPostulants.Queries;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.EvaluationPostulant.Dto;
using HumanManagement.Domain.EvaluationPostulant.QueryFilter;
using HumanManagement.Domain.Utils.Dto;
using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

using System.Threading.Tasks;
using HumanManagement.Application.Campaign.Commands.Create;



namespace HumanManagementApi.Controllers.EvaluationPostulant
{
    [Route("api/[controller]")]
    [ApiController]
    public class EvaluationPostulantController : BaseApiController
    {


        [HttpPost("createevaluation")]
        public async Task<IActionResult> CreateEvaluation(List<EvaluationPostulantDto> dto)
        {
            var result = await mediator.Send(new CreateEvaluationPostulantCommand() { Dto = dto });

            return Ok(result);
        }

        [HttpGet("getIdEvaluation/{id}")]
        public async Task<IActionResult> GetIdEvaluation(int id)
        {
            var result = await mediator.Send(new GetIdEvaluationPostulantQuery() { IdJob = id });

            return Ok(result);
        }


        [HttpPost("getevaluationlist")]
        public async Task<IActionResult> GetEvaluationList(EvaluationQueryFilter filter)
        {
            var result = await mediator.Send(new GetEvaluationListQuery() { Filter = filter });

            return Ok(result);
        }

        [HttpGet("getevaluation/{id}")]
        public async Task<IActionResult> GetEvaluation(int id)
        {
            var result = await mediator.Send(new GetEvaluationPostulantQuery() { IdEvaluation = id });

            return Ok(result);
        }

        [HttpGet("getevaluationexport/{id}")]
        public async Task<IActionResult> GetEvaluationExport(int id)
        {
            string fullPath = string.Empty;
            string randmname = "Postulantes_" + DateTime.Now.ToString("ddMMyyyy") + DateTime.Now.ToString("hhmmss") + ".xlsx";
            fullPath = Path.Combine(Directory.GetCurrentDirectory(), "Files", randmname);

            var result = await mediator.Send(new GetListEvaluationPostulantQuery() { IdEvaluation = id });

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

        [HttpGet("getinfopostulant/{id}")]
        public async Task<IActionResult> GetInfoPostulant(int id)
        {
            var result = await mediator.Send(new GetInfoPostulanteQuery() { IdEvaluationPostulant = id });

            return Ok(result);
        }

        [HttpPost("createnotes")]
        public async Task<IActionResult> CreateNotes(NotesEvaluationDto dto)
        {
            var result = await mediator.Send(new CreateNotesEvaluationCommand() { NotesEvaluationDto = dto });

            return Ok(result);
        }

        [HttpGet("getevaluationproficiency/{id}/{idpostulant}")]
        public async Task<IActionResult> GetEvaluationProficiency(int id, int idpostulant)
        {
            var result = await mediator.Send(new GetEvaluationProficiencyQuery() { IdEvaluation = id, IdPostulant = idpostulant });

            return Ok(result);
        }

        [HttpGet("getevaluationrating/{id}/{idpostulant}")]
        public async Task<IActionResult> GetEvaluationRating(int id, int idpostulant)
        {
            var result = await mediator.Send(new GetEvaluationRatingQuery() { IdEvaluation = id, IdPostulant = idpostulant });

            return Ok(result);
        }

        [HttpGet("getnotes/{id}")]
        public async Task<IActionResult> GetNotes(int id)
        {
            var result = await mediator.Send(new GetNotesEvaluationQuery() { IdEvaluationPostulant = id });

            return Ok(result);
        }

        [HttpPost("updatevaluation")]
        public async Task<IActionResult> UpdateEvaluationPostulant()
        {
            var dtoRequest = Request.Form["request"];
            var dto = JsonConvert.DeserializeObject<EvaluationPostulantDto>(dtoRequest);

            var dtoMultitest = Request.Form["multitest"];
            var dtoMulti = JsonConvert.DeserializeObject<List<FactorDto>>(dtoMultitest);
            var result = await mediator.Send(new UpdateEvaluationPostulantCommand() { dto = dto , factorDtos = dtoMulti});

            return Ok(result);
        }

        [HttpPost("updateevaluationprocess")]
        public async Task<IActionResult> UpdateEvaluationProcess(EvaluationDto dto)
        {
            var result = await mediator.Send(new UpdateEvaluationExternProcessCommand() { dto = dto });

            return Ok(result);
        }

        [HttpPost("updateevaluationproficiency")]
        public async Task<IActionResult> UpdateEvaluationProficiency(EvaluationProficiencyDto dto)
        {
            var result = await mediator.Send(new UpdateEvaluationProficiencyCommand() { dto = dto });

            return Ok(result);
        }

        [HttpPost("updateevaluationrating")]
        public async Task<IActionResult> UpdateEvaluationRating(EvaluationRatingPostulantDto dto)
        {
            var result = await mediator.Send(new UpdateEvaluationRatingPostulantCommand() { dto = dto });

            return Ok(result);
        }


        [HttpPost("loaddocuments")]
        public async Task<IActionResult> LoadDocuments()
        {
            var dtoRequest = Request.Form["request"];

            var file = Request.Form.Files[0];
            var dto = JsonConvert.DeserializeObject<EvaluationPostulantDocumentsDto>(dtoRequest);
            var result = await mediator.Send(new LoadDocumentsPostulantRequiredCommand() { dto = dto, formFile = file });

            return Ok(result);
        }

        [HttpGet("getdocuments/{id}")]
        public async Task<IActionResult> GetDocumentsPostulant(int id)
        {
            var result = await mediator.Send(new GetDocumentPostulantQuery() { IdEvaluationPostulant = id });

            return Ok(result);
        }

        [HttpPost("deletefile")]
        public async Task<IActionResult> DeleteFile(EvaluationPostulantDocumentsDto dto)
        {
            var result = await mediator.Send(new DeleleDocumentPostulantCommand() { EvaluationPostulantDocumentsDto = dto });

            return Ok(result);
        }

        [HttpGet("getevaluationtest/{id}")]
        public async Task<IActionResult> GetEvaluationTest(int id)
        {
            var result = await mediator.Send(new GetEvaluationTestQuery() { IdEvaluationPostulant = id });

            return Ok(result);
        }

        [HttpPost("createevaluationtest")]
        public async Task<IActionResult> CreateEvaluationTest(EvaluationExternTestDto dto)
        {
            var result = await mediator.Send(new CreateEvaluationTestCommand() { Dto = dto });

            return Ok(result);
        }

        [HttpPost("deleteevaluationtest")]
        public async Task<IActionResult> DeleteEvaluationTest(EvaluationExternTestDto dto)
        {
            var result = await mediator.Send(new DeleteEvaluationTestCommand() { Dto = dto });

            return Ok(result);
        }

        [HttpGet("generateinforme/{id}")]
        public async Task<IActionResult> GenerateInforme(int id)
        {
            var result = await mediator.Send(new GenerateInformeEvaluationExternCommand() { IdEvaluation = id });

            return Ok(result);
        }

        [HttpGet("generatereportpostulant/{id}")]
        public async Task<IActionResult> GenerateReportPostulant(int id)
        {
            var result = await mediator.Send(new GenerateEvaluationPostulantExternCommand() { IdEvaluationPostulant = id });

            return Ok(result);
        }

        [HttpPost("loadmasive")]
        public async Task<IActionResult> LoadMasive()
        {
            var dtoRequest = Request.Form["request"];

            var file = Request.Form.Files[0];
            var dto = JsonConvert.DeserializeObject<CargaMasivaDto>(dtoRequest);

            var result = await mediator.Send(new LoadMasivePostulantCommand() { formFile = file, IsBumeran = dto.IsBumeran, Job = dto.Job });

            return Ok(result);
        }

        [HttpGet("getpostulantsloader/{job}")]
        public async Task<IActionResult> GetPostulantsLoaded(int job)
        {
            var result = await mediator.Send(new GetPostulantsLoadedQuery() { Job = job });

            return Ok(result);
        }

        [HttpPost("deleteevaluationproficiency")]
        public async Task<IActionResult> DeleteEvaluationProficiency(EvaluationProficiencyDto dto)
        {
            var result = await mediator.Send(new DeleteEvaluationProficiencyCommand() { dto = dto });

            return Ok(result);
        }
        [HttpPost("sendnotificationsselected/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> SendNotificationSelected(int id)
        {

            var dtoRequest = Request.Form["request"];
            var dto = JsonConvert.DeserializeObject<EvaluationPostulantDto>(dtoRequest);
            var campaign = await mediator.Send(new SendNotificationCommand() { IdCampaign = id, tipo = 1, dto = dto });

            return Ok(campaign);
        }
    }
}
