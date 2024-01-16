using HumanManagement.Domain.Job.Dto;
using SitePostulant.Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitePostulant.Application.Job.IServices
{
    public interface IJobService
    {
        Task<Result> GetById(int Id);
        Task<Result> IsJobPostulated(int nIdJob, int nIdPostulant);
        Task<Result> AddJobPostulant(int nIdJob, int nIdPostulant);
        Task<Result> GetRelatedJobs(int nIdJob);
        Task<Result> GetOtherJobs();
        Task<Result> GetAllJobs(JobFilterDto filter);
    }
}
