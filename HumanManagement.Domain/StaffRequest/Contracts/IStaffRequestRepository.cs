using HumanManagement.Domain.Common;
using HumanManagement.Domain.StaffRequest.Dto;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HumanManagement.Domain.StaffRequest.Contracts
{
    public interface IStaffRequestRepository
    {
        Task<ResultPaginationListDto<StaffRequestListDto>> GetListPagination(StaffRequestQueryFilter staffRequestQueryFilter);
        Task<Object> GetListRequestPrint(StaffRequestQueryFilter staffRequestQueryFilter);
        Task<StaffRequestDto> GetById(int id);
        Task<StaffRequestEmployeeDto> GetEmployeeById(int idEmployee);
        Task<List<ListIdPersonByChargerDto>> GetPersonByCharger(int Idcharger);
        Task<List<ListDatesByEmployeeDto>> GetDatesByEmployee(int Idemployee);
        Task<List<NotificationReceptorDto>> GetListReceptorForNotification(int idProfile, int idArea);
        Task<List<NotificationReceptorDto>> GetListReceptorForNotificationBoss(int idProfile, int idArea, int idEmployee);
        Task<GetRequestAdvance> GetRequestAdvance(int idRequest);
        Task<List<DetailRequestAdvacement>> GetDetailRequestAdvacement(int IdRequest);
        Task ApprovedAdvacement(ApprovedAdvacementDto payload, bool IsFinish);
        Task RejectedAdvacement(RejectAdvacementDto payload);
        Task RegisterRequestMedical(RegisterRequestMedical payload, IFormFile file);
        Task RegisterRequestBurial(RegisterRequestBurial payload);
        Task RegisterRequestSalary(RegisterRequestSalary payload, IFormFile file, IFormFile fileFicha);
        Task RegisterRequestHourExtra(RegisterHourExtraDto payload, IFormFile file);
        Task<List<ListBank>> ListBank();

        Task<GetStaffSalaryById> GetStaffSalaryById(int Id);
        Task ApprovedSalary(ApprovedSalaryDto payload, bool IsFinish);
        Task RejectSalary(RejectSalaryDto payload);
        Task<GetStaffBurialByIdDto> GetStaffBurialById(int Id);

        Task ApprovedBurial(ApprovedSalaryDto payload, bool IsFinish);
        Task RejectBurial(RejectSalaryDto payload);
        Task<GetRequestMedicalById> GetRequestMedicalById(int Id);
        Task<GetRequestTypeSureById> GetRequestTypeSureById(int Id);
        Task<GetRequestHourExtraById> GetRequestHourExtraById(int Id);
        Task ApprovedMedical(ApprovedSalaryDto payload, bool IsFinish);
        Task ApprovedTypeSure(ApprovedSalaryDto payload, bool IsFinish);
        Task ApprovedHourExtra(ApprovedSalaryDto payload, bool IsFinish);
        Task RejectMedical(RejectSalaryDto payload);
        Task RegisterRequestSure(RegisterRequestSure payload, IFormFile file);
        Task RegisterRequestTypeSure(RegisterChangeSureDto payload, IFormFile file);
        Task<GetStaffSureById> GetRequestSureById(int Id);
        Task ApprovedSure(ApprovedSureDto payload, bool IsFinish);
        Task RejectSure(RejectSalaryDto payload);
        Task RejectTypeSure(RejectSalaryDto payload);
        Task RejectHourExtra(RejectSalaryDto payload);
        Task<List<EmployeeChildren>> ListEmployeeChildren(int Id, int IdEmployee);
        Task<List<EmployeeChildren>> ListEmployeeReplacement(int Id);
        Task RegisterRequestCapacitacionNueva(RegisterCapacitacionDto payload);
        Task<GetStaffCapacitationNuevByIdDto> GetRequestCapacitacionNuevaById(int Id);
        Task RegisterRequestCapacitacionExtra(RegisterCapacitacionExtraDto payload);
        Task UpdateRequestCapacitacionExtra(RegisterCapacitacionExtraDto payload);

        Task ApprovedTrainingNew(ApprovedSalaryDto payload, bool IsFinish);
        Task RejectTrainingNew(RejectSalaryDto payload);
        Task<GetStaffCapacitationExtraByIdDto> GetRequestCapacitacionExtraById(int Id);

        Task ApprovedTrainingExtra(ApprovedSalaryDto payload, bool IsFinish);
        Task RejectTrainingExtra(RejectSalaryDto payload);

        Task<List<CategoryRequest>> ListCategoryRequest();
        Task<List<ListRequestByCategory>> ListRequestByCategory(int Id);
        Task<ResultPaginationListDto<StaffRequestListDto>> GetListPaginationByUser(StaffRequestQueryFilter staffRequestQueryFilter);
        Task DeleteStaffRequest(int Id);
        Task<StaffRequestListDto> GetStaffRequestFromNotificacion(StaffRequestFromNotificacionFilter filter);
        Task<StaffRequestValidateDaysDto> GetStaffRequestValidateDaysAdelantoSueldo(int nid_employee);


    }
}
