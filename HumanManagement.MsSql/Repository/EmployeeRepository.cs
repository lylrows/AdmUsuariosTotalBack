using Dapper;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.BaseDto;
using HumanManagement.Domain.Common;
using HumanManagement.Domain.Contracts;
using HumanManagement.Domain.Employee.Contracts;
using HumanManagement.Domain.Employee.Dto;
using HumanManagement.Domain.Employee.Models;
using HumanManagement.Domain.Person.Dto;
using HumanManagement.MsSql.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

using System.Threading.Tasks;

namespace HumanManagement.MsSql.Repository
{
    public class EmployeeRepository : BaseRepository<EmployeeModel>, IEmployeeRepository
    {
        private readonly IHumanManagementReadDbConnection humanManagementReadDbConnection;
        private readonly AppSettings _appSettings;
        private readonly ILogger<EmployeeRepository> _logger;

        public EmployeeRepository(IHumanManagementReadDbConnection humanManagementReadDbConnection, IOptions<AppSettings> appSettings
            , DbContextMsSql context, ILogger<EmployeeRepository> logger) : base(context)
        {
            this.humanManagementReadDbConnection = humanManagementReadDbConnection;
            this._appSettings = appSettings.Value;
            this._logger = logger;
        }

        public async Task<EmployeeDetailtDto> GetDetailEmployee(int nid_person)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid_person", nid_person);
            var employee = await humanManagementReadDbConnection.QueryAsync<EmployeeDetailtDto>(
                "sp_employee_byId",
                queryParameters, commandType: CommandType.StoredProcedure);

            
            return (EmployeeDetailtDto)employee[0];
        }

        public async Task<EmployeFileDto> GetEmployeeFile(int nid_employee)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid_employee", nid_employee);

            var employeefile = await humanManagementReadDbConnection.QueryAsync<EmployeFileDto>(
                "sp_employee_file_byid",
                queryParameters, commandType: CommandType.StoredProcedure);

            return (EmployeFileDto)employeefile[0];
        }

        public async Task<List<ListCompanyComboDto>> GetListCompanyCombo()
        {
            var listcompany = await humanManagementReadDbConnection.QueryAsync<ListCompanyComboDto>(
                "sp_company_list",
                commandType: CommandType.StoredProcedure);

            return listcompany.ToList();
        }

        public async Task<ResultPaginationListDto<EmployeeDto>> GetListEmployee(string sidentification, string sfullname, int nid_company, int nid_position,int nid_state, int currentPage, int itemsPerPage, int totalItems, int totalPages, int totalRows)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@sidentification", sidentification);
            queryParameters.Add("@sfullname", sfullname);
            queryParameters.Add("@nid_company", nid_company);
            queryParameters.Add("@nid_position", nid_position);
            queryParameters.Add("@nid_state", nid_state);
            queryParameters.Add("@ncurrentpage", currentPage);
            queryParameters.Add("@nitemsperPage", itemsPerPage);
            queryParameters.Add("@nrecordcount", DbType.Int32, direction: ParameterDirection.Output);

            var listUSer = await humanManagementReadDbConnection.QueryAsync<EmployeeDto>(
                 "sp_employee_list",
                 queryParameters, commandType: CommandType.StoredProcedure);

            ResultPaginationListDto<EmployeeDto> result = new ResultPaginationListDto<EmployeeDto>();
            result.list = listUSer.ToList();

            result.TotalItems = Convert.ToInt32(queryParameters.Get<int>("@nrecordcount"));
            result.TotalPages = (int)Math.Ceiling((double)result.TotalItems / itemsPerPage);

            return result;
        }
        public async Task<ResultPaginationListDto<EmployeeDto>> GetAllEmployee()
        {
            var queryParameters = new DynamicParameters();
            var listUSer = await humanManagementReadDbConnection.QueryAsync<EmployeeDto>(
                 "sp_employee_list_nopage",
                 queryParameters, commandType: CommandType.StoredProcedure);

            ResultPaginationListDto<EmployeeDto> result = new ResultPaginationListDto<EmployeeDto>();
            result.list = listUSer.ToList();

            return result;
        }


        public async Task<List<ListPositionComboDto>> GetListPositionCombo(int nid_company)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid_company", nid_company);
            var listposition = await humanManagementReadDbConnection.QueryAsync<ListPositionComboDto>(
                 "sp_charge_list_bycompany",
                 queryParameters, commandType: CommandType.StoredProcedure);

            return listposition.ToList();
            
        }

        public async Task UpdateEmployee(UpdateEmployeeDto payload)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid_person", payload.nid_person);
            queryParameters.Add("@scodperson", payload.scodperson);
            queryParameters.Add("@sfirstname", payload.sfirstname);
            queryParameters.Add("@ssecondname", payload.ssecondname);
            queryParameters.Add("@slastname", payload.slastname);
            queryParameters.Add("@smotherlastname", payload.smotherlastname);
            queryParameters.Add("@semail", payload.semail);
            queryParameters.Add("@nid_sex", payload.nid_sex > 0 ? payload.nid_sex : (int?)null);
            queryParameters.Add("@sbloodtype", payload.sbloodtype);
            queryParameters.Add("@sidentification", payload.sidentification);
            queryParameters.Add("@spassport", payload.spassport);
            queryParameters.Add("@dbirthdate", payload.dbirthdate);
            queryParameters.Add("@nid_nationality", payload.nid_nationality);
            queryParameters.Add("@nid_civilstatus", payload.nid_civilstatus);
            queryParameters.Add("@bitisnotdomiciled", payload.bitisnotdomiciled);
            queryParameters.Add("@sdrivinglicense", payload.sdrivinglicense);
            queryParameters.Add("@duniversitygraduationdate", payload.duniversitygraduationdate);
            queryParameters.Add("@dcountryentrydate", payload.dcountryentrydate);
            queryParameters.Add("@smedicalstaff", payload.smedicalstaff);
            queryParameters.Add("@nid_active", payload.nid_active);
            queryParameters.Add("@simg", payload.simg);

            queryParameters.Add("@email", payload.email);
            queryParameters.Add("@semergency_contact_name", payload.semergency_contact_name);
	        queryParameters.Add("@semergency_contact_phone", payload.semergency_contact_phone); 

            queryParameters.Add("@nid_employee", payload.nid_employee);
            queryParameters.Add("@scodemployee", payload.scodemployee);
            queryParameters.Add("@nid_position", payload.nid_position);
            queryParameters.Add("@nid_company", payload.nid_company);
            queryParameters.Add("@plaza", payload.plaza);
            queryParameters.Add("@nid_costcenter", payload.nid_costcenter);
            queryParameters.Add("@ddateoffirstadmission", payload.ddateoffirstadmission);
            queryParameters.Add("@dadmissiondate", payload.dadmissiondate);
            queryParameters.Add("@ddeparturedate", payload.ddeparturedate);
            queryParameters.Add("@nid_payroll", payload.nid_payroll);
            queryParameters.Add("@bdependents", payload.bdependents);
            queryParameters.Add("@snit", payload.snit);
            queryParameters.Add("@dcompanyseniority", payload.dcompanyseniority);
            queryParameters.Add("@dgovernmentseniority", payload.dgovernmentseniority);
            queryParameters.Add("@nid_state", payload.nid_state);
            queryParameters.Add("@sinsurednumbers", payload.sinsurednumbers);
            queryParameters.Add("@stypeinsurance", payload.stypeinsurance);
            queryParameters.Add("@shealthpermit", payload.shealthpermit);

            queryParameters.Add("@smerit", payload.smerit);
	        queryParameters.Add("@sdemerit", payload.sdemerit);
	        queryParameters.Add("@scorporatemail", payload.scorporatemail);
	        queryParameters.Add("@sannexed", payload.sannexed);
	        queryParameters.Add("@sheavymachinerylicense", payload.sheavymachinerylicense);
	        queryParameters.Add("@sddriverlicense", payload.sddriverlicense);
	        queryParameters.Add("@snamewife_partner", payload.snamewife_partner);
	        queryParameters.Add("@ddateofmarriage", payload.ddateofmarriage);
            queryParameters.Add("@scovidcard", payload.scovidcard); 

            queryParameters.Add("@nid_employee_file", payload.nid_employee_file);
            queryParameters.Add("@nvacationdays", payload.nvacationdays);
            queryParameters.Add("@npendingvacations", payload.npendingvacations);
            queryParameters.Add("@bsalarycurrency", payload.bsalarycurrency);
            queryParameters.Add("@bctscurrency", payload.bctscurrency);
            queryParameters.Add("@bitsray", payload.bitsray);
            queryParameters.Add("@nid_safeplan", payload.nid_safeplan);
            queryParameters.Add("@bdoesnotapplyqta", payload.bdoesnotapplyqta);
            queryParameters.Add("@bmixedafp", payload.bmixedafp);

            queryParameters.Add("@nid_sctrpensionentity", payload.nid_sctrpensionentity);
            queryParameters.Add("@nid_afp", payload.nid_afp);
            queryParameters.Add("@id_epsplan", payload.id_epsplan);
            queryParameters.Add("@slifelaw", payload.slifelaw);
	        queryParameters.Add("@nFesaludPlan", payload.nFesaludPlan);
            queryParameters.Add("@nInternPlan", payload.nInternPlan);
            queryParameters.Add("@nid_sede", payload.nid_sede);

            queryParameters.Add("@bemploye_file_exist", payload.bemployee_file_exist);
            queryParameters.Add("@nid_boss_real", payload.nid_boss_real);

            queryParameters.Add("@idGerencia", payload.idGerencia);
            queryParameters.Add("@idArea", payload.idArea);
            queryParameters.Add("@idSubArea", payload.idSubArea);



            var update = await humanManagementReadDbConnection.QueryAsync<ListPositionComboDto>(
                 "sp_employee_update",
                 queryParameters, commandType: CommandType.StoredProcedure);
        }

        public async Task PhoneMangement(PhoneManagementDto payload)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid_phone", payload.nid_phone);
            queryParameters.Add("@nid_person", payload.nid_person);
            queryParameters.Add("@phone", payload.phone);
            queryParameters.Add("@flat", payload.flat);

            var management = await humanManagementReadDbConnection.QueryAsync<ListPositionComboDto>(
                 "sp_phone_management",
                 queryParameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<List<ListAddressDto>> GetListAddressDto(int nid_person)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid_person", nid_person);

            var listadress = await humanManagementReadDbConnection.QueryAsync<ListAddressDto>(
                 "sp_address_listbyPerson",
                 queryParameters, commandType: CommandType.StoredProcedure);

            return listadress.ToList();
        }

        public async Task<GetDataToSendDownloadDocumentDto> GetDataToSendDownloadDocument(int nid_request)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid_request", nid_request);

            var response = await humanManagementReadDbConnection.QueryAsync<GetDataToSendDownloadDocumentDto>(
                 "staff.sp_request_get",
                 queryParameters, commandType: CommandType.StoredProcedure);

            return response.ToList().FirstOrDefault();
        }

        public async Task AddressMangement(AddressManagementDto payload)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid_address", payload.nid_address);
            queryParameters.Add("@saddress", payload.saddress);
            queryParameters.Add("@nid_district", payload.nid_district);
            queryParameters.Add("@state", payload.state);
            queryParameters.Add("@nid_person", payload.nid_person);
            queryParameters.Add("@flat", payload.flat);

            var management = await humanManagementReadDbConnection.QueryAsync<ListPositionComboDto>(
                 "sp_address_management",
                 queryParameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<List<StudientEmployeeDto>> GetListStudenEmplooyee(int nid_employee)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid_employee", nid_employee);

            var listadress = await humanManagementReadDbConnection.QueryAsync<StudientEmployeeDto>(
                 "sp_employee_studen_list",
                 queryParameters, commandType: CommandType.StoredProcedure);

            return listadress.ToList();
        }

        public async Task InsertStudenEmployee(EmployeeInsRequestDto request)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid_employee", request.nid_employee);
            queryParameters.Add("@nid_instruction", request.nid_instruction);
            queryParameters.Add("@nid_district", request.nid_district);
            queryParameters.Add("@sstudy_center", request.sstudy_center);
            queryParameters.Add("@scurrent_cycle", request.scurrent_cycle);
            queryParameters.Add("@dateStart", request.dateStart);
            queryParameters.Add("@dateEnd", request.dateEnd);
            queryParameters.Add("@scarreer", request.scarreer);

            var management = await humanManagementReadDbConnection.QueryAsync<ListPositionComboDto>(
                 "sp_employee_studen_ins",
                 queryParameters, commandType: CommandType.StoredProcedure);
        }

        public async Task UpdateStudenEmployee(EmployeeEditRequestDto request)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid_education", request.nid_education);
            queryParameters.Add("@nid_employee", request.nid_employee);
            queryParameters.Add("@nid_instruction", request.nid_instruction);
            queryParameters.Add("@nid_district", request.nid_district);
            queryParameters.Add("@sstudy_center", request.sstudy_center);
            queryParameters.Add("@scurrent_cycle", request.scurrent_cycle);
            queryParameters.Add("@dateStart", request.dateStart);
            queryParameters.Add("@dateEnd", request.dateEnd);
            queryParameters.Add("@scarreer", request.scarreer);

            var management = await humanManagementReadDbConnection.QueryAsync<ListPositionComboDto>(
                 "sp_employee_studen_edit",
                 queryParameters, commandType: CommandType.StoredProcedure);
        }

        public async Task DeleteStudenEmployee(int nid_studen)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid_education", nid_studen);

            var management = await humanManagementReadDbConnection.QueryAsync<ListPositionComboDto>(
                 "sp_employee_studen_del",
                 queryParameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<List<GetListInstruccionDto>> ListInstruccion()
        {
            var listadress = await humanManagementReadDbConnection.QueryAsync<GetListInstruccionDto>(
                 "sp_instruction_list",
                 commandType: CommandType.StoredProcedure);

            return listadress.ToList();
        }

        public async Task<List<ListRequestDto>> ListRequest()
        {
            var listadress = await humanManagementReadDbConnection.QueryAsync<ListRequestDto>(
                 "sp_instruction_list",
                 commandType: CommandType.StoredProcedure);

            return listadress.ToList();
        }

        public async Task<List<ListSonDto>> ListSon(int id)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid_employee", id);
            
            var list = await humanManagementReadDbConnection.QueryAsync<ListSonDto>(
                 "staff.sp_employee_sons_list",
                 queryParameters, commandType: CommandType.StoredProcedure);

            return list.ToList();
        }

        public async Task InsertSon(InsertSonDto request)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid_employee", request.nid_employee);
            queryParameters.Add("@sfullname", request.sfullname);
            queryParameters.Add("@ddateofbirth", request.ddateofbirth);
            queryParameters.Add("@slastname", request.slastname);
            queryParameters.Add("@smotherslastname", request.smotherslastname);
            queryParameters.Add("@sfamilytype", request.sfamilytype);
            

            var management = await humanManagementReadDbConnection.QueryAsync<ListPositionComboDto>(
                 "staff.sp_employee_sons_ins",
                 queryParameters, commandType: CommandType.StoredProcedure);
        }

        public async Task UpdateSon(UpdateSonDto request)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid_employee", request.nid_employee);
            queryParameters.Add("@sfullname", request.sfullname);
            queryParameters.Add("@ddateofbirth", request.ddateofbirth);
            queryParameters.Add("@slastname", request.slastname);
            queryParameters.Add("@nid_son", request.nid_son);
            queryParameters.Add("@smotherslastname", request.smotherslastname);

            var management = await humanManagementReadDbConnection.QueryAsync<ListPositionComboDto>(
                 "staff.sp_employee_sons_upd",
                 queryParameters, commandType: CommandType.StoredProcedure);
        }

        public async Task InsertJob(InsertJobDto request)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid_employee", request.nid_employee);
            queryParameters.Add("@namejob", request.namejob);
            queryParameters.Add("@timejob", request.timejob);
            queryParameters.Add("@positionjob", request.positionjob);
            queryParameters.Add("@sfunction", request.sfunction);

            var management = await humanManagementReadDbConnection.QueryAsync<ListPositionComboDto>(
                 "staff.sp_employee_job_ins",
                 queryParameters, commandType: CommandType.StoredProcedure);
        }

        public async Task UpdateJob(UpdateJobDto request)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid_employee", request.nid_employee);
            queryParameters.Add("@namejob", request.namejob);
            queryParameters.Add("@timejob", request.timejob);
            queryParameters.Add("@positionjob", request.positionjob);
            queryParameters.Add("@nid_employee_job", request.nid_employee_job);
            queryParameters.Add("@sfunction", request.sfunction);

            var management = await humanManagementReadDbConnection.QueryAsync<ListPositionComboDto>(
                 "staff.sp_employee_job_upd",
                 queryParameters, commandType: CommandType.StoredProcedure);
        }

        public async Task DeleteJob(DeleteJobDto request)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid_employee_job", request.nid_employee_job);

            var management = await humanManagementReadDbConnection.QueryAsync<ListPositionComboDto>(
                 "staff.sp_employee_job_del",
                 queryParameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<List<ListJobDto>> ListJob(int id)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid_employee", id);

            var list = await humanManagementReadDbConnection.QueryAsync<ListJobDto>(
                 "staff.sp_employe_job_list",
                 queryParameters, commandType: CommandType.StoredProcedure);

            return list.ToList();
        }

        public async Task UploadFIle(IFormFile file)
        {
            var folder = _appSettings.PathSaveFile;
            var filenamefolder = folder + "File\\";
            var Folder = filenamefolder + file.FileName;
            if (!Directory.Exists(filenamefolder))
            {
                Directory.CreateDirectory(filenamefolder);
            }

            using (var stream = new FileStream(Folder, FileMode.Create))
            {
                file.CopyTo(stream);
            }
        }

        public async Task<List<MasterTableGenericDto>> GenericListMasterTable(int id_father)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid_father", id_father);

            var list = await humanManagementReadDbConnection.QueryAsync<MasterTableGenericDto>(
                 "sp_list_generic_master",
                 queryParameters, commandType: CommandType.StoredProcedure);

            return list.ToList();
        }

        public async Task UpdateCovidCard(UpdateCovidCardDto payload, IFormFile file)
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
            queryParameters.Add("@nid_employee", payload.nid_employee);
            queryParameters.Add("@surl", Folder);

            var list = await humanManagementReadDbConnection.QueryAsync<MasterTableGenericDto>(
                 "staff.sp_edit_covidcard",
                 queryParameters, commandType: CommandType.StoredProcedure);
        }

        public async Task UpdateFirma(UpdateCovidCardDto payload, IFormFile file)
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
            queryParameters.Add("@nid_employee", payload.nid_employee);
            queryParameters.Add("@surl", Folder);

            var list = await humanManagementReadDbConnection.QueryAsync<MasterTableGenericDto>(
                 "sp_edit_firma_employee",
                 queryParameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<List<EmployeeModel>> EmployeeForSendToExactus()
        {
            var result = await (from emp in context.Employee
                                where emp.ExistsInExactus != true
                                select emp).ToListAsync();

            return result;
        }

        public async Task<List<MasterTableGenericDto>> GenericListMasterTableByKey(string key)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@skey", key);

            var list = await humanManagementReadDbConnection.QueryAsync<MasterTableGenericDto>(
                 "sp_list_generic_master_by_key",
                 queryParameters, commandType: CommandType.StoredProcedure);

            return list.ToList();
        }

        public async Task<List<DropDownListDto<int>>> GetBossDropDown(int nidPosition)
        {
            
            var charge = await context.tb_charge.Where(i => i.Id == nidPosition).FirstOrDefaultAsync();

            var result = await (from emp in context.Employee 
                                join pers in context.Person on emp.IdPerson equals pers.Id
                                where emp.IdPosition == charge.IdUpperCargo
                                select new DropDownListDto<int>
                                { 
                                    Code = emp.Id,
                                    Description = $"{emp.CodEmployee} - {pers.FirstName} {pers.LastName} {pers.MotherLastName }"
                                }).ToListAsync();
            return result;
        }



        public async Task<EmployeeCVDto> GetEmployeeCVById(int nid_employee)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid_employee", nid_employee);
            _logger.LogInformation("nid_employee: " + nid_employee);
            var employee = await humanManagementReadDbConnection.QueryAsync<EmployeeCVDto>(
                "sp_employee_cv_byid",
                queryParameters, commandType: CommandType.StoredProcedure);
            _logger.LogInformation("employee[0]: " + (EmployeeCVDto)employee[0]);

            return (EmployeeCVDto)employee[0];
        }

        public async Task<List<MonthDto>> GetMonthsByTipoDocumento(int id_tipo_documento,int nyear)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid_tipo_documento", id_tipo_documento);
            queryParameters.Add("@nid_year", nyear);

            var list = await humanManagementReadDbConnection.QueryAsync<MonthDto>(
                 "sp_month_list",
                 queryParameters, commandType: CommandType.StoredProcedure);

            return list.ToList();
        }

    }
}
