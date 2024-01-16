using DocumentFormat.OpenXml.Office2010.Excel;
using HumanManagement.Application.Employee.Queries;
using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.Employee.Dto;
using HumanManagement.Domain.Employee.QueryFilter;
using HumanManagement.Domain.Security.QueryFilter;
using HumanManagement.Domain.StaffRequest.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace HumanManagementApi.Controllers.Employee
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : BaseApiController
    {
        private readonly ITextReplacement _textReplacement;
        private readonly AppSettings _appSettings;
        private readonly ILogger<RequestController> _logger;

        public RequestController(ITextReplacement textReplacement, IOptions<AppSettings> appSettings, ILogger<RequestController> logger)
        {
            this._textReplacement = textReplacement;
            this._appSettings = appSettings.Value;
            this._logger = logger;
        }

        [HttpPost("requestIns")]
        public async Task<IActionResult> InsertRequestEmployee()
        {
            var dtoRequest = Request.Form["request"];
            IFormFile file = null;
            if (Request.Form.Files.Count != 0)
                file = Request.Form.Files[0];
            var dto = JsonConvert.DeserializeObject<RequestInsDto>(dtoRequest);
            var management = await mediator.Send(new InsRequestQuery() { payload = dto, file = file});
            return Ok(management);
        }


        [HttpPost("listrquest")]
        public async Task<IActionResult> ListRequest([FromBody] RequestFilterDto payload )
        {
            var management = await mediator.Send(new ListRequestQuery() { payload = payload });

            return Ok(management);
        }

        [HttpPost("listrquestpagination")]
        public async Task<IActionResult> ListRequestPagination(EmployeeQueryFilter employeeQueryFilter)
        {
            var lista = await mediator.Send(new ListRequestPaginationQuery() { EmployeeQueryFilter = employeeQueryFilter });

            return Ok(lista);
        }

        [HttpPost("listrquestprint")]
        public async Task<IActionResult> ListRequestPrint([FromBody] RequestFilterDto payload)
        {
            string fullPath = string.Empty;

            try
            {
                string randmname = "Listado " + DateTime.Now.ToString("ddMMyyyy") + DateTime.Now.ToString("hhmmss") + ".xlsx";

                fullPath = Path.Combine(Directory.GetCurrentDirectory(), "Files", randmname);

                var management = await mediator.Send(new ListRequestQuery() { payload = payload });

                DataTable dt = generateTable(management);

                Functions.DataTableToExcelWithStyle(dt, fullPath);

                Byte[] bytes5 = System.IO.File.ReadAllBytes(fullPath);
                String file5 = Convert.ToBase64String(bytes5);

                if (System.IO.File.Exists(fullPath))
                {
                    System.IO.File.Delete(fullPath);
                }
                return Json(file5);

            }
            catch (Exception ex)
            {
                if (System.IO.File.Exists(fullPath))
                {
                    System.IO.File.Delete(fullPath);
                }
                throw;
            }
        }


        private DataTable generateTable(Result _listSummary)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.TableName = "Listado";

                dt.Columns.Add("DNI");
                dt.Columns.Add("Colaborador");
                dt.Columns.Add("Gerencia");
                dt.Columns.Add("Area");
                dt.Columns.Add("SubArea");
                dt.Columns.Add("Tipo de Solicitud");
                dt.Columns.Add("Fecha de Solicitud");
                dt.Columns.Add("Sección");
                dt.Columns.Add("Acción");
                dt.Columns.Add("Periodo Solicitado");
                dt.Columns.Add("Aprobador/Rechazado Por");
                dt.Columns.Add("Estado");

                DataRow row;
                List<ListRequestDto> lstSubTotales = (List<ListRequestDto>)_listSummary.Data;

                foreach (var item in lstSubTotales)
                {
                    row = dt.NewRow();

                    row[0] = item.dni;
                    row[1] = item.scollaborator;
                    row[2] = item.Gerencia;
                    row[3] = item.Area;
                    row[4] = item.SubArea;
                    row[5] = item.styperequest;
                    row[6] = item.dregister;
                    row[7] = item.ssection;
                    row[8] = item.stypeaction;
                    row[9] = item.periodo;
                    row[10] = item.sapprover;
                    row[11] = item.sstate;
                    dt.Rows.Add(row);
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        [HttpPost("accept")]
        public async Task<IActionResult> AcceptRequest([FromBody] AcceptRequest payload)
        {
            var management = await mediator.Send(new AcceptRequestQuery() { payload = payload });

            return Ok(management);
        }

        [HttpPost("reject")]
        public async Task<IActionResult> RejectRequest([FromBody] RejectRequest payload)
        {
            var management = await mediator.Send(new RejectRequestQuery() { payload = payload });

            return Ok(management);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> RequestDetail(int id)
        {
            var management = await mediator.Send(new DetailRequestQuery() { id = id});

            return Ok(management);
        }

        [HttpPost("insertdocument")]
        public async Task<IActionResult> InsertDocument([FromBody] InsertRequestDocumentDto payload)
        {
            var management = await mediator.Send(new insertRequestDocumentQuery() { payload = payload });

            

            return Ok(management);
        }



        [HttpPost("dowloadcv")]
        public async Task<IActionResult> DownloadCV([FromBody] simplePayload payload )
        {
            var employeecv = await mediator.Send(new GetEmployeeCVQuery() { nid_employee = payload.idEmployee });

            var fileCV = _textReplacement.ReplaceTextEmployeeCV(employeecv.Data as EmployeeCVDto, _appSettings.PathSaveCv, _appSettings.TemplateCvDocx);
            var data = new {
                file = fileCV,
                fileName = "CV de " + payload.inputFullname,
                contentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document"
            };

            if (!string.IsNullOrWhiteSpace(fileCV))
                return Json(data);

            return NoContent();
        }

        [HttpPost("listrequestbyuser")]
        public async Task<IActionResult> ListRequestByUser(EmployeeQueryFilter employeeQueryFilter)
        {
            var lista = await mediator.Send(new ListRequestByUserQuery() { EmployeeQueryFilter = employeeQueryFilter });

            return Ok(lista);
        }

        [HttpPost("RequestSolicitudById")]
        public async Task<IActionResult> RequestById(RequestByIdFilter filter)
        {
            var lista = await mediator.Send(new RequestByIdQuery() { filter = filter });

            return Ok(lista);
        }
    }
}
