using HumanManagement.Domain.Job.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HumanManagement.Domain.Job.Contracts
{
    public interface IJobPregradoRepository
    {
        Task<List<JobPregradoDto>> GetPregradoList(int idJob);
    }
}
