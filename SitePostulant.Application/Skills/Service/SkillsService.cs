using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.Postulant.Skills.Contracts;
using SitePostulant.Application.Response;
using SitePostulant.Application.Skills.IServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SitePostulant.Application.Skills.Service
{
    public class SkillsService : ISkillsService
    {
        private readonly ISkillsRepository skillsRepository;
        public SkillsService(ISkillsRepository skillsRepository)
        {
            this.skillsRepository = skillsRepository;
        }
        public async Task<Result> GetSkillsByDescription(string description)
        {
            var dto = await skillsRepository.GetSkillsSearch(description);

            return new Result
            {
                StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                Data = dto
            };
        }
    }
}
