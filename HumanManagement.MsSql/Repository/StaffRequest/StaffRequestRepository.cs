using HumanManagement.Domain.Common;
using HumanManagement.Domain.Contracts;
using HumanManagement.Domain.StaffRequest.Contracts;
using HumanManagement.Domain.StaffRequest.Dto;
using HumanManagement.MsSql.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Dapper;
using System.Data;
using Microsoft.AspNetCore.Http;
using System.IO;
using HumanManagement.CrossCutting.Utils;
using Microsoft.Extensions.Options;


namespace HumanManagement.MsSql.Repository.StaffRequest
{
    public class StaffRequestRepository : IStaffRequestRepository
    {
        private readonly IHumanManagementReadDbConnection humanManagementReadDbConnection;
        private readonly DbContextMsSql context;
        private readonly AppSettings _appSettings;
        public StaffRequestRepository(IHumanManagementReadDbConnection humanManagementReadDbConnection, IOptions<AppSettings> appSettings,
                                      DbContextMsSql context)
        {
            this.humanManagementReadDbConnection = humanManagementReadDbConnection;
            this.context = context;
            this._appSettings = appSettings.Value;
        }
        public async Task<StaffRequestDto> GetById(int id)
        {
            var result = await (from r in context.tb_staff_request
                                join t in context.tb_type_staff_request on r.IdTypeStaffRequest equals t.Id
                                join c in context.tb_charge on r.IdCharge equals c.Id
                                join a in context.tb_area on c.IdArea equals a.Id
                                join e in context.tb_company on c.IdEmpresa equals e.Id
                                join p in context.Employee on r.IdEmployee equals p.Id
                                join per in context.Person on p.IdPerson equals per.Id
                                
                                where r.Id == id
                                select new StaffRequestDto
                                {
                                    Id = r.Id,
                                    IdTypeStaffRequest = r.IdTypeStaffRequest,
                                    DateIssue = r.DateIssue,
                                    RegistryNumber = r.RegistryNumber,
                                    State = r.State,
                                    TypeStaffRequest = t.Name,
                                    Comment = r.Comment,
                                    StaffRequestEmployee = new StaffRequestEmployeeDto
                                    {
                                        IdEmployee = r.IdEmployee,
                                        IdPerson = p.IdPerson,
                                        IdCharge = r.IdCharge,
                                        Charge = c.NameCargo,
                                        IdArea = c.IdArea,
                                        Area = a.NameArea,
                                        Company = e.Descripcion,
                                        Code = p.CodEmployee,
                                        DateAdmissionEmployee = r.DateAdmission,
                                        Names = per.FirstName + " " + per.SecondName,
                                        LastName = per.LastName,
                                        MotherLastName = per.MotherLastName,
                                        FullNameComplete = per.FirstName + " " + (string.IsNullOrEmpty(per.SecondName)?"": per.SecondName) + " " + per.LastName+" "+ per.MotherLastName,
                                        Dni = per.Identification,
                                        Email = per.Email,
                                        PathSignature = p.Signature
                                    }
                                }).SingleOrDefaultAsync();
            result.SetStateName();
            result.SetIsAceeptOrRejected();

            return result;
        }

        public async Task<StaffRequestEmployeeDto> GetEmployeeById(int idEmployee)
        {
            var result = await(from p in context.Employee 
                               join per in context.Person on p.IdPerson equals per.Id
                               join c in context.tb_charge on p.IdPosition equals c.Id
                               join a in context.tb_area on c.IdArea equals a.Id
                               join e in context.tb_company on c.IdEmpresa equals e.Id
                               join m in context.MasterTable on p.SedeId equals m.Id into gj
                               from subsede in gj.DefaultIfEmpty()
                               where p.Id == idEmployee
                               select new StaffRequestEmployeeDto
                               {
                                   IdEmployee = p.Id,
                                   IdPerson = p.IdPerson,
                                   IdCharge = p.IdPosition,
                                   Charge = c.NameCargo,
                                   IdArea = a.Id,
                                   Area = a.NameArea,
                                   Company = e.Descripcion,
                                   Code = p.CodEmployee,
                                   DateAdmissionEmployee = p.AdmissionDate,
                                   Names = per.FirstName + " " + per.SecondName,
                                   LastName = per.LastName,
                                   MotherLastName = per.MotherLastName,
                                   Dni = per.Identification,
                                   RUC = e.Ruc,
                                   SedeId = p.SedeId,
                                   Sede = subsede.DescriptionValue ?? String.Empty,
                                   CodeBank=p.CodeBank,
                                   AccountBank=p.AccountBank,
                                   Cciaccount_bank=p.Cciaccount_bank,
                                   CurrencyAccountBank=p.CurrencyAccountBank,
                                   CodeBankCts=p.CodeBankCts,
                                   AccountCts=p.AccountCts,
                                   CurrencyCts=p.CurrencyCts,
                                   AfpCode=p.AfpCode

                               }).SingleOrDefaultAsync();

            return result;
        }

        public async Task<ResultPaginationListDto<StaffRequestListDto>> GetListPagination(StaffRequestQueryFilter staffRequestQueryFilter)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nidtypestaffrequest", staffRequestQueryFilter.IdTypeStaffRequest);
            queryParameters.Add("@dateissuestart", staffRequestQueryFilter.InitialIssueDate);
            queryParameters.Add("@dateissueend", staffRequestQueryFilter.FinalIssueDate);
            queryParameters.Add("@niduser", staffRequestQueryFilter.IdUser);
            queryParameters.Add("@nidcompany", staffRequestQueryFilter.IdCompany);
            queryParameters.Add("@nidarea", staffRequestQueryFilter.IdArea);
            queryParameters.Add("@nidstatus", staffRequestQueryFilter.IdStatus);
            queryParameters.Add("@nidemployee", staffRequestQueryFilter.IdEmployee);
            queryParameters.Add("@nidstatus_approve", staffRequestQueryFilter.IdStatusApprove);
            queryParameters.Add("@ncurrentpage", staffRequestQueryFilter.Pagination.CurrentPage);
            queryParameters.Add("@nitemsperPage", staffRequestQueryFilter.Pagination.ItemsPerPage); 
            queryParameters.Add("@nrecordcount", DbType.Int32, direction: ParameterDirection.Output);

           var list = await humanManagementReadDbConnection.QueryAsync<StaffRequestListDto>(
                 "sps_staff_request_get_list_pagination",
                 queryParameters, commandType: CommandType.StoredProcedure);

            int totalItems = Convert.ToInt32(queryParameters.Get<int>("@nrecordcount"));

            return new ResultPaginationListDto<StaffRequestListDto>
            {
                list = list.ToList(),
                TotalItems = totalItems,
                TotalPages = (int)Math.Ceiling((double)totalItems / staffRequestQueryFilter.Pagination.ItemsPerPage)
            };
        }


        public async Task<List<ListDatesByEmployeeDto>> GetDatesByEmployee(int Idemployee)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid_employee", Idemployee);

            var list = await humanManagementReadDbConnection.QueryAsync<ListDatesByEmployeeDto>(
                 "sps_staff_request_get_dates_by_employee",
                 queryParameters, commandType: CommandType.StoredProcedure);

            return list.ToList();
        }


        public async Task<List<ListIdPersonByChargerDto>> GetPersonByCharger(int Idcharger)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid_charger", Idcharger);

            var list = await humanManagementReadDbConnection.QueryAsync<ListIdPersonByChargerDto>(
                 "sp_staff_getperson_bycharger",
                 queryParameters, commandType: CommandType.StoredProcedure);

            return list.ToList();
        }
        
        public async Task<List<NotificationReceptorDto>> GetListReceptorForNotification(int idProfile, int idArea)
        {
            var result = await (from u in context.User
                                join pu in context.ProfileUser on u.Id equals pu.IdUser
                                join per in context.Person on u.IdPerson equals per.Id
                                join em in context.Employee on per.Id equals em.IdPerson
                                join c in context.tb_charge on em.IdPosition equals c.Id
                                where pu.IdProfile == idProfile && c.IdArea == ((pu.IdProfile == 2 || pu.IdProfile == 8) ? idArea : c.IdArea)
                                select new NotificationReceptorDto
                                {
                                    IdReceptor = u.IdPerson,
                                    IdArea = c.IdArea,
                                    EvaluatorFullName = per.FirstName + " " + per.LastName,
                                }).ToListAsync();

            return result;
        }

        public async Task<GetRequestAdvance> GetRequestAdvance(int idRequest)
        {
            var queryParameters = new DynamicParameters();

            queryParameters.Add("@nid_request", idRequest);


            var list = await humanManagementReadDbConnection.QueryAsync<GetRequestAdvance>(
                 "sp_staff_getrequestadvance",
                 queryParameters, commandType: CommandType.StoredProcedure);


            return list.ToList().FirstOrDefault();
        }

        public async Task<List<DetailRequestAdvacement>> GetDetailRequestAdvacement(int IdRequest)
        {
            var queryParameters = new DynamicParameters();

            queryParameters.Add("@nid_Request", IdRequest);


            var list = await humanManagementReadDbConnection.QueryAsync<DetailRequestAdvacement>(
                 "sp_staff_detail_request",
                 queryParameters, commandType: CommandType.StoredProcedure);


            return list.ToList();
        }

        public async Task ApprovedAdvacement(ApprovedAdvacementDto payload, bool IsFinish)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid_request", payload.nid_request);
            queryParameters.Add("@nid_charger", payload.nid_charger);
            queryParameters.Add("@nid_employee", payload.nid_employee);
            queryParameters.Add("@nlevel", payload.nlevel);
            queryParameters.Add("@IsFinish", IsFinish);

            var management = await humanManagementReadDbConnection.QueryAsync<ApprovedAdvacementDto>(
                 "sp_staff__approver_advacement",
                 queryParameters, commandType: CommandType.StoredProcedure);
        }

        public async Task RejectedAdvacement(RejectAdvacementDto payload)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid_request", payload.nid_request);
            queryParameters.Add("@nid_charger", payload.nid_charger);
            queryParameters.Add("@nid_employee", payload.nid_employee);
            queryParameters.Add("@nlevel", payload.nlevel);
            queryParameters.Add("@scoment", payload.comment);

            var management = await humanManagementReadDbConnection.QueryAsync<ApprovedAdvacementDto>(
                 "sp_staff__rejecte_advacement",
                 queryParameters, commandType: CommandType.StoredProcedure);
        }

        public async Task RegisterRequestMedical(RegisterRequestMedical payload, IFormFile file)
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
            queryParameters.Add("@nid_request", payload.nid_request);
            queryParameters.Add("@nid_collabotor", payload.nid_collaborator);
            queryParameters.Add("@dbroadcastdate", payload.dbroadcastdate);
            queryParameters.Add("@ddateinit", payload.ddateinit);
            queryParameters.Add("@ddateend", payload.ddateend);
            queryParameters.Add("@sdiagnosis", payload.sdiagnosis);
            queryParameters.Add("@sclinicruc", payload.sclinicruc);
            queryParameters.Add("@tutiondoctor", payload.tutiondoctor);
            queryParameters.Add("@originmedical", payload.originmedical);
            queryParameters.Add("@typemedical", payload.typemedical);
            queryParameters.Add("@listmedical", Folder);
            queryParameters.Add("@sdeliverycommitment", payload.sdeliverycommitment);
            queryParameters.Add("@semailsocialwelfare", payload.semailsocialwelfare);
            

            var management = await humanManagementReadDbConnection.QueryAsync<ApprovedAdvacementDto>(
                 "sp_staff_medical_ins",
                 queryParameters, commandType: CommandType.StoredProcedure);
        }

        public async Task RegisterRequestBurial(RegisterRequestBurial payload)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid_request", payload.nid_request);
            queryParameters.Add("@nid_collabotor", payload.nid_collaborator);
            queryParameters.Add("@ntypeservice", payload.ntypeservice);
            queryParameters.Add("@observations", payload.observations);
            queryParameters.Add("@bmeetrequirements", payload.bmeetrequirements);
            queryParameters.Add("@serviciosepultura", payload.serviciosepultura);
            queryParameters.Add("@serviciofunerario", payload.serviciofunerario);
            queryParameters.Add("@ceremoniainhumacion", payload.ceremoniainhumacion);
            queryParameters.Add("@serviciofunerarioporc", payload.StaffRequest.serviciofunerarioporc);
            queryParameters.Add("@otros", payload.otros);


            var management = await humanManagementReadDbConnection.QueryAsync<ApprovedAdvacementDto>(
                 "sp_staff_burial_ins",
                 queryParameters, commandType: CommandType.StoredProcedure);
        }

        public async Task RegisterRequestSalary(RegisterRequestSalary payload, IFormFile file, IFormFile fileFicha)
        {

            var urlhost = _appSettings.PathSaveFile;

            var filenamefolder = Path.Combine(urlhost, "File");
            var Name = file.FileName;
            var Folder = filenamefolder + file.FileName;
            var FolderFicha = filenamefolder + fileFicha.FileName;
            if (!Directory.Exists(filenamefolder))
            {
                Directory.CreateDirectory(filenamefolder);
            }

            using (var stream = new FileStream(Folder, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            using (var stream = new FileStream(FolderFicha, FileMode.Create))
            {
                fileFicha.CopyTo(stream);
            }

            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid_request", payload.nid_request);
            queryParameters.Add("@nid_collabotor", payload.nid_collaborator);
            queryParameters.Add("@ddatechange", payload.ddatechange);
            queryParameters.Add("@sbank", payload.sbank);
            queryParameters.Add("@saccountnumber", payload.saccountnumber);
            queryParameters.Add("@sdniurl", Folder);
            queryParameters.Add("@sfile", FolderFicha);
            queryParameters.Add("@saccountnumber_cci", payload.saccountccinumber);
            queryParameters.Add("@scurrency", payload.scurrency);
            queryParameters.Add("@sdestincurrency", payload.sdestincurrency);
            queryParameters.Add("@sbankdestin", payload.sbankdestin);

            var management = await humanManagementReadDbConnection.QueryAsync<ApprovedAdvacementDto>(
                 "sp_staff_salary_ins",
                 queryParameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<List<ListBank>> ListBank()
        {
            var list = await humanManagementReadDbConnection.QueryAsync<ListBank>(
                "sp_bank_list",
                commandType: CommandType.StoredProcedure);


            return list.ToList();
        }

        public async Task<GetStaffSalaryById> GetStaffSalaryById(int Id)
        {
            var queryParameters = new DynamicParameters();

            queryParameters.Add("@nid_request", Id);


            var list = await humanManagementReadDbConnection.QueryAsync<GetStaffSalaryById>(
                 "sp_request_salary_byId",
                 queryParameters, commandType: CommandType.StoredProcedure);


            return list.ToList().FirstOrDefault();
        }

        public async Task ApprovedSalary(ApprovedSalaryDto payload, bool IsFinish)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid_request", payload.nid_request);
            queryParameters.Add("@nid_charger", payload.nid_charger);
            queryParameters.Add("@nid_employee", payload.nid_employee);
            queryParameters.Add("@nlevel", payload.nlevel);
            queryParameters.Add("@IsFinish", IsFinish);

            var management = await humanManagementReadDbConnection.QueryAsync<ApprovedAdvacementDto>(
                 "sp_staff_approver_salary",
                 queryParameters, commandType: CommandType.StoredProcedure);
        }

        public async Task RejectSalary(RejectSalaryDto payload)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid_request", payload.nid_request);
            queryParameters.Add("@nid_charger", payload.nid_charger);
            queryParameters.Add("@nid_employee", payload.nid_employee);
            queryParameters.Add("@nlevel", payload.nlevel);
            queryParameters.Add("@scomment", payload.comment);

            var management = await humanManagementReadDbConnection.QueryAsync<ApprovedAdvacementDto>(
                 "sp_staff_reject_salary",
                 queryParameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<GetStaffBurialByIdDto> GetStaffBurialById(int Id)
        {
            var queryParameters = new DynamicParameters();

            queryParameters.Add("@nid_request", Id);


            var list = await humanManagementReadDbConnection.QueryAsync<GetStaffBurialByIdDto>(
                 "sp_request_burial_byId",
                 queryParameters, commandType: CommandType.StoredProcedure);


            return list.ToList().FirstOrDefault();
        }

        public async Task ApprovedBurial(ApprovedSalaryDto payload, bool IsFinish)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid_request", payload.nid_request);
            queryParameters.Add("@nid_charger", payload.nid_charger);
            queryParameters.Add("@nid_employee", payload.nid_employee);
            queryParameters.Add("@nlevel", payload.nlevel);
            queryParameters.Add("@IsFinish", IsFinish);
            queryParameters.Add("@serviciosepulturaporc", payload.serviciosepulturaporc);
            queryParameters.Add("@serviciofunerarioporc", payload.serviciofunerarioporc);
            queryParameters.Add("@ceremoniainhumacionporc", payload.ceremoniainhumacionporc);
            queryParameters.Add("@otrosporc", payload.otrosporc);

            var management = await humanManagementReadDbConnection.QueryAsync<ApprovedAdvacementDto>(
                 "sp_staff_approver_burial",
                 queryParameters, commandType: CommandType.StoredProcedure);
        }

        public async Task RejectBurial(RejectSalaryDto payload)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid_request", payload.nid_request);
            queryParameters.Add("@nid_charger", payload.nid_charger);
            queryParameters.Add("@nid_employee", payload.nid_employee);
            queryParameters.Add("@nlevel", payload.nlevel);
            queryParameters.Add("@scoment", payload.comment);

            var management = await humanManagementReadDbConnection.QueryAsync<ApprovedAdvacementDto>(
                 "sp_staff_reject_burial",
                 queryParameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<GetRequestMedicalById> GetRequestMedicalById(int Id)
        {
            var queryParameters = new DynamicParameters();

            queryParameters.Add("@nid_request", Id);


            var list = await humanManagementReadDbConnection.QueryAsync<GetRequestMedicalById>(
                 "sp_request_medical_byId",
                 queryParameters, commandType: CommandType.StoredProcedure);


            return list.ToList().FirstOrDefault();
        }

        public async Task ApprovedMedical(ApprovedSalaryDto payload, bool IsFinish)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid_request", payload.nid_request);
            queryParameters.Add("@nid_charger", payload.nid_charger);
            queryParameters.Add("@nid_employee", payload.nid_employee);
            queryParameters.Add("@nlevel", payload.nlevel);
            queryParameters.Add("@IsFinish", IsFinish);

            var management = await humanManagementReadDbConnection.QueryAsync<ApprovedAdvacementDto>(
                 "sp_staff_approver_medical",
                 queryParameters, commandType: CommandType.StoredProcedure);
        }

        public async Task RejectMedical(RejectSalaryDto payload)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid_request", payload.nid_request);
            queryParameters.Add("@nid_charger", payload.nid_charger);
            queryParameters.Add("@nid_employee", payload.nid_employee);
            queryParameters.Add("@nlevel", payload.nlevel);

            var management = await humanManagementReadDbConnection.QueryAsync<ApprovedAdvacementDto>(
                 "sp_staff_reject_medical",
                 queryParameters, commandType: CommandType.StoredProcedure);
        }

        public async Task RegisterRequestSure(RegisterRequestSure payload, IFormFile file) 
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
            queryParameters.Add("@nid_request", payload.nid_request);
            queryParameters.Add("@nid_collabotor", payload.nid_collaborator);
            queryParameters.Add("@Isaffiliate", payload.Isaffiliate);
            queryParameters.Add("@ntypesure", payload.ntypesure);
            queryParameters.Add("@nbeneficiary", payload.nbeneficiary);
            queryParameters.Add("@sfile", Folder);


            var management = await humanManagementReadDbConnection.QueryAsync<ApprovedAdvacementDto>(
                 "sp_staff_sure_ins",
                 queryParameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<GetStaffSureById> GetRequestSureById(int Id)
        {
            var queryParameters = new DynamicParameters();

            queryParameters.Add("@nid_request", Id);


            var list = await humanManagementReadDbConnection.QueryAsync<GetStaffSureById>(
                 "sp_staff_sure_byId",
                 queryParameters, commandType: CommandType.StoredProcedure);


            return list.ToList().FirstOrDefault();
        }

        public async Task ApprovedSure(ApprovedSureDto payload, bool IsFinish)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid_request", payload.nid_request);
            queryParameters.Add("@nid_charger", payload.nid_charger);
            queryParameters.Add("@nid_employee", payload.nid_employee);
            queryParameters.Add("@nlevel", payload.nlevel);
            queryParameters.Add("@IsFinish", IsFinish);

            var management = await humanManagementReadDbConnection.QueryAsync<ApprovedAdvacementDto>(
                 "sp_staff_approved_sure",
                 queryParameters, commandType: CommandType.StoredProcedure);
        }

        public async Task RejectSure(RejectSalaryDto payload)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid_request", payload.nid_request);
            queryParameters.Add("@nid_charger", payload.nid_charger);
            queryParameters.Add("@nid_employee", payload.nid_employee);
            queryParameters.Add("@nlevel", payload.nlevel);
            queryParameters.Add("@scoment", payload.comment);

            var management = await humanManagementReadDbConnection.QueryAsync<ApprovedAdvacementDto>(
                 "sp_staff_reject_sure",
                 queryParameters, commandType: CommandType.StoredProcedure);
        }

        public async Task RegisterRequestTypeSure(RegisterChangeSureDto payload, IFormFile file)
        {
            var urlhost = _appSettings.PathSaveFile;
            string Folder = string.Empty;

            if (file != null)
            {
                var filenamefolder = Path.Combine(urlhost, "FileCambioSeguro");
                var Name = file.FileName;
                 Folder = filenamefolder + file.FileName;

                if (!Directory.Exists(filenamefolder))
                {
                    Directory.CreateDirectory(filenamefolder);
                }

                using (var stream = new FileStream(Folder, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            

            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid_request", payload.nid_request);
            queryParameters.Add("@nid_collabotor", payload.nid_collaborator);
            queryParameters.Add("@nid_typesure", payload.ntypesure);
            queryParameters.Add("@nid_typeeps", payload.ntypeeps);
            queryParameters.Add("@nbeneficiary", payload.nbeneficiary);
            queryParameters.Add("@sfile", Folder);


            var management = await humanManagementReadDbConnection.QueryAsync<ApprovedAdvacementDto>(
                 "sp_staff_request_typesure_ins",
                 queryParameters, commandType: CommandType.StoredProcedure);
        }

        public async Task ApprovedTypeSure(ApprovedSalaryDto payload, bool IsFinish)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid_request", payload.nid_request);
            queryParameters.Add("@nid_charger", payload.nid_charger);
            queryParameters.Add("@nid_employee", payload.nid_employee);
            queryParameters.Add("@nlevel", payload.nlevel);
            queryParameters.Add("@IsFinish", IsFinish);

            var management = await humanManagementReadDbConnection.QueryAsync<ApprovedAdvacementDto>(
                 "sp_staff_approver_typesure",
                 queryParameters, commandType: CommandType.StoredProcedure);
        }

        public async Task RejectTypeSure(RejectSalaryDto payload)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid_request", payload.nid_request);
            queryParameters.Add("@nid_charger", payload.nid_charger);
            queryParameters.Add("@nid_employee", payload.nid_employee);
            queryParameters.Add("@nlevel", payload.nlevel);
            queryParameters.Add("@@scoment", payload.comment);

            var management = await humanManagementReadDbConnection.QueryAsync<ApprovedAdvacementDto>(
                 "sp_staff_reject_typesure",
                 queryParameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<GetRequestTypeSureById> GetRequestTypeSureById(int Id)
        {
            var queryParameters = new DynamicParameters();

            queryParameters.Add("@nid_request", Id);


            var list = await humanManagementReadDbConnection.QueryAsync<GetRequestTypeSureById>(
                 "sp_request_typesure_byid",
                 queryParameters, commandType: CommandType.StoredProcedure);


            return list.ToList().FirstOrDefault();
        }

        public async Task RegisterRequestHourExtra(RegisterHourExtraDto payload, IFormFile file)
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
            queryParameters.Add("@nid_request", payload.nid_request);
            queryParameters.Add("@nid_collabotor", payload.nid_collaborator);
            queryParameters.Add("@support", payload.support);
            queryParameters.Add("@dday", payload.dday);
            queryParameters.Add("@shourinit", payload.shourinit);
            queryParameters.Add("@shourfinish", payload.shourfinish);
            queryParameters.Add("@sfileUrl", Folder);

            var management = await humanManagementReadDbConnection.QueryAsync<ApprovedAdvacementDto>(
                 "sp_staff_hour_extra_ins",
                 queryParameters, commandType: CommandType.StoredProcedure);
        }

        public async Task ApprovedHourExtra(ApprovedSalaryDto payload, bool IsFinish)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid_request", payload.nid_request);
            queryParameters.Add("@nid_charger", payload.nid_charger);
            queryParameters.Add("@nid_employee", payload.nid_employee);
            queryParameters.Add("@nlevel", payload.nlevel);
            queryParameters.Add("@IsFinish", IsFinish);

            var management = await humanManagementReadDbConnection.QueryAsync<ApprovedAdvacementDto>(
                 "sp_staff_approver_hour_extra",
                 queryParameters, commandType: CommandType.StoredProcedure);
        }

        public async Task RejectHourExtra(RejectSalaryDto payload)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid_request", payload.nid_request);
            queryParameters.Add("@nid_charger", payload.nid_charger);
            queryParameters.Add("@nid_employee", payload.nid_employee);
            queryParameters.Add("@nlevel", payload.nlevel);

            var management = await humanManagementReadDbConnection.QueryAsync<ApprovedAdvacementDto>(
                 "sp_staff_reject_hour_extra",
                 queryParameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<GetRequestHourExtraById> GetRequestHourExtraById(int Id)
        {
            var queryParameters = new DynamicParameters();

            queryParameters.Add("@nid_request", Id);


            var list = await humanManagementReadDbConnection.QueryAsync<GetRequestHourExtraById>(
                 "sp_request_hour_extra_byId",
                 queryParameters, commandType: CommandType.StoredProcedure);


            return list.ToList().FirstOrDefault();
        }

        public async Task<List<EmployeeChildren>> ListEmployeeChildren(int Id, int IdEmployee)
        {
            var queryParameters = new DynamicParameters();

            queryParameters.Add("@nid_charge", Id);
            queryParameters.Add("@nid_employee", IdEmployee); 


            var list = await humanManagementReadDbConnection.QueryAsync<EmployeeChildren>(
                 "sp_staff_employee_children",
                 queryParameters, commandType: CommandType.StoredProcedure);


            return list.ToList();
        }

        public async Task<List<EmployeeChildren>> ListEmployeeReplacement(int Id)
        {
            var queryParameters = new DynamicParameters();

            queryParameters.Add("@nid_area", Id);

            var list = await humanManagementReadDbConnection.QueryAsync<EmployeeChildren>(
                 "sps_employee_replacement",
                 queryParameters, commandType: CommandType.StoredProcedure);


            return list.ToList();
        }

        public async Task RegisterRequestCapacitacionNueva(RegisterCapacitacionDto payload)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid_request", payload.nid_request);
            queryParameters.Add("@nid_collabotor", payload.nid_collaborator);
            queryParameters.Add("@ntypetraining", payload.ntypetraining);
            queryParameters.Add("@ntypemodality", payload.ntypemodality);
            queryParameters.Add("@sname", payload.sname);
            queryParameters.Add("@ddateinit", payload.ddateinit);

            queryParameters.Add("@ddateend", payload.ddateend);
            queryParameters.Add("@splace", payload.splace);
            queryParameters.Add("@starget", payload.starget);
            queryParameters.Add("@ncost", payload.ncost);
            queryParameters.Add("@spercentage", payload.spercentage);

            queryParameters.Add("@sagreement", payload.sagreement);
            queryParameters.Add("@nperiod", payload.nperiod);
            queryParameters.Add("@ntype", payload.ntype);

            var management = await humanManagementReadDbConnection.QueryAsync<ApprovedAdvacementDto>(
                 "sp_staff_training_ins",
                 queryParameters, commandType: CommandType.StoredProcedure);
        }

        public async Task RegisterRequestCapacitacionExtra(RegisterCapacitacionExtraDto payload)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid_request", payload.nid_request);
            queryParameters.Add("@nid_collabotor", payload.nid_collaborator);
            queryParameters.Add("@ntypetraining", payload.ntypetraining);
            queryParameters.Add("@ntypemodality", payload.ntypemodality);
            queryParameters.Add("@sname", payload.sname);
            queryParameters.Add("@sorganizer", payload.sorganizer);
            queryParameters.Add("@ddateinit", payload.ddateinit);

            queryParameters.Add("@ddateend", payload.ddateend);
            queryParameters.Add("@splace", payload.splace);
            queryParameters.Add("@schedule", payload.schedule);

            queryParameters.Add("@starget", payload.starget);
            queryParameters.Add("@ncostevent", payload.ncostevent);
            queryParameters.Add("@ncostpassage", payload.ncostpassage);
            queryParameters.Add("@ncostaccommodation", payload.ncostaccommodation);
            queryParameters.Add("@ncostfeeding", payload.ncostfeeding);
            queryParameters.Add("@sothercost", payload.sothercost);
            queryParameters.Add("@nothercost", payload.nothercost);
            queryParameters.Add("@sbenefits", payload.sbenefits);
            queryParameters.Add("@nannualbudget", payload.nannualbudget);
            queryParameters.Add("@nbudget", payload.nbudget);
            queryParameters.Add("@nsteppedout", payload.nsteppedout);
            queryParameters.Add("@ninvestment", payload.ninvestment);
            queryParameters.Add("@nnewbalance", payload.nnewbalance);
    
            var management = await humanManagementReadDbConnection.QueryAsync<ApprovedAdvacementDto>(
                 "sp_staff_training_extemporaneous_ins",
                 queryParameters, commandType: CommandType.StoredProcedure);
        }

        public async Task UpdateRequestCapacitacionExtra(RegisterCapacitacionExtraDto payload)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid_request", payload.nid_request);
            queryParameters.Add("@nid_collabotor", payload.nid_collaborator);
            queryParameters.Add("@ntypetraining", payload.ntypetraining);
            queryParameters.Add("@ntypemodality", payload.ntypemodality);
            queryParameters.Add("@sname", payload.sname);
            queryParameters.Add("@sorganizer", payload.sorganizer);
            queryParameters.Add("@ddateinit", payload.ddateinit);

            queryParameters.Add("@ddateend", payload.ddateend);
            queryParameters.Add("@splace", payload.splace);
            queryParameters.Add("@schedule", payload.schedule);

            queryParameters.Add("@starget", payload.starget);
            queryParameters.Add("@ncostevent", payload.ncostevent);
            queryParameters.Add("@ncostpassage", payload.ncostpassage);
            queryParameters.Add("@ncostaccommodation", payload.ncostaccommodation);
            queryParameters.Add("@ncostfeeding", payload.ncostfeeding);
            queryParameters.Add("@sothercost", payload.sothercost);
            queryParameters.Add("@nothercost", payload.nothercost);
            queryParameters.Add("@sbenefits", payload.sbenefits);
            queryParameters.Add("@nannualbudget", payload.nannualbudget);
            queryParameters.Add("@nbudget", payload.nbudget);
            queryParameters.Add("@nsteppedout", payload.nsteppedout);
            queryParameters.Add("@ninvestment", payload.ninvestment);
            queryParameters.Add("@nnewbalance", payload.nnewbalance);

            var management = await humanManagementReadDbConnection.QueryAsync<ApprovedAdvacementDto>(
                 "sp_staff_training_extemporaneous_upd",
                 queryParameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<GetStaffCapacitationNuevByIdDto> GetRequestCapacitacionNuevaById(int Id)
        {
            var queryParameters = new DynamicParameters();

            queryParameters.Add("@nid_request", Id);


            var list = await humanManagementReadDbConnection.QueryAsync<GetStaffCapacitationNuevByIdDto>(
                 "sp_staff_training_new_byId",
                 queryParameters, commandType: CommandType.StoredProcedure);


            return list.ToList().FirstOrDefault();
        }

        public async Task ApprovedTrainingNew(ApprovedSalaryDto payload, bool IsFinish)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid_request", payload.nid_request);
            queryParameters.Add("@nid_charger", payload.nid_charger);
            queryParameters.Add("@nid_employee", payload.nid_employee);
            queryParameters.Add("@nlevel", payload.nlevel);
            queryParameters.Add("@IsFinish", IsFinish);

            var management = await humanManagementReadDbConnection.QueryAsync<ApprovedAdvacementDto>(
                 "sp_staff_approver_training_new",
                 queryParameters, commandType: CommandType.StoredProcedure);
        }

        public async Task RejectTrainingNew(RejectSalaryDto payload)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid_request", payload.nid_request);
            queryParameters.Add("@nid_charger", payload.nid_charger);
            queryParameters.Add("@nid_employee", payload.nid_employee);
            queryParameters.Add("@nlevel", payload.nlevel);
            queryParameters.Add("@scoment", payload.comment);

            var management = await humanManagementReadDbConnection.QueryAsync<ApprovedAdvacementDto>(
                 "sp_staff_rejecte_training_new",
                 queryParameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<GetStaffCapacitationExtraByIdDto> GetRequestCapacitacionExtraById(int Id)
        {
            var queryParameters = new DynamicParameters();

            queryParameters.Add("@nid_request", Id);


            var list = await humanManagementReadDbConnection.QueryAsync<GetStaffCapacitationExtraByIdDto>(
                 "sp_staff_training_extra_byId",
                 queryParameters, commandType: CommandType.StoredProcedure);


            return list.ToList().FirstOrDefault();
        }

        public async Task ApprovedTrainingExtra(ApprovedSalaryDto payload, bool IsFinish)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid_request", payload.nid_request);
            queryParameters.Add("@nid_charger", payload.nid_charger);
            queryParameters.Add("@nid_employee", payload.nid_employee);
            queryParameters.Add("@nlevel", payload.nlevel);
            queryParameters.Add("@IsFinish", IsFinish);

            var management = await humanManagementReadDbConnection.QueryAsync<ApprovedAdvacementDto>(
                 "sp_staff_approver_training_extra",
                 queryParameters, commandType: CommandType.StoredProcedure);
        }

        public async Task RejectTrainingExtra(RejectSalaryDto payload)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid_request", payload.nid_request);
            queryParameters.Add("@nid_charger", payload.nid_charger);
            queryParameters.Add("@nid_employee", payload.nid_employee);
            queryParameters.Add("@nlevel", payload.nlevel);
            queryParameters.Add("@scoment", payload.comment);

            var management = await humanManagementReadDbConnection.QueryAsync<ApprovedAdvacementDto>(
                 "sp_staff_rejecte_training_extra",
                 queryParameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<List<CategoryRequest>> ListCategoryRequest()
        {
            var list = await humanManagementReadDbConnection.QueryAsync<CategoryRequest>(
                "staff.sp_category_request_select",
                commandType: CommandType.StoredProcedure);

            return list.ToList();
        }

        public async Task<List<ListRequestByCategory>> ListRequestByCategory(int Id)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid_category", Id);

            var list = await humanManagementReadDbConnection.QueryAsync<ListRequestByCategory>(
                 "staff.sp_getrequest_bycategory",
                 queryParameters, commandType: CommandType.StoredProcedure);
             
            return list.ToList();
        }

        public async Task<Object> GetListRequestPrint(StaffRequestQueryFilter staffRequestQueryFilter)
        {
            var queryParameters = new DynamicParameters();
            var _procedure = "sps_staff_request_get_to_print";
            queryParameters.Add("@nidtypestaffrequest", staffRequestQueryFilter.IdTypeStaffRequest);
            queryParameters.Add("@dateissuestart", staffRequestQueryFilter.InitialIssueDate);
            queryParameters.Add("@dateissueend", staffRequestQueryFilter.FinalIssueDate);
            queryParameters.Add("@niduser", staffRequestQueryFilter.IdUser);
            queryParameters.Add("@nidcompany", staffRequestQueryFilter.IdCompany);
            queryParameters.Add("@nidarea", staffRequestQueryFilter.IdArea);
            queryParameters.Add("@nidstatus", staffRequestQueryFilter.IdStatus);
            switch (staffRequestQueryFilter.IdTypeStaffRequest)
            {
                case 1:
                case 2:
                case 5:
                case 6:
                case 7:
                    var listaTiempos = await humanManagementReadDbConnection.QueryAsync<StaffRequestTimeDto>(
                                    _procedure,
                                    queryParameters, commandType: CommandType.StoredProcedure);
                    return listaTiempos.ToList();
                case 3:
                case 4:
                case 9:
                    var listaDineroPrestamos = await humanManagementReadDbConnection.QueryAsync<StaffRequestMoneyLoanDto>(
                                    _procedure,
                                    queryParameters, commandType: CommandType.StoredProcedure);
                    return listaDineroPrestamos.ToList();
                case 12:
                case 13:
                    var listaDineroCambio = await humanManagementReadDbConnection.QueryAsync<StaffRequestMoneyChange>(
                                    _procedure,
                                    queryParameters, commandType: CommandType.StoredProcedure);
                    return listaDineroCambio.ToList();
                case 10:
                case 14:
                    var listaAfiliacion = await humanManagementReadDbConnection.QueryAsync<StaffRequestSure>(
                                    _procedure,
                                    queryParameters, commandType: CommandType.StoredProcedure);
                    return listaAfiliacion.ToList();

                case 11:
                    var listaSepelio = await humanManagementReadDbConnection.QueryAsync<StaffRequestBurial>(
                                    _procedure,
                                    queryParameters, commandType: CommandType.StoredProcedure);
                    return listaSepelio.ToList();

                case 17:
                    var listaCapacitacion = await humanManagementReadDbConnection.QueryAsync<StaffRequestCapacitation>(
                                    _procedure,
                                    queryParameters, commandType: CommandType.StoredProcedure);
                    return listaCapacitacion.ToList();
            }
            return new List<Object>();
        }

        public async Task<ResultPaginationListDto<StaffRequestListDto>> GetListPaginationByUser(StaffRequestQueryFilter staffRequestQueryFilter)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nidtypestaffrequest", staffRequestQueryFilter.IdTypeStaffRequest);
            queryParameters.Add("@dateissuestart", staffRequestQueryFilter.InitialIssueDate);
            queryParameters.Add("@dateissueend", staffRequestQueryFilter.FinalIssueDate);
            queryParameters.Add("@niduser", staffRequestQueryFilter.IdUser);
            queryParameters.Add("@nidcompany", staffRequestQueryFilter.IdCompany);
            queryParameters.Add("@nidarea", staffRequestQueryFilter.IdArea);
            queryParameters.Add("@nidemployee", staffRequestQueryFilter.IdEmployee);
            queryParameters.Add("@nidstatus", staffRequestQueryFilter.IdStatus);
            queryParameters.Add("@ncurrentpage", staffRequestQueryFilter.Pagination.CurrentPage);
            queryParameters.Add("@nitemsperPage", staffRequestQueryFilter.Pagination.ItemsPerPage);
            queryParameters.Add("@nrecordcount", DbType.Int32, direction: ParameterDirection.Output);

            var list = await humanManagementReadDbConnection.QueryAsync<StaffRequestListDto>(
                  "sps_staff_request_get_list_pagination_by_user",
                  queryParameters, commandType: CommandType.StoredProcedure);

            int totalItems = Convert.ToInt32(queryParameters.Get<int>("@nrecordcount"));

            return new ResultPaginationListDto<StaffRequestListDto>
            {
                list = list.ToList(),
                TotalItems = totalItems,
                TotalPages = (int)Math.Ceiling((double)totalItems / staffRequestQueryFilter.Pagination.ItemsPerPage)
            };
        }

        public async Task<List<NotificationReceptorDto>> GetListReceptorForNotificationBoss(int idProfile, int idArea, int idEmployee)
        {
            //var result = await(from u in context.User
            //                   join pu in context.ProfileUser on u.Id equals pu.IdUser
            //                   join per in context.Person on u.IdPerson equals per.Id
            //                   join em in context.Employee on per.Id equals em.IdPerson
            //                   join c in context.tb_charge on em.IdPosition equals c.Id
            //                   where pu.IdProfile == idProfile && c.IdArea == ((pu.IdProfile == 2 || pu.IdProfile == 8) ? idArea : c.IdArea)
            //                   select new NotificationReceptorDto
            //                   {
            //                       IdReceptor = u.IdPerson,
            //                       IdArea = c.IdArea,
            //                       EvaluatorFullName = per.FirstName + " " + per.LastName,
            //                   }).ToListAsync();

            //return result;

            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid_profile", idProfile);
            queryParameters.Add("@nid_area", idArea);
            queryParameters.Add("@nid_employee", idEmployee);

            var list = await humanManagementReadDbConnection.QueryAsync<NotificationReceptorDto>(
                 "sp_staff_get_notification_boss",
                 queryParameters, commandType: CommandType.StoredProcedure);

            return list.ToList();
        }

        public async Task DeleteStaffRequest(int Id)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid_request", Id);

            var management = await humanManagementReadDbConnection.QueryAsync<ApprovedAdvacementDto>(
                 "sp_staff_delete_request",
                 queryParameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<StaffRequestListDto> GetStaffRequestFromNotificacion(StaffRequestFromNotificacionFilter filter)
        {

            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid_staffrequest", filter.nid_staff_request);
            queryParameters.Add("@nid_user", filter.nid_user);
            var list = await humanManagementReadDbConnection.QueryAsync<StaffRequestListDto>(
                  "dbo.sps_staff_request_by_id",
                  queryParameters, commandType: CommandType.StoredProcedure);


            return list.ToList().FirstOrDefault();
        }
        public async Task<StaffRequestValidateDaysDto> GetStaffRequestValidateDaysAdelantoSueldo(int nid_employee)
        {
            StaffRequestValidateDaysDto result=new StaffRequestValidateDaysDto();
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nidemployee", nid_employee);
            //queryParameters.Add("@nid_user", filter.nid_user);
            var list = await humanManagementReadDbConnection.QueryAsync<StaffRequestValidateDaysDto>(
                  "dbo.sps_staff_request_validate_days_adelanto_sueldo",
                  queryParameters, commandType: CommandType.StoredProcedure);
            if (list.Count()==0)
            {
                result.nid_collaborator = nid_employee;
                result.nid_advancement = 0;
                result.ntotal_dias = 0;
                result.bexistsregister = false;
            }
            else
            {
                result = list.ToList().FirstOrDefault();
                result.bexistsregister = true;
            }
            return result;
        }

    }
}
