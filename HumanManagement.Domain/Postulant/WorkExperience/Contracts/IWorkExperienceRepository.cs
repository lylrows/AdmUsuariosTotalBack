using HumanManagement.Domain.Postulant.WorkExperience.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.Postulant.WorkExperience.Contracts
{
    public interface IWorkExperienceRepository
    {
        Task<List<WorkExperienceDto>> GetWorkExperience(int IdPerson);
        Task<List<WorkExperienceDto>> GetWorkExperiencePostulants(int[] arrayIdPostulant);
    }
}
