using HumanManagement.Domain.Postulant.Education.Dto;
using SitePostulant.Application.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SitePostulant.Application.EducationPostulant.IServices
{
    public interface IEducationPostulantService
    {
        Task<Result> GetEducationPostulant(int IdPerson);
        Task<Result> Add(EducationPostulantDto dto);
        Task<Result> Update(EducationPostulantDto dto);
    }
}
