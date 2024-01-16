using HumanManagement.Domain.Job.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HumanManagement.Domain.Job.Contracts
{
    public interface IJobIdiomRepository
    {
        Task<List<JobIdiomDto>> GetIdiomList(int idJob);
        Task DeleteByJob(int idJob);
    }
}
