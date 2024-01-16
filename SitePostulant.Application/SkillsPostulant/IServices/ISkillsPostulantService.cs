using HumanManagement.Domain.Postulant.Skills.Dto;
using SitePostulant.Application.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SitePostulant.Application.SkillsPostulant.IServices
{
    public interface ISkillsPostulantService
    {
        Task<Result> GetSkilssPostulant(int IdPerson);
        Task<Result> Add(List<SkillsPostulantDto> dto);
        Task<Result> Delete(SkillsPostulantDto dto);
    }
}
