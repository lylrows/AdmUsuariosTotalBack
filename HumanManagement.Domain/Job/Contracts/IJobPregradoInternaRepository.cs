using HumanManagement.Domain.Job.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HumanManagement.Domain.Job.Contracts
{
    public interface IJobPregradoInternaRepository
    {
        Task<List<JobPregradoInternaDto>> GetPregradoList(int idJob);
    }
}
