using HumanManagement.Domain.Applicants.Dto;
using SitePostulant.Application.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SitePostulant.Application.Applications.IServices
{
    public interface IApplicantService
    {
        Task<Result> GetListMyApplicants(FilterApplicants filters);
        Task<Result> GetStateApplicants(int IdUser);
        Task<Result> GetListJob(int IdUser);
    }
}
