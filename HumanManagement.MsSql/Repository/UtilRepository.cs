using Dapper;
using HumanManagement.Application.Response;
using HumanManagement.Domain.Contracts;
using HumanManagement.Domain.InformationPostulant.Dto;
using HumanManagement.Domain.MasterTable.Models;
using HumanManagement.Domain.Notification.Dto;
using HumanManagement.Domain.Utils.Constracts;
using HumanManagement.Domain.Utils.Dto;
using HumanManagement.MsSql.Context;

using System.Collections.Generic;
using System.Data;
using System.Linq;

using System.Threading.Tasks;

namespace HumanManagement.MsSql.Repository
{
    public class UtilRepository: BaseRepository<MasterTable>,IUtilRepository
    {
        private readonly IHumanManagementReadDbConnection humanManagementReadDbConnection;
        public UtilRepository(IHumanManagementReadDbConnection humanManagementReadDbConnection, DbContextMsSql context) : base(context)
        {
            this.humanManagementReadDbConnection = humanManagementReadDbConnection;
        }
        public async Task<List<DepartamentDto>> GetDepartament()
        {
            var listdepartment = await humanManagementReadDbConnection.QueryAsync<DepartamentDto>(
                "sp_department_list",
                commandType: CommandType.StoredProcedure);
            return listdepartment.ToList();
        }

        public async Task<List<ProvinceDto>> GetProvince(int Id)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid_departament", Id);

            var listprovince = await humanManagementReadDbConnection.QueryAsync<ProvinceDto>(
                "sp_province_list",
                queryParameters,commandType: CommandType.StoredProcedure);
            return listprovince.ToList();
        }

        public async Task<List<DistrictDto>> GetDistrict(int Id)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid_province", Id);
            var listdistrict = await humanManagementReadDbConnection.QueryAsync<DistrictDto>(
                "sp_district_list",
                queryParameters,commandType: CommandType.StoredProcedure);
            return listdistrict.ToList();
        }

        public async Task<List<MasterTableDto>> GetListSex()
        {
            var listsex = await humanManagementReadDbConnection.QueryAsync<MasterTableDto>(
                "sp_sex_list",
                commandType: CommandType.StoredProcedure);
            return listsex.ToList();
        }

        public async Task<List<MasterTableDto>> GetListNationality()
        {
            var listnationality = await humanManagementReadDbConnection.QueryAsync<MasterTableDto>(
                "sp_nationality_list",
                commandType: CommandType.StoredProcedure);
            return listnationality.ToList();
        }

        public async Task<List<MasterTableDto>> GetListCivil()
        {
            var listcivil = await humanManagementReadDbConnection.QueryAsync<MasterTableDto>(
                "sp_civil_list",
                commandType: CommandType.StoredProcedure);
            return listcivil.ToList();
        }

        public async Task<List<MasterTableDto>> GetListActive()
        {
            var listactive = await humanManagementReadDbConnection.QueryAsync<MasterTableDto>(
                "sp_active_list",
                commandType: CommandType.StoredProcedure);
            return listactive.ToList();
        }

        public async Task<List<ListStatusEmployeeDto>> GetStatusEmployee()
        {
            var liststatus = await humanManagementReadDbConnection.QueryAsync<ListStatusEmployeeDto>(
               "sp_state_employee_list",
               commandType: CommandType.StoredProcedure);
            return liststatus.ToList();
        }

        public async Task<List<ListAreaDto>> GetListArea()
        {
            var listarea = await humanManagementReadDbConnection.QueryAsync<ListAreaDto>(
               "sp_area_list",
               commandType: CommandType.StoredProcedure);
            return listarea.ToList();
        }

        public async Task<List<ListConsCenterDto>> GetListCostCenter(int IdCompany)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid_company", IdCompany);
            var listcostcenter = await humanManagementReadDbConnection.QueryAsync<ListConsCenterDto>(
                "sp_costcenter_list",
                queryParameters, commandType: CommandType.StoredProcedure);
            return listcostcenter.ToList();
        }

        public async Task<List<ListPayrollDto>> GetPayroll()
        {
            var listpayroll = await humanManagementReadDbConnection.QueryAsync<ListPayrollDto>(
               "sp_payroll_list",
               commandType: CommandType.StoredProcedure);
            return listpayroll.ToList();
        }

        public async Task<List<ListChargerDto>> GetCharger()
        {
            var list = await humanManagementReadDbConnection.QueryAsync<ListChargerDto>(
               "sp_list_charger",
               commandType: CommandType.StoredProcedure);
            return list.ToList();
        }

        public async Task<List<CategoryEmploymentDto>> GetListCategoryEmployment()
        {
            var listCategory = await humanManagementReadDbConnection.QueryAsync<CategoryEmploymentDto>(
                "sp_list_category_employment",
                commandType: CommandType.StoredProcedure);
            return listCategory.ToList();
        }

        public async Task<ListChargePostulantDto> GetChangePositionById(int Id)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid_charge", Id);
            var result = await humanManagementReadDbConnection.QueryAsync<ListChargePostulantDto>(
                "dbo.sp_charge_by_id",
                queryParameters, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }

        public async Task<int> GetDistrictIdByNames(int Id)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid_charge", Id);
            var result = await humanManagementReadDbConnection.QueryAsync<int>(
                "dbo.sps_getdistrictbynames",
                queryParameters, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public async Task<List<MasterTableDto>> GetTypeDocuementList()
        {
            var listsex = await humanManagementReadDbConnection.QueryAsync<MasterTableDto>(
                "sp_type_document_list",
                commandType: CommandType.StoredProcedure);
            return listsex.ToList();
        }

        public async Task<InformationFilesDto> SaveInformationFiles(InformationFilesDto request)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nidinformationfile", request.nidinformationfile);
            queryParameters.Add("@nidinformationextra", request.nidinformationextra);
            queryParameters.Add("@nidreferences", request.nidreferences);
            queryParameters.Add("@snamefile", request.snamefile);
            queryParameters.Add("@skeyfile", request.skeyfile);
            queryParameters.Add("@ntypefile", request.ntypefile);
            queryParameters.Add("@bactive", request.bactive);
            queryParameters.Add("@stype_file", request.stypeFile);
            queryParameters.Add("@path_complete", request.path_complete);
            var result = await humanManagementReadDbConnection.QueryAsync<InformationFilesDto>(
                "dbo.sps_information_files_save", 
                queryParameters, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }

        public async Task<List<ArchivosPostulante>> GetInformationFiles(FilterListaArchivos filter)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nidinformationextra", filter.nidinformationextra);
            queryParameters.Add("@nidreferences", filter.nidreferences); 
            queryParameters.Add("@stipo_archivo", filter.stipo_archivo);
            queryParameters.Add("@ntipo_archivo", filter.ntipo_archivo);
            var lstFiles = await humanManagementReadDbConnection.QueryAsync<ArchivosPostulante>(
                "sps_information_files", queryParameters,
                commandType: CommandType.StoredProcedure);
            return lstFiles.ToList();
        }

        public async Task<List<DocumentoAdicional>> GetDocumentosAdicionales(int idEvaluacion, int idPostulant)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nidevaluation", idEvaluacion);
            queryParameters.Add("@nidpostulant", idPostulant);
            var lstFiles = await humanManagementReadDbConnection.QueryAsync<DocumentoAdicional>(
                "sps_aditional_document_postulant", queryParameters,
                commandType: CommandType.StoredProcedure);
            return lstFiles.ToList();
        }

        public async Task<List<DocumentoAdicional>> GetDocumentosAdicionalesByPerson(int idPostulant)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nidevaluation", 0);
            queryParameters.Add("@nidpostulant", idPostulant);
            var lstFiles = await humanManagementReadDbConnection.QueryAsync<DocumentoAdicional>(
                "sps_aditional_document_postulant", queryParameters,
                commandType: CommandType.StoredProcedure);
            return lstFiles.ToList();
        }

        public async Task<bool> SaveDocumentAditional(DocumentoAdicional request)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid_document_aditional", request.IdDocumentAditional);
            queryParameters.Add("@nidpostulant", request.IdPostulant);
            queryParameters.Add("@nid_master", request.IdMaster);
            queryParameters.Add("@bchecked", request.Checked);
            queryParameters.Add("@sfilename", request.NombreFile);
            queryParameters.Add("@spath_file", request.PathFile);
            var result = await humanManagementReadDbConnection.QueryAsync<Result>(
                "dbo.spi_aditional_document_postulant",
                queryParameters, commandType: CommandType.StoredProcedure);

            return true;
        }

        public async Task<InformationFilesDto> GetInformationFilesByReference(InformationFilesDto request)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nidinformationextra", request.nidinformationextra);
            queryParameters.Add("@nidreferences", request.nidreferences);
            queryParameters.Add("@stipo_archivo", request.stypeFile);
            queryParameters.Add("@ntipo_archivo", request.ntypefile);
            var result = await humanManagementReadDbConnection.QueryAsync<InformationFilesDto>(
                "dbo.sps_information_files_by_references",
                queryParameters, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }

        public async Task<InformationReferenceDto> GetObjectivePostulantByperson(int idperson)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nidperson", idperson);
            var result = await humanManagementReadDbConnection.QueryAsync<InformationReferenceDto>(
                "recruitment.sps_objective_postulant_byperson",
                queryParameters, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }

        public async Task<InformationFilesDto> InformationFilesDelete(int nidinformationfile)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nidinformationfile", nidinformationfile);
            var result = await humanManagementReadDbConnection.QueryAsync<InformationFilesDto>(
                "dbo.information_files_postulant_delete",
                queryParameters, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }

        public async Task<List<InformationComputerSkillsDto>> GetSkillsPostulant(int idPostulant, int idEvaluation)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nidpostulant", idPostulant);
            queryParameters.Add("@nidevaluation", idEvaluation);
            var lstFiles = await humanManagementReadDbConnection.QueryAsync<InformationComputerSkillsDto>(
                "recruitment.sps_skills_postulant ", queryParameters,
                commandType: CommandType.StoredProcedure);
            return lstFiles.ToList();
        }

        public async Task<List<InformationComputerSkillsDto>> GetSkillsPostulantByPerson(int idPostulant)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nidpostulant", idPostulant);
            queryParameters.Add("@nidevaluation", 0);
            var lstFiles = await humanManagementReadDbConnection.QueryAsync<InformationComputerSkillsDto>(
                "recruitment.sps_skills_postulant ", queryParameters,
                commandType: CommandType.StoredProcedure);
            return lstFiles.ToList();
        }

        public async Task<InfoExactusSendDto> GetInfoToSendExatus(int IdPostulant)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nidpostulant", IdPostulant);
            var result = await humanManagementReadDbConnection.QueryAsync<InfoExactusSendDto>(
                "dbo.sp_info_send_exactus_by_postulant",
                queryParameters, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }

        public async Task<List<NotificationFichaDto>> GetPersonsToSendFichaNotification(NotificationFilterFichaDto filter)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid_evaluation", filter.IdEvaluation);
            queryParameters.Add("@spostulant_type", filter.PostulantType);
            queryParameters.Add("@nlevel", filter.Level);
            var listPersons = await humanManagementReadDbConnection.QueryAsync<NotificationFichaDto>(
                "sp_persons_notification_ficha",
                queryParameters, commandType: CommandType.StoredProcedure);
            return listPersons.ToList();
        }
    }
}
