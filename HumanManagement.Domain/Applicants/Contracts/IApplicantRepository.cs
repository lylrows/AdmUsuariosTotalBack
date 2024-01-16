using HumanManagement.Domain.Applicants.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.Applicants.Contracts
{
    public interface IApplicantRepository
    {
        Task<List<ListApplicantsDto>> GetListMyApplicants(FilterApplicants filters);
        Task<List<ListStateApplicantsDto>> GetStateApplicants(int IdUser);
        Task<List<ListJobDto>> GetListJob(int IdUser);
    }
}
