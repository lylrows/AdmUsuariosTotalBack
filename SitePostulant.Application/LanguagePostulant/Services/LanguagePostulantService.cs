using AutoMapper;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.Postulant.Languages.Contracts;
using HumanManagement.Domain.Postulant.Languages.Dto;
using SitePostulant.Application.LanguagePostulant.IServices;
using SitePostulant.Application.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LanguagePostulantModel = HumanManagement.Domain.Postulant.Languages.Models.LanguagePostulant;

namespace SitePostulant.Application.LanguagePostulant.Services
{
    public class LanguagePostulantService : ILanguagePostulantService
    {
        private readonly ILanguagesPostulantRepository languagePostulantRepository;
        private readonly IBaseRepository<LanguagePostulantModel> baseRepository;
        private readonly IMapper mapper;
        public LanguagePostulantService(ILanguagesPostulantRepository languagePostulantRepository,
                                        IBaseRepository<LanguagePostulantModel> baseRepository,
                                        IMapper mapper)
        {
            this.languagePostulantRepository = languagePostulantRepository;
            this.baseRepository = baseRepository;
            this.mapper = mapper;
        }
        public async Task<Result> Add(LanguagePostulantDto dto)
        {
            var entity = mapper.Map<LanguagePostulantModel>(dto);
            await baseRepository.Add(entity);
            dto.Id = entity.Id;

            return new Result
            {
                Data = dto,
                StateCode = Constants.StateCodeResult.STATE_CODE_OK
            };
        }

        public async Task<Result> GetLanguagePostulant(int IdPerson)
        {
            var dto = await languagePostulantRepository.GetLanguagePostulant(IdPerson);

            return new Result
            {
                StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                Data = dto
            };
        }

        public async Task<Result> Update(LanguagePostulantDto dto)
        {
            var entity = mapper.Map<LanguagePostulantModel>(dto);
            await baseRepository.Update(entity);
            dto.Id = entity.Id;

            return new Result
            {
                Data = dto,
                StateCode = Constants.StateCodeResult.STATE_CODE_OK
            };
        }
    }
}
