using HumanManagement.Application.Employee.Queries;
using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.Employee.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using System.IO;
using HumanManagement.Domain.Utils.Dto;

namespace HumanManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DownloadController : Controller
    {
        private readonly AppSettings _appSettings;
        private IMediator _mediatorInstance;
        protected IMediator mediator => _mediatorInstance ??= HttpContext.RequestServices.GetService<IMediator>();
        private readonly ILogger<DownloadController> _logger;

        public DownloadController(IOptions<AppSettings> appSettings, IMediator mediatorInstance, ILogger<DownloadController> logger)
        {
            _mediatorInstance = mediatorInstance;
            _appSettings = appSettings.Value;
            this._logger = logger;
        }

        
        [HttpPost("descargarPDF")]
        public async Task<IActionResult> descargarPDF(int id)
        {
            try
            {
                Result solicitud = await mediator.Send(new GetDataToSendDownloadDocumentQuery() { nid_request = id });
                GetDataToSendDownloadDocumentDto obj = (GetDataToSendDownloadDocumentDto)solicitud.Data;

                if(obj.ntypeseccion == 10)
                {
                    string PathDocumentsEmission = _appSettings.PATHSAVE;
                    byte[] bytes = System.IO.File.ReadAllBytes(string.Format("{0}CONSTANCIA_TRABAJO_{1}.docx", PathDocumentsEmission, id));
                    return new FileContentResult(bytes, "application/vnd.openxmlformats-officedocument.wordprocessingml.document");
                }

                var json = new
                {
                    empresa = obj.empresa,
                    tipo_reporte = obj.tipo_reporte,
                    empleado = obj.empleado,
                    fch_consulta = obj.fch_consulta
                };
                

                var clientId = _appSettings.ClientIdApiDocRRHH;
                var clientSecret = _appSettings.ClientSecretApiDocRRHH;
                var authenticationString = $"{clientId}:{clientSecret}";
                var base64EncodedAuthenticationString = Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(authenticationString));

                byte[] result = null;
                HttpWebRequest request;
                HttpWebResponse response;
                byte[] data = UTF8Encoding.UTF8.GetBytes(System.Text.Json.JsonSerializer.Serialize(json));
                _logger.LogInformation("json: " + System.Text.Json.JsonSerializer.Serialize(json));
                request = WebRequest.Create(_appSettings.UrlApiDocRRHH) as HttpWebRequest;
                request.Timeout = Convert.ToInt32(3000) * 1000;
                request.Method = "POST";
                request.ContentLength = data.Length;
                request.ContentType = "application/json; charset=utf-8";
                request.Headers.Add("Authorization", "Basic " + base64EncodedAuthenticationString);
                _logger.LogInformation("Authorization: " + base64EncodedAuthenticationString);
                _logger.LogInformation("Inicio send");
                using (Stream dataStream = request.GetRequestStream())
                {
                    dataStream.Write(data, 0, data.Length);
                    dataStream.Close();
                }

                try
                {
                    _logger.LogInformation("Inicio get response");
                    response = request.GetResponse() as HttpWebResponse;
                    using (Stream dataStream = response.GetResponseStream())
                    {
                        MemoryStream ms = new MemoryStream();
                        dataStream.CopyTo(ms);
                        result = ms.ToArray();
                        _logger.LogInformation("result : " + result.ToString());
                    }
                    _logger.LogInformation("Fin get response");
                }
                catch (Exception ex)
                {
                    _logger.LogInformation(string.Format("Error => ex: {0}, StackTrace: {1}", ex.Message, ex.StackTrace));
                }


                return new FileContentResult(result, "application/pdf");
            }
            catch (Exception ex)
            {
                _logger.LogError("[Start: Falló Comenzar Proceso]-[Error: " + ex.Message);
                _logger.LogError("[Start: Falló Comenzar Proceso]-[Error: " + ex.StackTrace);
                return new FileContentResult(null, "application/pdf");
            }
        }
    
        [HttpGet("getpdf/{id}")]
        public async Task<IActionResult> getPDF(int id)
        {

            Result solicitud = await mediator.Send(new GetDataToSendDownloadDocumentQuery() { nid_request = id });
            GetDataToSendDownloadDocumentDto obj = (GetDataToSendDownloadDocumentDto)solicitud.Data;

            if(obj.ntypeseccion == 10)
            {
                string PathDocumentsEmission = _appSettings.PATHSAVE;
                byte[] bytes = System.IO.File.ReadAllBytes(string.Format("{0}CONSTANCIA_TRABAJO_{1}.docx", PathDocumentsEmission, id));
                var file = new FileDto
                {
                    FileName = $"Constancia de Trabajo.docx",
                    File = bytes,
                    ContentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document"
                };

                var resul = new Result
                {
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                    Data = file
                };
                return Ok(resul);
            }

            var json = new
            {
                empresa = obj.empresa,
                tipo_reporte = obj.tipo_reporte,
                empleado = obj.empleado,
                fch_consulta = obj.fch_consulta
            };

            try
            {
                
                var clientId = _appSettings.ClientIdApiDocRRHH;
                var clientSecret = _appSettings.ClientSecretApiDocRRHH;
                var authenticationString = $"{clientId}:{clientSecret}";
                var base64EncodedAuthenticationString = Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(authenticationString));

                byte[] result = null;
                HttpWebRequest request;
                HttpWebResponse response;
                byte[] data = UTF8Encoding.UTF8.GetBytes(System.Text.Json.JsonSerializer.Serialize(json));
                _logger.LogInformation("json: " + System.Text.Json.JsonSerializer.Serialize(json));
                request = WebRequest.Create(_appSettings.UrlApiDocRRHH) as HttpWebRequest;
                request.Timeout = Convert.ToInt32(3000) * 1000;
                request.Method = "POST";
                request.ContentLength = data.Length;
                request.ContentType = "application/json; charset=utf-8";
                request.Headers.Add("Authorization", "Basic " + base64EncodedAuthenticationString);
                _logger.LogInformation("Authorization: " + base64EncodedAuthenticationString);
                _logger.LogInformation("Inicio send");
                using (Stream dataStream = request.GetRequestStream())
                {
                    dataStream.Write(data, 0, data.Length);
                    dataStream.Close();
                }

                try
                {
                    _logger.LogInformation("Inicio get response");
                    response = request.GetResponse() as HttpWebResponse;
                    using (Stream dataStream = response.GetResponseStream())
                    {
                        MemoryStream ms = new MemoryStream();
                        dataStream.CopyTo(ms);
                        result = ms.ToArray();
                        _logger.LogInformation("result                : " + result.ToString());
                    }
                    _logger.LogInformation("Fin get response");
                }
                catch (Exception ex)
                {
                    _logger.LogInformation(string.Format("Error => ex: {0}, StackTrace: {1}", ex.Message, ex.StackTrace));
                }

                var file = new FileDto
                {
                    FileName = $"Solicitud de {obj.empleado} {DateTime.Now.ToString("ddMMyyyy hhmmss")}.pdf",
                    File = result,
                    ContentType = "pdf"
                };

                var resul = new Result
                {
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                    Data = file
                };

                InsertRequestDocumentDto payload = new InsertRequestDocumentDto();
                payload.nid_person = id;
                await mediator.Send(new DownloadRequestDocumentQuery() { payload = payload });

                return Ok(resul);
            }
            catch (Exception ex)
            {
                _logger.LogError("[Start: Falló Comenzar Proceso]-[Error: " + ex.Message);
                _logger.LogError("[Start: Falló Comenzar Proceso]-[Error: " + ex.StackTrace);

                var file = new FileDto
                {
                    FileName = $"Solicitud de {obj.empleado} {DateTime.Now.ToString("ddMMyyyy hhmmss")}.pdf",
                    File = null,
                    ContentType = "pdf"
                };

                var resul = new Result
                {
                    StateCode = Constants.StateCodeResult.ERROR_EXCEPTION,
                    Data = file
                };

                return Ok(resul);

            }
        }

        [HttpGet("getdocumentbypath/{path}")]
        public async Task<IActionResult> GetDocumentByPath(string path)
        {
            Byte[] bytes5 = System.IO.File.ReadAllBytes(path);
            String file5 = Convert.ToBase64String(bytes5);

            return Ok(file5);
        }
    }
}
