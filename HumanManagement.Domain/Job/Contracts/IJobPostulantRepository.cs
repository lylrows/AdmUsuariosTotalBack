using HumanManagement.Domain.Job.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.Job.Contracts
{
    public interface IJobPostulantRepository
    {
        Task<JobPostulantDto> GetById(int nIdJob, int nIdPostulant);
        Task<List<JobPostulantLoadDto>> GetPostulantLoad(int nIdJob);
    }
}
