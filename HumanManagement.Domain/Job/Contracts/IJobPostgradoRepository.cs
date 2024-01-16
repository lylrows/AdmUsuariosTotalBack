using HumanManagement.Domain.Job.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HumanManagement.Domain.Job.Contracts
{
    public interface IJobPostgradoRepository
    {
        Task<List<JobPostgradoDto>> GetPostgradoList(int idJob);
    }
}
