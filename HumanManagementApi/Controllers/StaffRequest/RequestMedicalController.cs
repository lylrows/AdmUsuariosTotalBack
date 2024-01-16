using HumanManagement.Application.StaffRequest.Commands.Create;
using HumanManagement.Application.StaffRequest.Commands.Update;
using HumanManagement.Application.StaffRequest.Queries;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.StaffRequest.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Threading.Tasks;

namespace HumanManagementApi.Controllers.StaffRequest
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestMedicalController : BaseApiController
    {
        private readonly ILogger<RequestMedicalController> _logger;
        public RequestMedicalController(ILogger<RequestMedicalController> logger)
        {
            this._logger = logger;
        }

        [HttpPost()]
        public async Task<IActionResult> RegisterMedical(RegisterMedicalDto registerMedicalDto)
        {
            var list = await mediator.Send(new CreateMedicalCommand() { payload = registerMedicalDto });

            return Ok(list);
        }

        [HttpPost("registerdocument")]
        public async Task<IActionResult> RegisterDocument()
        {
            var dtoRequest = Request.Form["request"];
            IFormFile file = null;

            if (Request.Form.Files.Count > 0)
            {
                file = Request.Form.Files[0];
            }

            _logger.LogInformation(string.Format("dtoRequest => {0}", Newtonsoft.Json.JsonConvert.SerializeObject(dtoRequest)));
            var dto = JsonConvert.DeserializeObject<RegisterDocumentMedicalDto>(dtoRequest);
            var list = await mediator.Send(new RegisterRequestDocumentCommand() { payload = dto, file = file ,bIsDraft=false});
            return Ok(list);
        }

        [HttpPost("updatestaterequest")]
        public async Task<ActionResult> updateStateRequest()
        {
            var converted = Convert.ToInt32(Request.Form["id"].ToString());
            var resp = await mediator.Send(new UpdateRequestMedicalStateCommand() { idmedical = converted });

            return Ok(resp);
        }

        [HttpPost("registerdocumentdraft")]
        public async Task<IActionResult> RegisterDocumentDraft()
        {
            var dtoRequest = Request.Form["request"];
            var file = Request.Form.Files[0];
            _logger.LogInformation(string.Format("dtoRequest => {0}", Newtonsoft.Json.JsonConvert.SerializeObject(dtoRequest)));
            var dto = JsonConvert.DeserializeObject<RegisterDocumentMedicalDto>(dtoRequest);
            var list = await mediator.Send(new RegisterRequestDocumentCommand() { payload = dto, file = file, bIsDraft= true });
            return Ok(list);
        }

        [HttpPost("registerdocumentmasive")]
        public async Task<IActionResult> RegisterDocumentMasive()
        {
            var dtoRequest = Request.Form["request"];
            var file = Request.Form.Files[0];
            _logger.LogInformation(string.Format("dtoRequest => {0}", Newtonsoft.Json.JsonConvert.SerializeObject(dtoRequest)));
            var dto = JsonConvert.DeserializeObject<RegisterDocumentMedicalMasiveDto>(dtoRequest);
            var list = await mediator.Send(new RegisterRequestDocumentMasiveCommand() { payload = dto, fileslist = Request.Form.Files });
            return Ok("OK");
        }



       




        [HttpPost("getlistmedical")]
        public async Task<IActionResult> ListMedical(FilterListDocumentDto registerMedicalDto)
        {
            var list = await mediator.Send(new GetListMedicalCommand() { payload = registerMedicalDto });

            return Ok(list);
        }

        [HttpPost("getlistmedicalprint")]
        public async Task<IActionResult> ListMedicalPrint(FilterListDocumentDto registerMedicalDto)
        {
            string fullPath = string.Empty;
            var list = await mediator.Send(new GetListMedicalCommand() { payload = registerMedicalDto });

            try
            {
                DataTable dt = new DataTable();
                dt.TableName = "Listado";

                dt.Columns.Add("N° de solicitud");
                dt.Columns.Add("SEDE");
                dt.Columns.Add("CÓDIGO TIPO");
                dt.Columns.Add("TIPO");
                dt.Columns.Add("DNI COLABORADOR");
                dt.Columns.Add("COLABORADOR");
                dt.Columns.Add("FECHA DE REGISTRO DE DM");
                dt.Columns.Add("FECHA DE EMISION DE DM");
                dt.Columns.Add("AÑO");
                dt.Columns.Add("FECHA INICIO");
                dt.Columns.Add("FECHA FIN");
                dt.Columns.Add("DÍAS");
                dt.Columns.Add("DIAGNOSTICO MEDICO");
                dt.Columns.Add("RUC CLINICA");
                dt.Columns.Add("COLEGIATURA DEL MEDICO");
                dt.Columns.Add("CÓDIGO ORIGEN MÉDICO");
                dt.Columns.Add("ORIGEN MEDICO");
                dt.Columns.Add("CÓDIGO TIPO DE DESCANSO MEDICO");
                dt.Columns.Add("TIPO DE DESCANSO MEDICO");
                dt.Columns.Add("ADJUNTO SUSTENTO");
                dt.Columns.Add("COMPROMISO");
                dt.Columns.Add("ESTADO");
                dt.Columns.Add("ETAPA");
                dt.Columns.Add("REGISTRADO EN VIVA");
                dt.Columns.Add("NRO. OPERACIÓN VIVA");
                dt.Columns.Add("ADJUNTO SUSTENTO DE REGISTRO");
                dt.Columns.Add("NRO. NITT");
                dt.Columns.Add("OBSERVACION NITT");
                dt.Columns.Add("NRO. CITT");
                dt.Columns.Add("FECHA DEL CITT");
                dt.Columns.Add("ADJUNTO SUSTENTO DE CITT");
                dt.Columns.Add("MONTO GENERADO");
                dt.Columns.Add("MONTO COBRADO");
                dt.Columns.Add("MONTO NO DEVUELTO");
                

                DataRow row;
                List<MedicalDto> lstData = (List<MedicalDto>)list.Data;

                foreach (var item in lstData)
                {
                    row = dt.NewRow();
                    string etapa = string.Empty;
                    switch(item.nstate)
                    {
                        case 1:
                        case 2:
                        case 4:
                            etapa = "Etapa 1: Evaluación";
                            break;
                        case 3:
                        case 8:
                            etapa = "-";
                            break;
                        case 5:
                            etapa = "Etapa 2: Registro VIVA";
                            break;
                        case 6:
                            etapa = "Etapa 3: Evaluación VIVA";
                            break;
                        case 7:
                            etapa = "Etapa 4: Recupero VIVA";
                            break;
                    }

                    row[0] = item.nid_medical;
                    row[1] = item.ssede;
                    row[2] = item.ntype;
                    row[3] = item.stype;
                    row[4] = item.sdni;
                    row[5] = item.sfullname;
                    row[6] = item.dregisterdm.ToString("dd/MM/yyyy");
                    row[7] = item.dissuedm.ToString("dd/MM/yyyy");
                    row[8] = item.nyear;
                    row[9] = item.ddateinitdm.ToString("dd/MM/yyyy");
                    row[10] = item.ddateenddm.ToString("dd/MM/yyyy");
                    row[11] = item.ndays;
                    row[12] = item.smedicaldiagnostic;
                    row[13] = item.srucclinic;
                    row[14] = item.tuitiondoctor;
                    row[15] = item.noriginmedical;
                    row[16] = item.soriginmedical;
                    row[17] = item.ntypedm;
                    row[18] = item.stypedm;
                    row[19] = item.nstatedocument == 1 ? "SI" : "NO";
                    row[20] = item.scommitment == "1" ? "SI" : "NO";
                    row[21] = item.sstate;
                    row[22] = etapa;
                    row[23] = Convert.ToBoolean(item.bregisterviva) ? "SI" : "NO";
                    row[24] = item.soperationnumber;
                    row[25] = item.sfileregisterviva == "NO" ? "NO" : "SI";
                    row[26] = item.snitt;
                    row[27] = item.sobervationscitt;
                    row[28] = item.snumberCIT;
                    row[29] = item.dregisterdm.ToString("dd/MM/yyyy");
                    row[30] = item.sfilecitt == "N/A" ? "NO" : "SI";
                    row[31] = item.ngeneratedamount ==0? "N/A" : item.ngeneratedamount.ToString();
                    row[32] = item.namount == 0 ? "N/A" : item.namount.ToString();
                    row[33] = item.amountnoreturned == 0 ? "N/A" : item.amountnoreturned.ToString();
                    
                    dt.Rows.Add(row);
                }

                string randmname = "Listado " + DateTime.Now.ToString("ddMMyyyy") + DateTime.Now.ToString("hhmmss") + ".xlsx";

                fullPath = Path.Combine(Directory.GetCurrentDirectory(), "Files", randmname);
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
                throw ex;
            }

            return Ok(list);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> MedicalById(int id)
        {
            var list = await mediator.Send(new GetMedicalByIdQuery() { id = id });

            return Ok(list);
        }

        [HttpGet("getApprovalDate/{Id}")]
        public async Task<IActionResult> GetApprovalDate(int id)
        {
            var list = await mediator.Send(new GetApprovalDateQuery() { id = id });

            return Ok(list);
        }

        [HttpGet("listdocument/{Id}")]
        public async Task<IActionResult> ListDocumentByMedical(int id)
        {
            var list = await mediator.Send(new GetListDocumentByMedicalQuery() { id = id });

            return Ok(list);
        }


        [HttpGet("requestdocumentobserver/{Id}")]
        public async Task<IActionResult> RequestDocumentObserver(int id)
        {
            var list = await mediator.Send(new RequestDocumentObserverCommand() { IdDocument = id });

            return Ok(list);
        }


        [HttpGet("listusernotification")]
        public async Task<IActionResult> ListUserNotificationMedical()
        {
            var list = await mediator.Send(new GetUserByNotificationMedicalQuery() {});

            return Ok(list);
        }

        [HttpPost("validdocument")]
        public async Task<IActionResult> ValidDocument(ValidDocumentControllDto registerMedicalDto)
        {
            var list = await mediator.Send(new ValidDocumentQuery() { payload = registerMedicalDto });

            return Ok(list);
        }


        [HttpPost("observedocumentmasive")]
        public async Task<IActionResult> ObserveDocumentMasive(ObserveMasiveDocumentDto dto)
        {
            var list = await mediator.Send(new ObserveDocumentMasiveCommand() { dto = dto });

            return Ok(list);
        }



        [HttpPost("updatefilemedical")]
        public async Task<IActionResult> UpdateFile()
        {
            var dtoRequest = Request.Form["request"];
            var file = Request.Form.Files[0];
            var dto = JsonConvert.DeserializeObject<UpdateFilesDto>(dtoRequest);
            var list = await mediator.Send(new UpdateFileMedicalQuery() { payload = dto, file = file });

            return Ok(list);
        }

        [HttpPost("updatevivaFile")]
        public async Task<IActionResult> UpdateVIA()
        {
            var dtoRequest = Request.Form["request"];
            var file = Request.Form.Files[0];
            var dto = JsonConvert.DeserializeObject<UpdateVIVAMedical>(dtoRequest);
            var list = await mediator.Send(new UpdateVIVAFileMedicalCommand() { payload = dto, file = file });

            return Ok(list);
        }

        [HttpPost("updateviva")]
        public async Task<IActionResult> UpdateVIA(UpdateVIVAMedical updateVIVAMedical)
        {
            var list = await mediator.Send(new UpdateVIVAMedicalCommand() { payload = updateVIVAMedical });

            return Ok(list);
        }

        [HttpGet("getdays/{Id}")]
        public async Task<IActionResult> ListUserNotificationMedical(int id)
        {
            var list = await mediator.Send(new GetDaysbyEmployeeQuery() { payload = id });

            return Ok(list);
        }

        [HttpPost("updatecittFile")]
        public async Task<IActionResult> UpdateCITTFILE()
        {
            var dtoRequest = Request.Form["request"];
            var file = Request.Form.Files[0];
            var dto = JsonConvert.DeserializeObject<UpdateCITTMedicalDto>(dtoRequest);
            var list = await mediator.Send(new UpdateCITTFileMedicalCommand() { payload = dto, file = file });

            return Ok(list);
        }

        [HttpPost("updatecitt")]
        public async Task<IActionResult> UpdateCITT(UpdateCITTMedicalDto updateVIVAMedical)
        {
            var list = await mediator.Send(new UpdateCITTMedicalCommand() { payload = updateVIVAMedical });

            return Ok(list);
        }

        [HttpPost("updateamount")]
        public async Task<IActionResult> UpdateAmount(UpdateAmountMedicalDto updateVIVAMedical)
        {
            var list = await mediator.Send(new UpdateAmountMedicalCommand() { payload = updateVIVAMedical });

            return Ok(list);
        }

        [HttpPost("reject")]
        public async Task<IActionResult> Reject(RejectMedicalDto updateVIVAMedical)
        {
            var list = await mediator.Send(new RejectMedicalCommand() { payload = updateVIVAMedical });

            return Ok(list);
        }

        [HttpGet("getboss/{Id}")]
        public async Task<IActionResult> Getboss(int id)
        {
            var list = await mediator.Send(new GetBossByPersonQuery() { payload = id });

            return Ok(list);
        }

        [HttpGet("reportamount")]
        public async Task<IActionResult> ReportAmount()
        {
            var list = await mediator.Send(new ReportAmountQuery() { });

            return Ok(list);
        }

        [HttpPost("reportgraficstatus")]
        public async Task<IActionResult> ReportGraficStatus(ReportGraficFilter filter)
        {
            var list = await mediator.Send(new ReportGraficStatusMedicalQuery() { payload = filter });

            return Ok(list);
        }

        [HttpPost("reportgraficetapa")]
        public async Task<IActionResult> ReportGraficEtapa(ReportGraficFilter filter)
        {
            var list = await mediator.Send(new ReportGraficEtapaMedicalQuery() { payload = filter });

            return Ok(list);
        }

        [HttpPost("sendmedicalcertificateexactus")]
        public async Task<IActionResult> SendMedicalCertificateExactus(ValidDocumentControllDto registerMedicalDto)
        {
            var list = await mediator.Send(new SendMedicalCertificateExactusQuery() { payload = registerMedicalDto });

            return Ok(list);
        }

        [HttpPost("medicaldocumentapproved")]
        public async Task<IActionResult> RequestMedicalDocumentApproved(RequestDocumentApprovedDto dto)
        {
            var list = await mediator.Send(new RequestMedicalDocumentApprovedQuery() { payload = dto });

            return Ok(list);
        }
    }
}
