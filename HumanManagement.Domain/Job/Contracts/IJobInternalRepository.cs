using HumanManagement.Domain.Common;
using HumanManagement.Domain.Job.Dto;
using HumanManagement.Domain.Job.QueryFilter;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.Job.Contracts
{
    public interface IJobInternalRepository
    {
        Task<ResultPaginationListDto<JobDto>> GetAllJobsInternal(JobInternalQueryFilter filter);
        Task<JobDto> GetById(int nId);

        Task<ResultPaginationListDto<JobUserDto>> GetJobsByUser(JobQueryFilter jobQueryFilter);

    }
}
