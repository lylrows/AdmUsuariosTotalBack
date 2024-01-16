using AutoMapper;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.Postulant.Skills.Contracts;
using HumanManagement.Domain.Postulant.Skills.Dto;
using SitePostulant.Application.Response;
using SitePostulant.Application.SkillsPostulant.IServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SkillsPostulantModel = HumanManagement.Domain.Postulant.Skills.Models.SkillsPostulant;

namespace SitePostulant.Application.SkillsPostulant.Services
{
    public class SkillsPostulantService : ISkillsPostulantService
    {
        private readonly ISkillsPostulantRepository skillsPostulantRepository;
        private readonly IBaseRepository<SkillsPostulantModel> baseRepository;
        private readonly IMapper mapper;
        public SkillsPostulantService(ISkillsPostulantRepository skillsPostulantRepository,
                                     IBaseRepository<SkillsPostulantModel> baseRepository,
                                     IMapper mapper
                                     )
        {
            this.skillsPostulantRepository = skillsPostulantRepository;
            this.baseRepository = baseRepository;
            this.mapper = mapper;
        }
        public async Task<Result> Add(List<SkillsPostulantDto> dto)
        {
            foreach (var item in dto)
            {
                var entity = mapper.Map<SkillsPostulantModel>(item);
                entity.Active = true;
                await baseRepository.Add(entity);
                item.Id = entity.Id;
            }

            return new Result
            {
                Data = dto,
                StateCode = Constants.StateCodeResult.STATE_CODE_OK
            };
        }

        public async Task<Result> Delete(SkillsPostulantDto dto)
        {
            var entity = mapper.Map<SkillsPostulantModel>(dto);
            entity.Active = false;
            await baseRepository.Update(entity);

            dto.Id = entity.Id;
            return new Result
            {
                Data = dto,
                StateCode = Constants.StateCodeResult.STATE_CODE_OK
            };

        }

        public async Task<Result> GetSkilssPostulant(int IdPerson)
        {
            var dto = await skillsPostulantRepository.GetSkillsByPostulant(IdPerson);

            return new Result
            {
                StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                Data = dto
            };
        }
    }
}
