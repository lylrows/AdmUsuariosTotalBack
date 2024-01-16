using HumanManagement.Application.Campaign.Commands.Create;
using HumanManagement.Application.Evaluation.Queries;
using HumanManagement.Application.Evaluation.Update;
using HumanManagement.Application.Helpers;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.Campaign.Dto;
using HumanManagement.Domain.Employee.Dto;
using HumanManagement.Domain.Evaluation.Contracts;
using HumanManagement.Domain.Evaluation.Dto;
using HumanManagement.Domain.EvaluationPostulant.Dto;
using HumanManagement.Domain.StaffRequest.Contracts;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagementApi.Controllers.Evaluation
{
    public class EvaluationController : BaseApiController
    {
        protected readonly SessionManager sessionManager;
        
        private readonly ITextReplacement _textReplacement;

        public EvaluationController(SessionManager sessionManager
            
            ,ITextReplacement textReplacement
            )
        {
            this.sessionManager = sessionManager;
            this._textReplacement = textReplacement;
        
        }

        [HttpGet("getfullevaluation/{id}")]
        public async Task<IActionResult> GetFullEvaluation(int id)
        {

            var evaluation = await mediator.Send(new GetFullEvaluationQuery() { IdEvaluation= id });
            return Ok(evaluation);
        }

        [HttpGet("lastcampaign/{id}")]
        public async Task<IActionResult> LastCampaignByEmployee(int id)
        {

            var campaign = await mediator.Send(new LastGetCampaignQuery() { nid_employee = id });

            return Ok(campaign);
        }

        [HttpPost("updateevaluationdetail")]
        public async Task<IActionResult> UpdateEvaluationDetail([FromBody] UpdateEvaluationDetailDto dto)
        {
            int nIdUser = sessionManager.User == null ? 1: sessionManager.User.IdUser;
            
            var campaign = await mediator.Send(new UpdateEvaluationCommand() {  saveEvaluationDetail= dto ,IdUser = nIdUser });

            return Ok(campaign);
        }

        [HttpPost("deleteemployee")]
        public async Task<IActionResult> DeleteEmployeeEvaluation([FromBody] DeleteEmployee dto)
        {

            var campaign = await mediator.Send(new UpdateEmployeeCommand() { evaluationQueryFilter = dto });

            return Ok(campaign);
        }

        [HttpGet("sendnotificationsbycampaign/{id}")]
        public async Task<IActionResult> SendNotificationByCampaign(int id)
        {
            

            var campaign = await mediator.Send(new SendNotificationCommand() { IdCampaign = id,tipo = 0});

            return Ok(campaign);
        }

        [HttpGet("getprintevaluationdetail/{id}")]
        public async Task<IActionResult> GetPrintEvaluationDetail(int id)
        {

            var evaluation = await mediator.Send(new GetPrintEvaluationQuery() { IdEvaluation = id });
            var fileEvaluatioDetail =await _textReplacement.ReplaceTextEvuationDetailPDF(evaluation.Data);

            var data = new
            {
                file = fileEvaluatioDetail,
                fileName = "Detalle_Evaluacion",
                 
                contentType = "application/pdf"
            };

            if (!string.IsNullOrWhiteSpace(fileEvaluatioDetail))
                return Json(data);

            return NoContent();
        }


    }
}
