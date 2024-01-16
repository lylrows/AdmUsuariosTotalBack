using HumanManagement.Domain.InformationPostulant.Dto;
using HumanManagement.Domain.Notification.Dto;
using HumanManagement.Domain.Utils.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.Utils.Constracts
{
    public interface IUtilRepository
    {
        Task<List<DepartamentDto>> GetDepartament();
        Task<List<ProvinceDto>> GetProvince(int Id);
        Task<List<DistrictDto>> GetDistrict(int Id);

        Task<List<MasterTableDto>> GetListSex();
        Task<List<MasterTableDto>> GetListNationality(); 
        Task<List<MasterTableDto>> GetListCivil();
        Task<List<MasterTableDto>> GetListActive();

        Task<List<ListStatusEmployeeDto>> GetStatusEmployee();

        Task<List<ListAreaDto>> GetListArea();

        Task<List<ListConsCenterDto>> GetListCostCenter(int IdCompany);
        Task<List<ListPayrollDto>> GetPayroll();
        Task<List<ListChargerDto>> GetCharger();
        Task<List<CategoryEmploymentDto>> GetListCategoryEmployment();
        Task<ListChargePostulantDto> GetChangePositionById(int Id);
        Task<int> GetDistrictIdByNames(int Id);

        Task<List<MasterTableDto>> GetTypeDocuementList();
        Task<InformationFilesDto> SaveInformationFiles(InformationFilesDto request);
        Task<List<ArchivosPostulante>> GetInformationFiles(FilterListaArchivos filter);
        Task<List<DocumentoAdicional>> GetDocumentosAdicionales(int idEvaluacion, int idPostulant);
        Task<List<DocumentoAdicional>> GetDocumentosAdicionalesByPerson(int idPostulant);
        Task<bool> SaveDocumentAditional(DocumentoAdicional request);
        Task<InformationFilesDto> GetInformationFilesByReference(InformationFilesDto request);
        Task<InformationReferenceDto> GetObjectivePostulantByperson(int idperson);
        Task<InformationFilesDto> InformationFilesDelete(int nidinformationfile);
        Task<List<InformationComputerSkillsDto>> GetSkillsPostulant(int idPostulant, int idEvaluation);
        Task<List<InformationComputerSkillsDto>> GetSkillsPostulantByPerson(int idPostulant);
        Task<InfoExactusSendDto> GetInfoToSendExatus(int IdPostulant);
        Task<List<NotificationFichaDto>> GetPersonsToSendFichaNotification(NotificationFilterFichaDto filter);

    }
}
