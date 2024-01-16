using HumanManagement.Domain.Postulant.SalaryPreference.Dto;
using SitePostulant.Application.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SitePostulant.Application.SalaryPreference.IService
{
    public interface ISalaryPreferenceService
    {
        Task<Result> GetSalaryByPostulant(int IdPerson);
        Task<Result> Add(SalaryPreferenceDto dto);
        Task<Result> Update(SalaryPreferenceDto dto);
    }
}
