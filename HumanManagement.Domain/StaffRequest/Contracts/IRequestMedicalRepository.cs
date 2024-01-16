using HumanManagement.Domain.StaffRequest.Dto;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.StaffRequest.Contracts
{
    public interface IRequestMedicalRepository
    {
        Task<int> RegisterMedical(RegisterMedicalDto registerMedicalDto);
        Task<String> ValidateRegisterMedical(RegisterMedicalDto registerMedicalDto);

        //Task RegisterDocumentMedical(RegisterDocumentMedicalDto staffRequestQueryFilter, IFormFile file);
        Task RegisterDocumentMedical(RegisterDocumentMedicalDto payload, IFormFile file, bool bIsDraft);



        Task<List<MedicalDto>> ListMedical(FilterListDocumentDto staffRequestQueryFilter);

        Task<MedicalDto> MedicalById(int id);
        Task<ApprovalDateDto> GetApprovalDate(int id);

        Task<List<DocumentMedicalDto>> ListDocumentByMedical(int id);
        Task<List<ListMedicalNotification>> ListMedicalNotification();

        Task ValidDocument(ValidDocumentMedicalDto payload);
        Task ChangeStateMedical(ValidChangeStateMedical payload);
        Task UpdateFile(UpdateFilesDto payload, IFormFile file);
        Task UpdateVIVA(UpdateVIVAMedical payload, IFormFile file);

        Task UpdateCITT(UpdateCITTMedicalDto payload, IFormFile file);
        Task UpdateAmount(UpdateAmountMedicalDto payload);
        Task RejectedMedical(RejectMedicalDto payload);
        Task<GetDaysDto> GetDays(int employee);
        Task<BossDto> Getboss(int person);
        Task<ReportAmountDto> ReportAmount();


        Task<List<ReportGraficStatus>> ReportGraficByStatus(DateTime ddateinit, DateTime ddateend);
        Task<ReportGraficEtapa> ReportGraficByEtapa(DateTime ddateinit, DateTime ddateend);
        Task UpdateStatusExactus(int nid_medical, bool bexistexatus, int nactionexactus);
        Task ChangeStateMedicalEtapa1ToEtapa3(ValidChangeStateMedical payload);
        Task RequestDocumentApproved(RequestDocumentApprovedDto payload);
        Task<int> RequestDocumentObserve(int id, string scommentobserve);
        Task UpdateStateRequestMedical(int id);
    }
}
