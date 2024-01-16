using Dapper;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.Contracts;
using HumanManagement.Domain.StaffRequest.Contracts;
using HumanManagement.Domain.StaffRequest.Dto;
using HumanManagement.MsSql.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HumanManagement.MsSql.Repository.StaffRequest
{
    public class RequestMedicalRepository : IRequestMedicalRepository
    {
        private readonly IHumanManagementReadDbConnection humanManagementReadDbConnection;
        private readonly DbContextMsSql context;
        private readonly AppSettings _appSettings;
        private readonly ILogger<RequestMedicalRepository> _logger;
        public RequestMedicalRepository(IHumanManagementReadDbConnection humanManagementReadDbConnection, IOptions<AppSettings> appSettings,
                                      DbContextMsSql context, ILogger<RequestMedicalRepository> logger)
        {
            this.humanManagementReadDbConnection = humanManagementReadDbConnection;
            this.context = context;
            this._appSettings = appSettings.Value;
            this._logger = logger;
        }

        public async Task ChangeStateMedical(ValidChangeStateMedical payload)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid_medical", payload.nid_medical);
            queryParameters.Add("@nstate", payload.nstate);
            queryParameters.Add("@ntype", payload.ntype);

            var management = await humanManagementReadDbConnection.QueryAsync<ApprovedAdvacementDto>(
                 "sp_change_state_medical",
                 queryParameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<BossDto> Getboss(int person)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid_person", person);

            var management = await humanManagementReadDbConnection.QueryAsync<BossDto>(
                 "sp_get_boss",
                 queryParameters, commandType: CommandType.StoredProcedure);

            return management.ToList().FirstOrDefault();
        }

        public async Task<GetDaysDto> GetDays(int employee)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid_collaborator", employee);

            var management = await humanManagementReadDbConnection.QueryAsync<GetDaysDto>(
                 "sp_get_days_medical_byemployee",
                 queryParameters, commandType: CommandType.StoredProcedure);

            return management.ToList().FirstOrDefault();
        }

        public async Task<List<DocumentMedicalDto>> ListDocumentByMedical(int id)
        {
            var queryParameters = new DynamicParameters();

            queryParameters.Add("@nid_medical", id);

                var list = await humanManagementReadDbConnection.QueryAsync<DocumentMedicalDto>(
                 "sp_request_document_list",
                 queryParameters, commandType: CommandType.StoredProcedure);


            return list.ToList();
        }

        public async Task<List<MedicalDto>> ListMedical(FilterListDocumentDto staffRequestQueryFilter)
        {
            var queryParameters = new DynamicParameters();

            queryParameters.Add("@nid_employee", staffRequestQueryFilter.nid_employee);
            queryParameters.Add("@ntype", staffRequestQueryFilter.ntype);
            queryParameters.Add("@ddateinit", staffRequestQueryFilter.ddateinit);
            queryParameters.Add("@ddateend", staffRequestQueryFilter.ddateend);

            var list = await humanManagementReadDbConnection.QueryAsync<MedicalDto>(
                 "sp_request_medical_sel",
                 queryParameters, commandType: CommandType.StoredProcedure);


            return list.ToList();
        }

        public async Task<List<ListMedicalNotification>> ListMedicalNotification()
        {
            var list = await humanManagementReadDbConnection.QueryAsync<ListMedicalNotification>(
                 "sp_getperson_medical_notification",
                 commandType: CommandType.StoredProcedure);


            return list.ToList();
        }

        public async Task<MedicalDto> MedicalById(int id)
        {
            var queryParameters = new DynamicParameters();

            queryParameters.Add("@nid_medical", id);


            var list = await humanManagementReadDbConnection.QueryAsync<MedicalDto>(
                 "sp_request_medical_byId",
                 queryParameters, commandType: CommandType.StoredProcedure);


            return list.ToList().FirstOrDefault();
        }

        public async Task<ApprovalDateDto> GetApprovalDate(int id)
        {
            var queryParameters = new DynamicParameters();

            queryParameters.Add("@nid_employee", id);


            var list = await humanManagementReadDbConnection.QueryAsync<ApprovalDateDto>(
                 "sp_get_approval_date_request_medical",
                 queryParameters, commandType: CommandType.StoredProcedure);


            return list.ToList().FirstOrDefault();
        }

        public async Task RegisterDocumentMedical(RegisterDocumentMedicalDto payload, IFormFile file,bool bIsDraft)
        {
            try
            {
                var urlhost = _appSettings.PathSaveFile;
                string Folder = null;

                if (file != null)
                {
                    var filenamefolder = Path.Combine(urlhost, "File");
                    var Name = file.FileName;

                    Folder = $"{filenamefolder}\\{payload.nid_medical}_{payload.ndocument}_{DateTime.Now.ToString("yyyyMMddhhmmssffff")}_{file.FileName}";

                    //var NewFileName = filenamefolder + "\\" +  + file.FileName;

                    if (!Directory.Exists(filenamefolder))
                    {
                        Directory.CreateDirectory(filenamefolder);
                    }

                    using (var stream = new FileStream(Folder, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }

                _logger.LogError(string.Format("RegisterDocumentMedical => nid_medical: {0}, ntype_doc: {1}, ndocument: {2}, sfile: {3}", payload.nid_medical, payload.ntype_doc, payload.ndocument, Folder));

                var queryParameters = new DynamicParameters();
                queryParameters.Add("@nid_medical", payload.nid_medical);
                queryParameters.Add("@ntype_doc", payload.ntype_doc);
                queryParameters.Add("@ndocument", payload.ndocument);
                queryParameters.Add("@sfile", Folder);

                if (!bIsDraft)
                {
                    var management = await humanManagementReadDbConnection.QueryAsync<ApprovedAdvacementDto>(
                     "sp_request_medical_document_ins",
                     queryParameters, commandType: CommandType.StoredProcedure);
                }
                else
                {
                    var management = await humanManagementReadDbConnection.QueryAsync<ApprovedAdvacementDto>(
                   "sp_request_medical_document_draft",
                   queryParameters, commandType: CommandType.StoredProcedure);
                }
                

                
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("Exception RegisterDocumentMedical => {0}", Newtonsoft.Json.JsonConvert.SerializeObject(ex)));
            }
            
        }

        public async Task<int> RegisterMedical(RegisterMedicalDto payload)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@ntype", payload.ntype);
            queryParameters.Add("@nid_collaborator", payload.nid_collaborator);
            queryParameters.Add("@dregisterdm", payload.dregisterdm);
            queryParameters.Add("@dissuedm", payload.dissuedm);

            queryParameters.Add("@ddateinitdm", payload.ddateinitdm);
            queryParameters.Add("@ddateenddm", payload.ddateenddm);
            queryParameters.Add("@smedicaldiagnostic", payload.smedicaldiagnostic);
            queryParameters.Add("@srucclinic", payload.srucclinic);

            queryParameters.Add("@tuitiondoctor", payload.tuitiondoctor);
            queryParameters.Add("@noriginmedical", payload.noriginmedical);
            queryParameters.Add("@ntypedm", payload.ntypedm);

            queryParameters.Add("@scodtypeaction", payload.scodtypeaction);
            queryParameters.Add("@scodtypeabsence", payload.scodtypeabsence);

            queryParameters.Add("@scommitment", payload.scommitment);
            queryParameters.Add("@bisdraft", payload.bisDraft);
            
            queryParameters.Add("@nid", DbType.Int32, direction: ParameterDirection.Output);

            var management = await humanManagementReadDbConnection.QueryAsync<ApprovedAdvacementDto>(
                 "sp_request_medical_ins",
                 queryParameters, commandType: CommandType.StoredProcedure);

            int result = Convert.ToInt32(queryParameters.Get<int>("@nid"));
            return result;

        }

        public async Task RejectedMedical(RejectMedicalDto payload)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid_medical", payload.nid_medical);
            queryParameters.Add("@scomment", payload.scomment);
            
            var management = await humanManagementReadDbConnection.QueryAsync<ApprovedAdvacementDto>(
                 "sp_reject_medical",
                 queryParameters, commandType: CommandType.StoredProcedure);
        }


        public async Task UpdateStatusExactus(int nid_medical, bool bexistexatus, int nactionexactus)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid_medical", nid_medical);
            queryParameters.Add("@bexistexatus", bexistexatus);
            queryParameters.Add("@nactionexactus", nactionexactus);

            var management = await humanManagementReadDbConnection.QueryAsync<ApprovedAdvacementDto>(
                 "sp_request_medical_upd1",
                 queryParameters, commandType: CommandType.StoredProcedure);
        }



        public async Task<ReportAmountDto> ReportAmount()
        {

            var list = await humanManagementReadDbConnection.QueryAsync<ReportAmountDto>(
                 "sp_medical_report_amount",
                 commandType: CommandType.StoredProcedure);


            return list.ToList().FirstOrDefault();
        }

        public async Task<ReportGraficEtapa> ReportGraficByEtapa(DateTime ddateinit, DateTime ddateend)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@ddateinit", ddateinit);
            queryParameters.Add("@ddateend", ddateend);

            var list = await humanManagementReadDbConnection.QueryAsync<ReportGraficEtapa>(
                 "sp_report_medical_byetapa",
                 queryParameters, commandType: CommandType.StoredProcedure);


            return list.ToList().FirstOrDefault();
        }

        public async Task<List<ReportGraficStatus>> ReportGraficByStatus(DateTime ddateinit, DateTime ddateend)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@ddateinit", ddateinit);
            queryParameters.Add("@ddateend", ddateend);

            var list = await humanManagementReadDbConnection.QueryAsync<ReportGraficStatus>(
                 "sp_report_medical_bystate",
                 queryParameters, commandType: CommandType.StoredProcedure);


            return list.ToList();
        }

        public async Task UpdateAmount(UpdateAmountMedicalDto payload)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid_medical", payload.nid_medical);
            queryParameters.Add("@namount", payload.namount);
            queryParameters.Add("@nunreturnamount", payload.nunreturnamount);
            queryParameters.Add("@sobservationamount", payload.sobservationamount);

            var management = await humanManagementReadDbConnection.QueryAsync<ApprovedAdvacementDto>(
                 "sp_register_amount_medical",
                 queryParameters, commandType: CommandType.StoredProcedure);
        }

        public async Task UpdateCITT(UpdateCITTMedicalDto payload, IFormFile file)
        {
            if (file != null)
            {
                var urlhost = _appSettings.PathSaveFile;

                var filenamefolder = Path.Combine(urlhost, "File");
                var Name = file.FileName;
                var Folder = filenamefolder + file.FileName;

                if (!Directory.Exists(filenamefolder))
                {
                    Directory.CreateDirectory(filenamefolder);
                }

                using (var stream = new FileStream(Folder, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                var queryParameters = new DynamicParameters();
                queryParameters.Add("@nid_medical", payload.nid_medical);
                queryParameters.Add("@snumberCITT", payload.snumberCITT);
                queryParameters.Add("@snitt", payload.snitt);
                queryParameters.Add("@sobervationscitt", payload.sobervationscitt);
                queryParameters.Add("@ddateCIT", payload.ddateCIT);
                queryParameters.Add("@sfilecitt", Folder);

                var management = await humanManagementReadDbConnection.QueryAsync<ApprovedAdvacementDto>(
                     "sp_register_citt_medical",
                     queryParameters, commandType: CommandType.StoredProcedure);


            }
            else
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@nid_medical", payload.nid_medical);
                queryParameters.Add("@snumberCITT", payload.snumberCITT);
                queryParameters.Add("@snitt", payload.snitt);
                queryParameters.Add("@sobervationscitt", payload.sobervationscitt);
                queryParameters.Add("@sfilecitt", null);

                var management = await humanManagementReadDbConnection.QueryAsync<ApprovedAdvacementDto>(
                     "sp_register_citt_medical",
                     queryParameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task UpdateFile(UpdateFilesDto payload, IFormFile file)
        {
            var urlhost = _appSettings.PathSaveFile;

            var filenamefolder = Path.Combine(urlhost, "File");
            var Name = file.FileName;

            var NewFileName = filenamefolder + "\\" + DateTime.Now.ToString("yyyyMMddhhmmss.fffffffK") + file.FileName;

            if (!Directory.Exists(filenamefolder))
            {
                Directory.CreateDirectory(filenamefolder);
            }

            using (var stream = new FileStream(NewFileName, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid", payload.nid);

            queryParameters.Add("@sfilename", NewFileName);


            var management = await humanManagementReadDbConnection.QueryAsync<ApprovedAdvacementDto>(
                 "sp_request_document_edit",
                 queryParameters, commandType: CommandType.StoredProcedure);
        }

        public async Task UpdateVIVA(UpdateVIVAMedical payload, IFormFile file)
        {

            if (file != null)
            {
                var urlhost = _appSettings.PathSaveFile;

                var filenamefolder = Path.Combine(urlhost, "File");
                var Name = file.FileName;
                var Folder = filenamefolder + file.FileName;

                if (!Directory.Exists(filenamefolder))
                {
                    Directory.CreateDirectory(filenamefolder);
                }

                using (var stream = new FileStream(Folder, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                var queryParameters = new DynamicParameters();
                queryParameters.Add("@nid_medical", payload.nid_medical);
                queryParameters.Add("@soperationnumber", payload.soperationnumber); 
                queryParameters.Add("@snitt", payload.snitt); 
                queryParameters.Add("@sfileregisterviva", Folder);

                var management = await humanManagementReadDbConnection.QueryAsync<ApprovedAdvacementDto>(
                     "sp_register_viva_medical",
                     queryParameters, commandType: CommandType.StoredProcedure);


            }
            else
            {
                var queryParameters = new DynamicParameters();
                queryParameters.Add("@nid_medical", payload.nid_medical);
                queryParameters.Add("@soperationnumber", payload.soperationnumber);
                queryParameters.Add("@snitt", payload.snitt);
                queryParameters.Add("@sfileregisterviva", null);

                var management = await humanManagementReadDbConnection.QueryAsync<ApprovedAdvacementDto>(
                     "sp_register_viva_medical",
                     queryParameters, commandType: CommandType.StoredProcedure);
            }


        }

        public async Task ValidDocument(ValidDocumentMedicalDto payload)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid", payload.nid);
            queryParameters.Add("@nstate", payload.nstate);

            var management = await humanManagementReadDbConnection.QueryAsync<ApprovedAdvacementDto>(
                 "sp_change_state_document",
                 queryParameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<string> ValidateRegisterMedical(RegisterMedicalDto payload)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid_collaborator", payload.nid_collaborator);
            queryParameters.Add("@dissuedm", payload.dissuedm);
            queryParameters.Add("@ddateinitdm", payload.ddateinitdm);
            queryParameters.Add("@ddateenddm", payload.ddateenddm);
            queryParameters.Add("@smessage", "mensaje", DbType.String, direction: ParameterDirection.Output);

            var management = await humanManagementReadDbConnection.QueryAsync<ApprovedAdvacementDto>(
                 "sp_validate_request_medical_ins",
                 queryParameters, commandType: CommandType.StoredProcedure);

            string result = queryParameters.Get<string>("@smessage");
            return result;
        }

        public async Task ChangeStateMedicalEtapa1ToEtapa3(ValidChangeStateMedical payload)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid_medical", payload.nid_medical);

            var management = await humanManagementReadDbConnection.QueryAsync<ApprovedAdvacementDto>(
                 "sp_register_viva_medical_etapa1_to_etapa3",
                 queryParameters, commandType: CommandType.StoredProcedure);
        }

        public async Task RequestDocumentApproved(RequestDocumentApprovedDto payload)
        {

            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid_document_medical", payload.nid_document_medical);

            var management = await humanManagementReadDbConnection.QueryAsync<ApprovedAdvacementDto>(
                 "sp_request_document_approved",
                 queryParameters, commandType: CommandType.StoredProcedure);
        }



        public async Task<int> RequestDocumentObserve(int id,string scommentobserve)
        {
            var queryParameters = new DynamicParameters();

            queryParameters.Add("@nid_document_medical", id);
            queryParameters.Add("@scommentobserve", scommentobserve);
            

            var list = await humanManagementReadDbConnection.QueryAsync<int>(
             "sp_request_document_observe",
             queryParameters, commandType: CommandType.StoredProcedure);


            return 1;
        }

        public async Task UpdateStateRequestMedical(int id)
        {
            var queryParameters = new DynamicParameters();

            queryParameters.Add("@nid_medical", id);

            var list = await humanManagementReadDbConnection.QueryAsync<int>(
             "spu_request_medical_state",
             queryParameters, commandType: CommandType.StoredProcedure);
        }
    }
}
