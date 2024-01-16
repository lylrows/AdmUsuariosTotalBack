using HumanManagement.Domain.Common;
using HumanManagement.Domain.Job.Dto;
using HumanManagement.Domain.Job.QueryFilter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.Job.Contracts
{
    public interface IJobRepository
    {
        Task<JobDto> GetById(int nId);
        Task<List<JobDto>> GetRelatedJobs(int nIdJob);
        Task<List<JobDto>> GetOtherJobs();
        Task<List<JobDto>> GetAllJobs(JobFilterDto filter);
        Task<JobOfferDto> GetByIdRequest(int idRequest);
        Task<JobOfferInternalDto> GetJobInternByIdRequest(int idRequest);
        Task<ResultPaginationListDto<JobUserDto>> GetJobsByUser(JobQueryFilter jobQueryFilter);
    }
}
