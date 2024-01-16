using SitePostulant.Application.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SitePostulant.Application.Skills.IServices
{
    public interface ISkillsService
    {
        Task<Result> GetSkillsByDescription(string description);
    }
}
