using DocumentFormat.OpenXml.Packaging;
using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.Employee.Contracts;
using HumanManagement.Domain.Employee.Dto;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.Employee.Queries
{
    public class AcceptRequestQuery : IRequest<Result>
    {
        public AcceptRequest payload { get; set; }
        public class AcceptRequestQueryHandler : IRequestHandler<AcceptRequestQuery, Result>
        {
            private readonly IRquestRepository _employeeRepository;
            private readonly IBaseRepository<Domain.Notification.Model.NotificationModel> _baseNotification;
            private readonly AppSettings _appSettings;
            private readonly IHubContext<Notifications> _hubContext;
            private readonly ILogger<AcceptRequestQueryHandler> _logger;

            public AcceptRequestQueryHandler(IRquestRepository employeeRepository,IBaseRepository<Domain.Notification.Model.NotificationModel> baseNotification,
                                    IOptions<AppSettings> appSettings, IHubContext<Notifications> hubContext, ILogger<AcceptRequestQueryHandler> logger)
            {
                this._employeeRepository = employeeRepository;
                this._baseNotification = baseNotification;
                _appSettings = appSettings.Value;
                _hubContext = hubContext;
                this._logger = logger;
            }

            public async Task<Result> Handle(AcceptRequestQuery query, CancellationToken cancellationToken)
            {
                await _employeeRepository.AcceptRequest(query.payload);

                if ( query.payload.type == 12 )
                {
                    Domain.Notification.Model.NotificationModel newNotification = new Domain.Notification.Model.NotificationModel();

                    string fmt = File.ReadAllText(_appSettings.AceptRequestTemplateHtml);

                    switch (query.payload.ntypeseccion)
                    {
                        case 1:
                            fmt = fmt.Replace("[SOLICITUD]", "Dirección");
                            break;
                        case 2:
                            fmt = fmt.Replace("[SOLICITUD]", "Teléfono");
                            break;
                        case 3:
                            fmt = fmt.Replace("[SOLICITUD]", "Estado Civil");
                            break;
                        case 4:
                            fmt = fmt.Replace("[SOLICITUD]", "Licencias");
                            break;
                        case 5:
                            fmt = fmt.Replace("[SOLICITUD]", "Estudio");
                            break;
                        case 6:
                            fmt = fmt.Replace("[SOLICITUD]", "Esposa/Conviviente");
                            break;
                        case 7:
                            fmt = fmt.Replace("[SOLICITUD]", "Hijos");
                            break;
                    }

                    newNotification.IdArea = query.payload.nid_area;
                    newNotification.IdPerson = query.payload.nid_emisor; 
                    newNotification.IdReceptor = query.payload.nid_reseptor; 
                    newNotification.Subject = "Solicitud de Movimiento de Datos Aceptada";
                    newNotification.Body = fmt;
                    newNotification.SendDate = DateTime.Now;
                    newNotification.Active = true;

                    newNotification.Important = true;
                    newNotification.Favorite = true;

                    await _baseNotification.Add(newNotification);
                }

                if ( query.payload.type == 13 )
                {
                    Domain.Notification.Model.NotificationModel newNotification = new Domain.Notification.Model.NotificationModel();

                    string fmt = File.ReadAllText(_appSettings.AceptRequestDocumentHTML);
                    
                    string fullpath = string.Empty;
                    string PathDocumentsEmission = _appSettings.PATHSAVE;
                    string spathWord = string.Empty;
                    List<ReplaceEntity> lstReplaces = new List<ReplaceEntity>();
                    string rutaDowload = _appSettings.PATHDOWNLOAD;
                    string fichero = "";

                    _logger.LogInformation("query.payload.ntypeseccion: " + query.payload.ntypeseccion);
                    _logger.LogInformation("query.payload.nid_request.ToString(): " + query.payload.nid_request.ToString());
                    if ( query.payload.ntypeseccion  == 8 )
                    {
                        fichero = "Boleta_Pago";

                        fmt = fmt.Replace("[ID_REQUEST]", query.payload.nid_request.ToString());
                        fmt = fmt.Replace("[SOLICITUD]", "Boleta de Pago");

                        newNotification.IdArea = query.payload.nid_area;
                        newNotification.IdPerson = query.payload.nid_emisor; 
                        newNotification.IdReceptor = query.payload.nid_reseptor; 
                        newNotification.Subject = "Solicitud de Consulta de Documentos Aceptada: Boleta de Pago";
                        newNotification.Body = fmt;
                        newNotification.SendDate = DateTime.Now;
                        newNotification.Active = true;

                        newNotification.Important = true;
                        newNotification.Favorite = true;

                        await _baseNotification.Add(newNotification);

                    }

                    if ( query.payload.ntypeseccion == 9 )
                    {
                        fichero = "Certificado_5ta_categoria";

                        fmt = fmt.Replace("[ID_REQUEST]", query.payload.nid_request.ToString());
                        fmt = fmt.Replace("[SOLICITUD]", "Certificado 5ta Categoría");

                        newNotification.IdArea = query.payload.nid_area;
                        newNotification.IdPerson = query.payload.nid_emisor;
                        newNotification.IdReceptor = query.payload.nid_reseptor;
                        newNotification.Subject = "Solicitud de Consulta de Documentos Aceptada: Certificado 5ta Categoría";
                        newNotification.Body = fmt;
                        newNotification.SendDate = DateTime.Now;
                        newNotification.Active = true;

                        newNotification.Important = true;
                        newNotification.Favorite = true;

                        await _baseNotification.Add(newNotification);
                    }

                    if ( query.payload.ntypeseccion == 10 )
                    {
                        string mesCargo = string.Empty;
                        switch (query.payload.date.ToString("MM"))
                        {
                            case "01":
                                mesCargo = "Enero";
                                break;
                            case "02":
                                mesCargo = "Febrero";
                                break;
                            case "03":
                                mesCargo = "Marzo";
                                break;
                            case "04":
                                mesCargo = "Abril";
                                break;
                            case "05":
                                mesCargo = "Mayo";
                                break;
                            case "06":
                                mesCargo = "Junio";
                                break;
                            case "07":
                                mesCargo = "Julio";
                                break;
                            case "08":
                                mesCargo = "Agosto";
                                break;
                            case "09":
                                mesCargo = "Setiembre";
                                break;
                            case "10":
                                mesCargo = "Octubre";
                                break;
                            case "11":
                                mesCargo = "Noviembre";
                                break;
                            case "12":
                                mesCargo = "Diciembre";
                                break;
                        }

                        string mesActual = string.Empty;
                        switch (DateTime.Now.ToString("MM"))
                        {
                            case "01":
                                mesActual = "Enero";
                                break;
                            case "02":
                                mesActual = "Febrero";
                                break;
                            case "03":
                                mesActual = "Marzo";
                                break;
                            case "04":
                                mesActual = "Abril";
                                break;
                            case "05":
                                mesActual = "Mayo";
                                break;
                            case "06":
                                mesActual = "Junio";
                                break;
                            case "07":
                                mesActual = "Julio";
                                break;
                            case "08":
                                mesActual = "Agosto";
                                break;
                            case "09":
                                mesActual = "Setiembre";
                                break;
                            case "10":
                                mesActual = "Octubre";
                                break;
                            case "11":
                                mesActual = "Noviembre";
                                break;
                            case "12":
                                mesActual = "Diciembre";
                                break;
                        }

                        spathWord = _appSettings.Certificado.ToString();
                        lstReplaces.Add(new ReplaceEntity() { stag = "XXXNOMBRE", sreplacetext = query.payload.name });
                        lstReplaces.Add(new ReplaceEntity() { stag = "XXXDNI", sreplacetext = query.payload.dni });
                        lstReplaces.Add(new ReplaceEntity() { stag = "XXXFECHADIA", sreplacetext = query.payload.date.ToString("dd") });
                        lstReplaces.Add(new ReplaceEntity() { stag = "XXXFECHAMES", sreplacetext = mesCargo });
                        lstReplaces.Add(new ReplaceEntity() { stag = "XXXFECHAANIO", sreplacetext = query.payload.date.ToString("yyyy") });
                        lstReplaces.Add(new ReplaceEntity() { stag = "XXXCARGO", sreplacetext = query.payload.charger });
                        lstReplaces.Add(new ReplaceEntity() { stag = "XXXACTUALDIA", sreplacetext = DateTime.Now.ToString("dd") });
                        lstReplaces.Add(new ReplaceEntity() { stag = "XXXACTUALMES", sreplacetext = mesActual });
                        lstReplaces.Add(new ReplaceEntity() { stag = "XXXACTUALANIO", sreplacetext = DateTime.Now.ToString("yyyy") });
                        
                        fichero = string.Format("CONSTANCIA_TRABAJO_{0}", query.payload.nid_request);

                        if (spathWord != string.Empty)
                        {
                            if (File.Exists(spathWord))
                            {

                                bool exists = System.IO.Directory.Exists(PathDocumentsEmission);
                                if (!exists)
                                    System.IO.Directory.CreateDirectory(PathDocumentsEmission);
                                fullpath = string.Format("{0}{1}.docx", PathDocumentsEmission, fichero);

                                File.Copy(spathWord, fullpath);
                                if (File.Exists(fullpath))
                                {
                                    using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(fullpath, true))
                                    {
                                        string docText = null;
                                        using (StreamReader sr = new StreamReader(wordDoc.MainDocumentPart.GetStream()))
                                        {
                                            docText = sr.ReadToEnd();
                                        }
                                        foreach (var bean in lstReplaces)
                                        {
                                            string sNombreCampo = bean.stag;
                                            string sValorCampo = bean.sreplacetext;
                                            Regex regexText = new Regex(sNombreCampo);
                                            docText = regexText.Replace(docText, ReplaceSpecialCharacters(sValorCampo));
                                        }
                                        using (StreamWriter sw = new StreamWriter(wordDoc.MainDocumentPart.GetStream(FileMode.Create)))
                                        {
                                            sw.Write(docText);
                                        }
                                        wordDoc.Close();
                                    }
                                }

                            }
                        }

                        string rutaFullDownload = Path.Combine(rutaDowload, fichero + ".docx");

                        fmt = fmt.Replace("[URL]", rutaFullDownload);
                        fmt = fmt.Replace("[ID_REQUEST]", query.payload.nid_request.ToString());
                        fmt = fmt.Replace("[SOLICITUD]", "Constancia de Trabajo");

                        newNotification.IdArea = query.payload.nid_area;
                        newNotification.IdPerson = query.payload.nid_emisor;
                        newNotification.IdReceptor = query.payload.nid_reseptor;
                        newNotification.Subject = "Solicitud de Consulta de Documentos Aceptada: Constancia de Trabajo";
                        newNotification.Body = fmt;
                        newNotification.SendDate = DateTime.Now;
                        newNotification.Active = true;

                        newNotification.Important = true;
                        newNotification.Favorite = true;

                        await _baseNotification.Add(newNotification);
                    }


                    if (query.payload.ntypeseccion == 11)
                    {
                        fichero = "Certificado_CTS";

                      
                        fmt = fmt.Replace("[ID_REQUEST]", query.payload.nid_request.ToString());
                        fmt = fmt.Replace("[SOLICITUD]", "Certificado CTS");

                        newNotification.IdArea = query.payload.nid_area;
                        newNotification.IdPerson = query.payload.nid_emisor;
                        newNotification.IdReceptor = query.payload.nid_reseptor;
                        newNotification.Subject = "Solicitud de Consulta de Documentos Aceptada: Certificado CTS";
                        newNotification.Body = fmt;
                        newNotification.SendDate = DateTime.Now;
                        newNotification.Active = true;

                        newNotification.Important = true;
                        newNotification.Favorite = true;

                        await _baseNotification.Add(newNotification);
                    }


                    if (query.payload.ntypeseccion == 12)
                    {
                        fichero = "Certificado_Utilidades";

                        fmt = fmt.Replace("[ID_REQUEST]", query.payload.nid_request.ToString());
                        fmt = fmt.Replace("[SOLICITUD]", "Certificado de Utilidades");

                        newNotification.IdArea = query.payload.nid_area;
                        newNotification.IdPerson = query.payload.nid_emisor;
                        newNotification.IdReceptor = query.payload.nid_reseptor;
                        newNotification.Subject = "Solicitud de Consulta de Documentos Aceptada: Certificado de Utilidades";
                        newNotification.Body = fmt;
                        newNotification.SendDate = DateTime.Now;
                        newNotification.Active = true;

                        newNotification.Important = true;
                        newNotification.Favorite = true;

                        await _baseNotification.Add(newNotification);
                    }

                }

                string notification = Newtonsoft.Json.JsonConvert.SerializeObject(query.payload);
                await this._hubContext.Clients.All.SendAsync("enviar-todos", notification);
                return new Result
                {
                    StateCode = 200,
                    Data = "Acepto correctamente la solicitud"
                };
            }
        }

        private static string ReplaceSpecialCharacters(string str)
        {
            str = str.Replace("&", "&amp;");
            str = str.Replace("<", "&lt;");
            str = str.Replace(">", "&gt;");
            str = str.Replace("\"", "&quot;");
            str = str.Replace("'", "&apos;");
            return str.ToString();
        }
    }

    
}
