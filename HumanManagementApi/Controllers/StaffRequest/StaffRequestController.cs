using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using HumanManagement.Application.StaffRequest.Commands.Create;
using HumanManagement.Application.StaffRequest.Commands.Update;
using HumanManagement.Application.StaffRequest.GeneratePdf;
using HumanManagement.Application.StaffRequest.Queries;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.StaffRequest.Dto;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace HumanManagementApi.Controllers.StaffRequest
{
    public class StaffRequestController : BaseApiController
    {

        private readonly AppSettings appSettings;
        public StaffRequestController(IOptions<AppSettings> appSettings)
        {
            this.appSettings = appSettings.Value;
        }

        [HttpGet("getemployee")]
        public async Task<IActionResult> GetEmployee()
        {
            var employee = await mediator.Send(new GetStaffRequestEmployeeByIdQuery());

            return Ok(employee);
        }
        [HttpPost("getlistpagination")]
        public async Task<IActionResult> GetListPagination(StaffRequestQueryFilter staffRequestQueryFilter)
        {
            var list = await mediator.Send(new GetStaffRequestListPaginationQuery() { StaffRequestQueryFilter = staffRequestQueryFilter });

            return Ok(list);
        }

        [HttpPost("insertrequestadvament")]
        public async Task<IActionResult> RegisterAdvacementRequest(StaffRequestAdvancementDto staffRequestQueryFilter)
        {
            var list = await mediator.Send(new RegisterStaffRequestAdvancementCommand() { payload = staffRequestQueryFilter });

            return Ok(list);
        }

        [HttpGet("getrequestAdvacement/{Id}")]
        public async Task<IActionResult> GetRequestAdvacement(int Id)
        {
            var employee = await mediator.Send(new GetRequestAdvacementQuery() { IdRequest = Id });

            return Ok(employee);
        }

        [HttpGet("getrequestAdvacementdetail/{Id}")]
        public async Task<IActionResult> GetRequestAdvacementDetail(int Id)
        {
            var employee = await mediator.Send(new GetListDetailRequestQuery() { IdRequest = Id });

            return Ok(employee);
        }

        [HttpPost("acceptrequestadvament")]
        public async Task<IActionResult> AcceptAdvacementRequest(ApprovedAdvacementDto staffRequestQueryFilter)
        {
            var list = await mediator.Send(new ApprovedAdvacementRequestCommand() { payload = staffRequestQueryFilter });

            return Ok(list);
        }

        [HttpPost("rejectrequestadvament")]
        public async Task<IActionResult> RejectAdvacementRequest(RejectAdvacementDto staffRequestQueryFilter)
        {
            var list = await mediator.Send(new RejectAdvacementRequestCommand() { payload = staffRequestQueryFilter });

            return Ok(list);
        }

        [HttpPost("registerrequestmedical")]
        public async Task<IActionResult> RegisterRequestMedical()
        {
            var dtoRequest = Request.Form["request"];
            var file = Request.Form.Files[0];
            var dto = JsonConvert.DeserializeObject<RegisterRequestMedical>(dtoRequest);
            var list = await mediator.Send(new CreateStaffRequestMedicalCommand() { payload = dto, file = file });

            return Ok(list);
        }

        [HttpPost("registerrequestburial")]
        public async Task<IActionResult> RegisterRequestBurial(RegisterRequestBurial staffRequestQueryFilter)
        {
            var list = await mediator.Send(new CreateStaffRequestBurialCommand() { payload = staffRequestQueryFilter });

            return Ok(list);
        }

        [HttpPost("registerrequestsalary")]
        public async Task<IActionResult> RegisterRequestSalary()
        {
            var dtoRequest = Request.Form["request"];
            var file = Request.Form.Files[0];
            var fileFicha = Request.Form.Files[1];
            var dto = JsonConvert.DeserializeObject<RegisterRequestSalary>(dtoRequest);
            var list = await mediator.Send(new CreateStaffRequestSalaryCommand() { payload = dto, file = file, fileFicha= fileFicha });

            return Ok(list);
        }

        [HttpGet("getlistbank")]
        public async Task<IActionResult> ListBank()
        {
            var employee = await mediator.Send(new ListBankQuery() {});

            return Ok(employee);
        }

        [HttpGet("getrequestsalaryById/{Id}")]
        public async Task<IActionResult> getrequestsalaryById(int Id)
        {
            var employee = await mediator.Send(new GetStaffSalaryByIdQuery() { IdRequest = Id });

            return Ok(employee);
        }

        [HttpPost("acceptrequestsalary")]
        public async Task<IActionResult> AcceptSalaryRequest(ApprovedSalaryDto staffRequestQueryFilter)
        {
            var list = await mediator.Send(new ApprovedSalaryCommand() { payload = staffRequestQueryFilter });

            return Ok(list);
        }

        [HttpPost("rejectrequestsalary")]
        public async Task<IActionResult> RejectRequestSalary(RejectSalaryDto staffRequestQueryFilter)
        {
            var list = await mediator.Send(new RejectSalaryCommand() { payload = staffRequestQueryFilter });

            return Ok(list);
        }

        [HttpGet("getrequestburialById/{Id}")]
        public async Task<IActionResult> getrequestburialById(int Id)
        {
            var employee = await mediator.Send(new GetStaffBurialByIdQuery() { IdRequest = Id });

            return Ok(employee);
        }

        [HttpPost("acceptrequestburial")]
        public async Task<IActionResult> AcceptBurialRequest(ApprovedSalaryDto staffRequestQueryFilter)
        {
            var list = await mediator.Send(new ApprovedBurialCommand() { payload = staffRequestQueryFilter });

            return Ok(list);
        }

        [HttpPost("rejectrequestburial")]
        public async Task<IActionResult> RejectRequestBurial(RejectSalaryDto staffRequestQueryFilter)
        {
            var list = await mediator.Send(new RejectStaffBurialCommand() { payload = staffRequestQueryFilter });

            return Ok(list);
        }

        [HttpPost("acceptrequestmedical")]
        public async Task<IActionResult> AcceptMedicoRequest(ApprovedSalaryDto staffRequestQueryFilter)
        {
            var list = await mediator.Send(new ApprovedMedicalCommand() { payload = staffRequestQueryFilter });

            return Ok(list);
        }

        [HttpGet("getrequestmedicoById/{Id}")]
        public async Task<IActionResult> getrequestmedicoById(int Id)
        {
            var employee = await mediator.Send(new GetListDetailMedicalQuery() { IdRequest = Id });

            return Ok(employee);
        }

        [HttpPost("rejectrequestmedical")]
        public async Task<IActionResult> RejectRequestMedical(RejectSalaryDto staffRequestQueryFilter)
        {
            var list = await mediator.Send(new RejectStaffMedicalCommand() { payload = staffRequestQueryFilter });

            return Ok(list);
        }

        [HttpPost("registerrequessure")]
        public async Task<IActionResult> RegisterRequestSure()
        {
            var dtoRequest = Request.Form["request"];
            var file = Request.Form.Files[0];
            var dto = JsonConvert.DeserializeObject<RegisterRequestSure>(dtoRequest);
            
            var list = await mediator.Send(new RegisterStaffSureCommand() { payload = dto, file = file });

            return Ok(list);
        }

        [HttpPost("acceptrequestsure")]
        public async Task<IActionResult> AcceptSureRequest(ApprovedSureDto staffRequestQueryFilter)
        {
            var list = await mediator.Send(new ApprovedSureCommand() { payload = staffRequestQueryFilter });

            return Ok(list);
        }

        [HttpPost("rejectrequestsure")]
        public async Task<IActionResult> RejectRequestSure(RejectSalaryDto staffRequestQueryFilter)
        {
            var list = await mediator.Send(new RejectRequestSureCommand() { payload = staffRequestQueryFilter });

            return Ok(list);
        }

        [HttpGet("getrequestsureById/{Id}")]
        public async Task<IActionResult> getrequestsureById(int Id)
        {
            var employee = await mediator.Send(new GetSureRequestByIdQuery() { IdRequest = Id });

            return Ok(employee);
        }

        [HttpGet("getpdfmedicalrest/{id}")]
        public async Task<IActionResult> GetPdfMedicalRest(int id)
        {
            var result = await mediator.Send(new StaffRequestMedicalGeneratePdf() { Id = id });

            return Ok(result);
        }

        [HttpGet("getpdfsalaryadvance/{id}")]
        public async Task<IActionResult> GetPdfSalaryAdvance(int id)
        {
            var result = await mediator.Send(new StaffRequestAdvancementGeneratePdf() { Id = id });

            return Ok(result);
        }

        [HttpGet("getpdfburial/{id}")]
        public async Task<IActionResult> GetPdfBurial(int id)
        {
            var result = await mediator.Send(new StaffRequestBurialGeneratePdf() { Id = id });

            return Ok(result);
        }

        [HttpGet("getpdfsepelio/{id}")]
        public async Task<IActionResult> GetPdfSepelio(int id)
        {
            var result = await mediator.Send(new StaffRequestSepelioGeneratePdf() { Id = id });

            return Ok(result);
        }

        [HttpGet("getpdfsalaryaccount/{id}")]
        public async Task<IActionResult> GetPdfSalaryAccount(int id)
        {
            var result = await mediator.Send(new StaffRequestSalaryGeneratePdf() { Id = id });

            return Ok(result);
        }

        [HttpGet("getpdfsure/{id}")]
        public async Task<IActionResult> GetPdfSure(int id)
        {
            var result = await mediator.Send(new StaffRequestSureGeneratePdf() { Id = id });

            return Ok(result);
        }

        [HttpPost("registerrequeschangesure")]
        public async Task<IActionResult> RegisterRequestChangeSure()
        {
            var dtoRequest = Request.Form["request"];
            var file = Request.Form.Files.Any() ? Request.Form.Files[0] : null ;
            var dto = JsonConvert.DeserializeObject<RegisterChangeSureDto>(dtoRequest);

            var list = await mediator.Send(new CreateStaffRequestTypeSureCommand() { payload = dto, file = file });

            return Ok(list);
        }

        [HttpPost("acceptrequesttypesure")]
        public async Task<IActionResult> AcceptTypeSureRequest(ApprovedSalaryDto staffRequestQueryFilter)
        {
            var list = await mediator.Send(new ApprovedTypeSureCommand() { payload = staffRequestQueryFilter });

            return Ok(list);
        }

        [HttpPost("rejectrequesttypesure")]
        public async Task<IActionResult> RejectRequestTypeSure(RejectSalaryDto staffRequestQueryFilter)
        {
            var list = await mediator.Send(new RejectRequestTypeSureCommand() { payload = staffRequestQueryFilter });

            return Ok(list);
        }

        [HttpGet("getrequesttypesureById/{Id}")]
        public async Task<IActionResult> getrequesttypesureById(int Id)
        {
            var employee = await mediator.Send(new GetListDetailTypeSureQuery() { IdRequest = Id });

            return Ok(employee);
        }

        [HttpPost("registerrequeshourextra")]
        public async Task<IActionResult> RegisterRequestHourExtra()
        {
            var dtoRequest = Request.Form["request"];
            var file = Request.Form.Files[0];
            var dto = JsonConvert.DeserializeObject<RegisterHourExtraDto>(dtoRequest);
            var list = await mediator.Send(new CreateStaffRequestHourExtraCommand() { payload = dto, file = file });

            return Ok(list);
        }

        [HttpPost("acceptrequesthourextra")]
        public async Task<IActionResult> AcceptExtraHourRequest(ApprovedSalaryDto staffRequestQueryFilter)
        {
            var list = await mediator.Send(new ApprovedHourExtraCommand() { payload = staffRequestQueryFilter });

            return Ok(list);
        }

        [HttpPost("rejectrequesthourextra")]
        public async Task<IActionResult> RejectRequestHourExtra(RejectSalaryDto staffRequestQueryFilter)
        {
            var list = await mediator.Send(new RejectStaffRequesHourExtraCommand() { payload = staffRequestQueryFilter });

            return Ok(list);
        }

        [HttpGet("getrequesthourextraById/{Id}")]
        public async Task<IActionResult> getrequestHourExtraById(int Id)
        {
            var employee = await mediator.Send(new GetListDetailHourExtraQuery() { IdRequest = Id });

            return Ok(employee);
        }

        [HttpGet("getpdfhoraextra/{id}")]
        public async Task<IActionResult> GetPdfHoraExtra(int id)
        {
            var result = await mediator.Send(new StaffRequestHoraExtraGeneratePdf() { Id = id });

            return Ok(result);
        }

        [HttpGet("getpdfchangeeps/{id}")]
        public async Task<IActionResult> GetPdfChangeEps(int id)
        {
            var result = await mediator.Send(new StaffRequestCambioEPSGeneratePdf() { Id = id });

            return Ok(result);
        }

        [HttpGet("getemployeeChildren/{id}/{idEmployee}")]
        public async Task<IActionResult> GetEmployeeChildren(int id, int idEmployee)
        {
            var result = await mediator.Send(new StaffRequestGetEmployeeQuery() { Id = id, IdEmployee = idEmployee });

            return Ok(result);
        }

        [HttpGet("getEmployeeReplacement/{id}")]
        public async Task<IActionResult> GetEmployeeReplacement(int id)
        {
            var result = await mediator.Send(new GetListEmployeeReplacementQuery() { Id = id});

            return Ok(result);
        }

        [HttpGet("getemployeeChildrenById/{id}")]
        public async Task<IActionResult> GetEmployeeChildrenById(int id)
        {
            var result = await mediator.Send(new GetEmployeeChildrenQuery() { Id = id });

            return Ok(result);
        }

        [HttpPost("registerrequestrainingnew")]
        public async Task<IActionResult> RegisterRequestTrainingNew(RegisterCapacitacionDto staffRequestQueryFilter)
        {
            var list = await mediator.Send(new RegisterRequestTrainingCommand() { payload = staffRequestQueryFilter });

            return Ok(list);
        }

        [HttpGet("getrequestcapacitacionnuevaById/{Id}")]
        public async Task<IActionResult> getrequestCapacitacionNuevaById(int Id)
        {
            var employee = await mediator.Send(new GetRequestCapacitacionNuevaQuery() { IdRequest = Id });

            return Ok(employee);
        }


        [HttpPost("acceptrequesttrainingnew")]
        public async Task<IActionResult> AcceptTrainingNewRequest(ApprovedSalaryDto staffRequestQueryFilter)
        {
            var list = await mediator.Send(new ApprovedTrainingNewCommand() { payload = staffRequestQueryFilter });

            return Ok(list);
        }

        [HttpPost("rejectrequesttrainingnew")]
        public async Task<IActionResult> RejectRequestTrainingNew(RejectSalaryDto staffRequestQueryFilter)
        {
            var list = await mediator.Send(new RejectRequestTrainingNewCommand() { payload = staffRequestQueryFilter });

            return Ok(list);
        }

        [HttpPost("registerrequestrainingextra")]
        public async Task<IActionResult> RegisterRequestTrainingExtra(RegisterCapacitacionExtraDto staffRequestQueryFilter)
        {
            var list = await mediator.Send(new RegisterStaffRequestTrainingExtraCommand() { payload = staffRequestQueryFilter });

            return Ok(list);
        }

        [HttpPost("updaterequestrainingextra")]
        public async Task<IActionResult> UpdateRequestTrainingExtra(RegisterCapacitacionExtraDto staffRequestQueryFilter)
        {
            var list = await mediator.Send(new UpdateStaffRequestTrainingExtraCommand() { payload = staffRequestQueryFilter });

            return Ok(list);
        }

        [HttpGet("getrequestcapacitacionextraById/{Id}")]
        public async Task<IActionResult> getrequestCapacitacionExtraById(int Id)
        {
            var employee = await mediator.Send(new GetStaffRequestTrainingExtraByIdQuery() { IdRequest = Id });

            return Ok(employee);
        }

        [HttpPost("acceptrequesttrainingextra")]
        public async Task<IActionResult> AcceptTrainingExtraRequest(ApprovedSalaryDto staffRequestQueryFilter)
        {
            var list = await mediator.Send(new ApprovedTrainingExtraCommand() { payload = staffRequestQueryFilter });

            return Ok(list);
        }

        [HttpPost("rejectrequesttrainingextra")]
        public async Task<IActionResult> RejectRequestTrainingExtra(RejectSalaryDto staffRequestQueryFilter)
        {
            var list = await mediator.Send(new RejectTrainingExtraCommand() { payload = staffRequestQueryFilter });

            return Ok(list);
        }

        [HttpGet("getpdftrainingnew/{id}")]
        public async Task<IActionResult> GetPdfTrainingNew(int id)
        {
            var result = await mediator.Send(new StaffRequestTrainingNewGeneratePdf() { Id = id });

            return Ok(result);
        }

        [HttpGet("getpdftrainingextra/{id}")]
        public async Task<IActionResult> GetPdfTrainingExtra(int id)
        {
            var result = await mediator.Send(new StaffRequestTrainingExtraGeneratePdf() { Id = id });

            return Ok(result);
        }

        [HttpGet("getlistrequestbycategory/{id}")]
        public async Task<IActionResult> GetListRequestByCategory(int id)
        {
            var result = await mediator.Send(new GetListRequestByCategoryQuery() { IdCategory = id });

            return Ok(result);
        }

        [HttpGet("getlistcategory")]
        public async Task<IActionResult> GetListCategory()
        {
            var result = await mediator.Send(new GetListCategoryRequest() {});

            return Ok(result);
        }

        [HttpGet("getdatesbyemployee/{id}")]
        public async Task<IActionResult> GetDatesByEmployee(int id)
        {
            var result = await mediator.Send(new GetDatesByEmployeeQuery() { IdEmployee = id });

            return Ok(result);
        }

        [HttpGet("getdocumentword/{option}")]
        public async Task<IActionResult> GetUrlDocumentWord(int option)
        {
            var url = "";
            if ( option == 1 )
            {
                url = appSettings.FormatoFeSaludWord;
            } else
            {
                url = appSettings.FormatoPacificoWord;
            }

            switch (option)
            {
                case 1:
                    url = appSettings.FormatoFeSaludWord;
                    break;
                case 2:
                    url = appSettings.FormatoPacificoWord;
                    break;
                case 3:
                    url = appSettings.FormatoCambioEPS;
                    break;
                case 4:
                    url = appSettings.FormatoCambioCuentaSueldo;
                    break;
                case 5:
                    url = appSettings.FormatoCambioCTS;
                    break;
            }


            return Ok(url);
        }

        [HttpPost("exportrequest")]
        public async Task<IActionResult> GetExportRequest(StaffRequestQueryFilter staffRequestQueryFilter)
        {
            string fullPath = string.Empty;
            try
            {
                string randmname = "Reporte de Ventas " + DateTime.Now.ToString("ddMMyyyy") + DateTime.Now.ToString("hhmmss") + ".xlsx";
                fullPath = Path.Combine(Directory.GetCurrentDirectory(), "Files", randmname);
                DataTable dt = new DataTable();
                dt.TableName = "Informe";

                dt.Columns.Add("NRO. SOLICITUD");
                dt.Columns.Add("TIPO DE SOLICITUD");
                dt.Columns.Add("DNI");
                dt.Columns.Add("NOMBRE");
                dt.Columns.Add("ÁREA");
                dt.Columns.Add("SEDE");
                dt.Columns.Add("FECHA DE SOLICITUD");
                dt.Columns.Add("ESTADO");
                dt.Columns.Add("FECHA APROBACIÓN PENÚLTIMO NIVEL");
                dt.Columns.Add("FECHA APROBACIÓN ÚLTIMO NIVEL");

                var _result = await mediator.Send(new GetStaffRequestPrintQuery() { StaffRequestQueryFilter = staffRequestQueryFilter });

                switch (staffRequestQueryFilter.IdTypeStaffRequest)
                {
                    case 1:
                    case 2:
                    case 5:
                    case 6:
                    case 7:
                        dt.Columns.Add("FECHA INICIO");
                        dt.Columns.Add("HORA INICIO");
                        dt.Columns.Add("FECHA FIN");
                        dt.Columns.Add("HORA FIN");
                        dt.Columns.Add("DÍAS CALENDARIO");
                        dt.Columns.Add("DÍAS HÁBILES");

                        var listaTiempos = new List<StaffRequestTimeDto>();
                        listaTiempos = (List<StaffRequestTimeDto>)_result.Data;
                        foreach (var item in listaTiempos)
                        {
                            DataRow row = dt.NewRow();
                            row[0] = item.Id;
                            row[1] = item.TipoSolicitud;
                            row[2] = item.DNI;
                            row[3] = item.FullNameEmployee;
                            row[4] = item.Area;
                            row[5] = item.AreaCentroCosto;

                            row[6] = item.FechaSolicitud;
                            row[7] = item.StateName;
                            row[8] = item.FechaAprobPenultimoNivel;
                            row[9] = item.FechaAprobUltimoNivel;

                            row[10] = item.FechaInicio;
                            row[11] = item.HoraInicio;
                            row[12] = item.FechaFin;
                            row[13] = item.HoraFin;
                            row[14] = item.DiasCalendario;
                            row[15] = item.DiasHabiles;
                            dt.Rows.Add(row);
                        }
                        break;
                    case 3:
                    case 4:
                    case 9:
                        dt.Columns.Add("CAPITAL");
                        dt.Columns.Add("NRO. CUOTAS");
                        dt.Columns.Add("IMPORTE A PAGAR EN GRATI.");
                        dt.Columns.Add("IMPORTE A PAGAR EN UTI.");
                        dt.Columns.Add("CUOTA BRUTA MENSUAL");
                        dt.Columns.Add("PERIODO PRIMERA CUOTA");
                        dt.Columns.Add("PERIODO ÚLTIMA CUOTA");
                        dt.Columns.Add("TOTAL INT. + IGV");

                        var listaDineroLoan = new List<StaffRequestMoneyLoanDto>();
                        listaDineroLoan = (List<StaffRequestMoneyLoanDto>)_result.Data;
                        foreach (var item in listaDineroLoan)
                        {
                            DataRow row = dt.NewRow();
                            row[0] = item.Id;
                            row[1] = item.TipoSolicitud;
                            row[2] = item.DNI;
                            row[3] = item.FullNameEmployee;
                            row[4] = item.Area;
                            row[5] = item.AreaCentroCosto;

                            row[6] = item.FechaSolicitud;
                            row[7] = item.StateName;
                            row[8] = item.FechaAprobPenultimoNivel;
                            row[9] = item.FechaAprobUltimoNivel;

                            row[10] = item.Capital;
                            row[11] = item.NroCuotas;
                            row[12] = item.MontoGrati;
                            row[13] = item.MontoUti;
                            row[14] = item.CuotraBrutaMensual;
                            row[15] = item.PeriodoPrimeraCuota;
                            row[16] = item.PeriodoUltimaCuota;
                            row[17] = item.TotalintPlusIGV;
                            dt.Rows.Add(row);
                        }
                        break;

                    case 12:
                    case 13:
                        dt.Columns.Add("BANCO");
                        dt.Columns.Add("MONEDA");
                        dt.Columns.Add("CTA. BANCARIA");
                        dt.Columns.Add("CCI");

                        var listaDineroCuenta = new List<StaffRequestMoneyChange>();
                        listaDineroCuenta = (List<StaffRequestMoneyChange>)_result.Data;
                        foreach (var item in listaDineroCuenta)
                        {
                            DataRow row = dt.NewRow();
                            row[0] = item.Id;
                            row[1] = item.TipoSolicitud;
                            row[2] = item.DNI;
                            row[3] = item.FullNameEmployee;
                            row[4] = item.Area;
                            row[5] = item.AreaCentroCosto;
                            row[6] = item.FechaSolicitud;
                            row[7] = item.StateName;
                            row[8] = item.FechaAprobPenultimoNivel;
                            row[9] = item.FechaAprobUltimoNivel;

                            row[10] = item.Banco;
                            row[11] = item.Moneda;
                            row[12] = item.CuentaBancaria;
                            row[13] = item.CuentaCCI;
                            dt.Rows.Add(row);
                        }
                        break;

                    case 10:
                    case 14:
                        dt.Columns.Add("ACCIÓN");
                        dt.Columns.Add("TIPO SEGURO");
                        dt.Columns.Add("TIPO EPS");
                        dt.Columns.Add("BENEFICIARIO");

                        var listaAfiliacion = new List<StaffRequestSure>();
                        listaAfiliacion = (List<StaffRequestSure>)_result.Data;
                        foreach (var item in listaAfiliacion)
                        {
                            DataRow row = dt.NewRow();
                            row[0] = item.Id;
                            row[1] = item.TipoSolicitud;
                            row[2] = item.DNI;
                            row[3] = item.FullNameEmployee;
                            row[4] = item.Area;
                            row[5] = item.AreaCentroCosto;

                            row[6] = item.FechaSolicitud;
                            row[7] = item.StateName;
                            row[8] = item.FechaAprobPenultimoNivel;
                            row[9] = item.FechaAprobUltimoNivel;

                            row[10] = item.Acion;
                            row[11] = item.TipoSeguro;
                            row[12] = item.TipoEPS;
                            row[13] = item.Beneficiario;
                            dt.Rows.Add(row);
                        }
                        break;

                    case 11:
                        dt.Columns.Add("SERV. SEPULTURA");
                        dt.Columns.Add("SERV. FUNERARIO");
                        dt.Columns.Add("CER. INHUMACIÓN");
                        dt.Columns.Add("OTROS");
                        dt.Columns.Add("OBSERVACIONES");
                        var listaSepelio = new List<StaffRequestBurial>();
                        listaSepelio = (List<StaffRequestBurial>)_result.Data;
                        foreach (var item in listaSepelio)
                        {
                            DataRow row = dt.NewRow();
                            row[0] = item.Id;
                            row[1] = item.TipoSolicitud;
                            row[2] = item.DNI;
                            row[3] = item.FullNameEmployee;
                            row[4] = item.Area;
                            row[5] = item.AreaCentroCosto;
                            row[6] = item.FechaSolicitud;
                            row[7] = item.StateName;
                            row[8] = item.FechaAprobPenultimoNivel;
                            row[9] = item.FechaAprobUltimoNivel;

                            row[10] = item.ServicioSepultura;
                            row[11] = item.ServicioFunerario;
                            row[12] = item.CeremoniInhumacion;
                            row[13] = item.Otros;
                            row[14] = item.Observaciones;
                            dt.Rows.Add(row);
                        }
                        break;

                    case 17:
                        dt.Columns.Add("EVENTO");
                        dt.Columns.Add("ORGANIZADOR");
                        dt.Columns.Add("FECHA INICIO");
                        dt.Columns.Add("FECHA FIN");
                        dt.Columns.Add("HORARIO");
                        dt.Columns.Add("LUGAR");
                        dt.Columns.Add("CLASIFICACIÓN");
                        dt.Columns.Add("TIPO CAPACITACIÓN");
                        dt.Columns.Add("% A ASUMIR");
                        dt.Columns.Add("CONVENIO DE OTORGAMIENTO POR ASIGNACIÓN");

                        var listaCapacitacion = new List<StaffRequestCapacitation>();
                        listaCapacitacion = (List<StaffRequestCapacitation>)_result.Data;
                        foreach (var item in listaCapacitacion)
                        {
                            DataRow row = dt.NewRow();
                            row[0] = item.Id;
                            row[1] = item.TipoSolicitud;
                            row[2] = item.DNI;
                            row[3] = item.FullNameEmployee;
                            row[4] = item.Area;
                            row[5] = item.AreaCentroCosto;
                            row[6] = item.FechaSolicitud;
                            row[7] = item.StateName;
                            row[8] = item.FechaAprobPenultimoNivel;
                            row[9] = item.FechaAprobUltimoNivel;

                            row[10] = item.Evento;
                            row[11] = item.Organizador;
                            row[12] = item.FechaInicio;
                            row[13] = item.FechaFin;
                            row[14] = item.Horario;
                            row[15] = item.Lugar;
                            row[16] = "";
                            row[17] = "";
                            row[18] = "";
                            row[19] = "";
                            dt.Rows.Add(row);
                        }
                        break;
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
            catch (Exception ex)
            {
                if (System.IO.File.Exists(fullPath))
                {
                    System.IO.File.Delete(fullPath);
                }
                throw;
            }
        }

        [HttpPost("getlistpaginationbyuser")]
        public async Task<IActionResult> GetListPaginationByUser(StaffRequestQueryFilter staffRequestQueryFilter)
        {
            var list = await mediator.Send(new GetStaffRequestListPaginationByUserQuery() { StaffRequestQueryFilter = staffRequestQueryFilter });

            return Ok(list);
        }

        [HttpPost("deleteRequest")]
        public async Task<IActionResult> DeleteRequest(DeleteStaffRequestDto _request)
        {
            var list = await mediator.Send(new DeleteStaffRequestCommand() { Id = _request.nid_request });

            return Ok(list);
        }

        [HttpPost("getStaffRequestFromNotificacionById")]
        public async Task<IActionResult> getStaffRequestFromNotificacionById(StaffRequestFromNotificacionFilter filter)
        {
            var list = await mediator.Send(new GetStaffRequestFromNotificacionQuery() { filter = filter });

            return Ok(list);
        }

        [HttpPost("getStaffRequestValidateDaysAdelantoSueldo")]
        public async Task<IActionResult> getStaffRequestValidateDaysAdelantoSueldo(StaffRequestValidateDaysRequest filter)
        {
            var list = await mediator.Send(new GetStaffRequestValidateDaysAdelantoSueldoQuery() { filter = filter });

            return Ok(list);
        }
    }
}