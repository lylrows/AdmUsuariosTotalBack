using AutoMapper;
using HumanManagement.Domain.Areas.Dto;
using HumanManagement.Domain.Home.Dto;
using HumanManagement.Domain.Models;
using HumanManagement.Domain.Security.Dto;
using HumanManagement.Domain.Cargo.Dto;
using HumanManagement.Domain.Contact.Dto;
using HumanManagement.Domain.MasterTable.Dto;
using HumanManagement.Domain.MasterTable.Models;
using HumanManagement.Domain.Employee.Models;
using HumanManagement.Domain.Employee.Dto;
using HumanManagement.Domain.Person.Models;
using HumanManagement.Domain.Notification.Model;
using HumanManagement.Domain.Notification.Dto;
using HumanManagement.Domain.Job.Models;
using HumanManagement.Domain.Job.Dto;
using HumanManagement.Domain.EvaluationPostulant.Dto;
using EvaluationModel = HumanManagement.Domain.EvaluationPostulant.Models.Evaluation;
using HumanManagement.Domain.EvaluationPostulant.Models;
using HumanManagement.Domain.InformationPostulant.Models;
using HumanManagement.Domain.InformationPostulant.Dto;
using HumanManagement.Domain.Postulant.Person.Dto;
using HumanManagement.Domain.Postulant.Person.Models;
using HumanManagement.Domain.RecruitmentArea.Models;
using HumanManagement.Domain.RecruitmentArea.Dto;
using HumanManagement.Domain.EvaluationPostulantInternal.Dto;
using HumanManagement.Domain.EvaluationPostulantInternal.Models;
using EvaluationPostulantsInternalModel = HumanManagement.Domain.EvaluationPostulantInternal.Models.EvaluationPostulantsInternal;
using HumanManagement.Domain.StaffRequest.Dto;
using HumanManagement.Domain.StaffRequest.Models;

namespace HumanManagement.Application.Helpers
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<UserDto, User>();
            CreateMap<ResetPasswordDto, User>();
            CreateMap<UserDto, Domain.Security.Models.ProfileUser>();
            CreateMap<UserDto, PersonModel>();
            CreateMap<UserDto, Phone>();
            CreateMap<ImportEmployeeDto, PersonModel>();
            CreateMap<ImportEmployeeDto, EmployeeModel>();
            CreateMap<ImportEmployeeDto, EmployeeFile>();
            CreateMap<AreasDto, HumanManagement.Domain.Areas.Models.Areas>();
            CreateMap<HumanManagement.Domain.Areas.Models.Areas, AreasDto>();

            CreateMap<CargoDto, HumanManagement.Domain.Cargo.Models.Cargo>();
            CreateMap<HumanManagement.Domain.Cargo.Models.Cargo, CargoDto>();
            CreateMap<HumanManagement.Domain.Home.Models.Slider, SliderDto>();
            CreateMap<SliderDto, HumanManagement.Domain.Home.Models.Slider>();
            CreateMap<HumanManagement.Domain.Home.Models.Document, DocumentDto>();
            CreateMap<DocumentDto, HumanManagement.Domain.Home.Models.Document>();
            CreateMap<HumanManagement.Domain.Home.Models.Organization, OrganizationDto>();
            CreateMap<OrganizationDto, HumanManagement.Domain.Home.Models.Organization>();
            CreateMap<HumanManagement.Domain.MasterTable.Models.MasterTable, MasterTableDto>();
            CreateMap<MasterTableDto, HumanManagement.Domain.MasterTable.Models.MasterTable>();

            CreateMap<ContactDto, HumanManagement.Domain.Contact.Models.Contact>();
            CreateMap<HumanManagement.Domain.Contact.Models.Contact, ContactDto>();
            CreateMap<NotificationDto, NotificationModel>();
            CreateMap<JobOfferDto, Job>();
            CreateMap<JobOfferInternalDto, JobOffersInternal>();
            CreateMap<JobIdiomDto, JobIdiom>();
            CreateMap<EvaluationDto, EvaluationModel>();
            CreateMap<Domain.EvaluationPostulant.Dto.EvaluationPostulantDto, EvaluationPostulant>();
            CreateMap<NotesEvaluationDto, NotesEvaluation>();
            CreateMap<NotesEvaluation, NotesEvaluationDto>();
            CreateMap<EvaluationProficiencyDto, EvaluationProficiency>();
            CreateMap<EvaluationRatingPostulantDto, EvaluationRatingPostulant>();
            CreateMap<EvaluationPostulantDocumentsDto, EvaluationPostulantDocuments>();
            CreateMap<EvaluationPostulantDocuments, EvaluationPostulantDocumentsDto>();

            CreateMap<InformationWorkModel, InformationWorkDto>();
            CreateMap<InformationLangModel, InformationLangDto>();
            CreateMap<InformationComputerSkillsModel, InformationComputerSkillsDto>();
            CreateMap<InformationEducationModel, InformationEducationDto>();
            CreateMap<InformationFamilyModel, InformationFamilyDto>();
            CreateMap<InformationAditionalModel, InformationAditionalDto>();
            CreateMap<InformationExtraModel, InformationExtraDto>();

            CreateMap<InformationWorkDto, InformationWorkModel>();
            CreateMap<InformationLangDto, InformationLangModel>();
            CreateMap<InformationComputerSkillsDto, InformationComputerSkillsModel>();
            CreateMap<InformationEducationDto, InformationEducationModel>();
            CreateMap<InformationFamilyDto, InformationFamilyModel>();
            CreateMap<InformationAditionalDto, InformationAditionalModel>();
            CreateMap<PersonDto, PersonModelPostulant>();
            CreateMap<InformationExtraDto, InformationExtraModel>();
            CreateMap<JobKeyWordDto, JobKeyWords>();
            CreateMap<RecruitmentArea, RecruitmentAreaDto>();
            CreateMap<JobOffersInternalPostulantDto, JobOffersInternalPostulant>();
            CreateMap<EvaluationVacantInternalDto, EvaluationVacantInternal>();
            CreateMap<Domain.EvaluationPostulantInternal.Dto.EvaluationPostulantDto, EvaluationPostulantsInternalModel>();
            CreateMap<EvaluationPostulantInfoCurriculumDto, EvaluationPostulantInfoCurriculum>();
            CreateMap<EvaluationPostulantPositionDto, EvaluationPostulantPosition>();
            CreateMap<NotesEvaluationInternalDto, NotesEvaluationInternal>();
            CreateMap<NotesEvaluationInternal, NotesEvaluationInternalDto>();
            CreateMap<EvaluationFortalezasInternDto, EvaluationFortalezasIntern>();
            CreateMap<EvaluationProficiencyInternDto, EvaluationProficiencyIntern>();
            CreateMap<EvaluationPostulantInternalLogrosDto, EvaluationPostulantInternalLogros>();

            CreateMap<TypeStaffRequestDto, TypeStaffRequest>();
            CreateMap<TypeStaffRequestApproverDto, TypeStaffRequestApprover>();
            CreateMap<StaffRequestApproverDto, StaffRequestApprover>();
            CreateMap<StaffRequestDto, StaffRequestModel>()
                .ForMember(p => p.IdEmployee, x => x.MapFrom(d => d.StaffRequestEmployee.IdEmployee))
                .ForMember(p => p.IdCharge, x => x.MapFrom(d => d.StaffRequestEmployee.IdCharge))
                .ForMember(p => p.DateAdmission, x => x.MapFrom(d => d.StaffRequestEmployee.DateAdmissionEmployee));
            CreateMap<StaffRequestVacationDto, StaffRequestVacation>();
            CreateMap<StaffRequestAdvancementDto, StaffRequestAdvancement>();
            CreateMap<StaffRequestAbsenceDto, StaffRequestAbsence>();
            CreateMap<StaffRequestJustificationTardinessDto, StaffRequestJustificationTardiness>();
            CreateMap<StaffRequestPermitDto, StaffRequestPermit>();
            CreateMap<BandejaNotificacionDto, NotificationModel>()
               .ForMember(p => p.Id, x => x.MapFrom(d => d.Id))
               .ForMember(p => p.Body, x => x.MapFrom(d => d.Message))
               .ForMember(p => p.Subject, x => x.MapFrom(d => d.Subject))
               .ForMember(p => p.SendDate, x => x.MapFrom(d => d.SendDate))
               .ForMember(p => p.IdPerson, x => x.MapFrom(d => d.IdPerson))
               .ForMember(p => p.IdArea, x => x.MapFrom(d => d.IdArea))
               .ForMember(p => p.Important, x => x.MapFrom(d => d.Important))
               .ForMember(p => p.Favorite, x => x.MapFrom(d => d.Favorite))
               .ForMember(p => p.Active, x => x.MapFrom(d => d.Active));
            CreateMap<StaffRequestLoanDto, StaffRequestLoan>();
            CreateMap<StaffRequestAccountChangeDto, StaffRequestAccountChangeCts>();
            CreateMap<EvaluationExternTestDto, EvaluationExternTest>();
            CreateMap<EvaluationExternTest, EvaluationExternTestDto>();
            CreateMap<HumanManagement.Domain.Postulant.Person.Dto.PersonDto, PersonModelPostulant>();
            CreateMap<EvaluationMultitestExtern, EvaluationMultitestExternDto>();
            CreateMap<EvaluationMultitestExternDto, EvaluationMultitestExtern>();
            CreateMap<EvaluationMultitestIntern, EvaluationMultitestInternDto>();
        }
    }
}
