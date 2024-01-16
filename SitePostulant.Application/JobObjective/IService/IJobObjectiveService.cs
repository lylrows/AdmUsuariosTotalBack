using HumanManagement.Domain.Postulant.JobObjective.Dto;
using SitePostulant.Application.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SitePostulant.Application.JobObjective.IService
{
    public interface IJobObjectiveService
    {
        Task<Result> GetObjectivesByPostulant(int IdPerson);
        Task<Result> Add(JobObjectiveDto dto);
        Task<Result> Update(JobObjectiveDto dto);
    }
}
