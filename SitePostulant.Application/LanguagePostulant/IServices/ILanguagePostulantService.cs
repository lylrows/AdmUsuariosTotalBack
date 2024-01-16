using HumanManagement.Domain.Postulant.Languages.Dto;
using SitePostulant.Application.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SitePostulant.Application.LanguagePostulant.IServices
{
    public interface ILanguagePostulantService
    {
        Task<Result> GetLanguagePostulant(int IdPerson);
        Task<Result> Add(LanguagePostulantDto dto);
        Task<Result> Update(LanguagePostulantDto dto);
    }
}
