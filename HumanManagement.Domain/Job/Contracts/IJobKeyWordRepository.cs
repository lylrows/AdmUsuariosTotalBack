using HumanManagement.Domain.Job.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HumanManagement.Domain.Job.Contracts
{
    public interface IJobKeyWordRepository
    {
        Task<List<JobKeyWordDto>> GetListByJob(int[] arrayIdJob);
        Task<List<JobKeyWordDto>> GetKeyWordList(int idJob);
        Task DeleteByJob(int idJob);
    }
}
