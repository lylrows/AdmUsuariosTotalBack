using HumanManagement.Domain.Postulant.WorkExperience.Dto;
using SitePostulant.Application.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SitePostulant.Application.WorkExperience.IService
{
    public interface IWorkExperienceService
    {
        Task<Result> GetWorkExperience(int IdPerson);
        Task<Result> Add(WorkExperienceDto dto);
        Task<Result> Update(WorkExperienceDto dto);
    }
}
