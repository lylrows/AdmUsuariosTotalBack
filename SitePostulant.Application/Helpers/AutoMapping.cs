using AutoMapper;
using HumanManagement.Domain.Postulant.Disability.Dto;
using HumanManagement.Domain.Postulant.Disability.Models;
using HumanManagement.Domain.Postulant.Education.Dto;
using HumanManagement.Domain.Postulant.JobObjective.Dto;
using HumanManagement.Domain.Postulant.JobObjective.Models;
using HumanManagement.Domain.Postulant.Languages.Dto;
using HumanManagement.Domain.Postulant.Models;
using HumanManagement.Domain.Postulant.Person.Dto;
using HumanManagement.Domain.Postulant.Person.Models;
using HumanManagement.Domain.Postulant.SalaryPreference.Dto;
using HumanManagement.Domain.Postulant.SalaryPreference.Models;
using HumanManagement.Domain.Postulant.Security.Dto;
using HumanManagement.Domain.Postulant.Security.Models;
using HumanManagement.Domain.Postulant.Skills.Dto;
using HumanManagement.Domain.Postulant.WorkExperience.Dto;
using HumanManagement.Domain.Postulant.WorkExperience.Models;
using HumanManagement.Domain.RecruitmentArea.Dto;

namespace SitePostulant.Application.Helpers
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<UserDto, UserPostulant>();
            CreateMap<ResetPasswordDto, UserPostulant>();
            CreateMap<UserDto, ProfileUserPostulant>();
            CreateMap<UserDto, PersonModelPostulant>();
            CreateMap<EducationPostulantDto, HumanManagement.Domain.Postulant.Education.Models.EducationPostulant>();
            CreateMap<LanguagePostulantDto, HumanManagement.Domain.Postulant.Languages.Models.LanguagePostulant>();
            CreateMap<SkillsPostulantDto, HumanManagement.Domain.Postulant.Skills.Models.SkillsPostulant>();
            CreateMap<WorkExperienceDto, WorkExperienceModel>();
            CreateMap<RecruitmentAreaDto, HumanManagement.Domain.RecruitmentArea.Models.RecruitmentArea>();
            CreateMap<HumanManagement.Domain.RecruitmentArea.Models.RecruitmentArea, RecruitmentAreaDto>();
            CreateMap<JobObjectiveDto, JobObjectiveModel>();
            CreateMap<SalaryPreferenceDto, SalaryPreferenceModel>();
            CreateMap<DisabilityDto, DisabilityModel>();
            CreateMap<JobObjectiveModel, JobObjectiveDto>();
            CreateMap<SalaryPreferenceModel, SalaryPreferenceDto>();
            CreateMap<DisabilityModel, DisabilityDto>();
            CreateMap<PersonDto, PersonModelPostulant>();
        }
    }
}
