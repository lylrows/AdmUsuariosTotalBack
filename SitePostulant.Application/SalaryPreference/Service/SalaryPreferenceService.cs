using AutoMapper;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.Postulant.SalaryPreference.Dto;
using HumanManagement.Domain.Postulant.SalaryPreference.Models;
using SitePostulant.Application.Response;
using SitePostulant.Application.SalaryPreference.IService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SitePostulant.Application.SalaryPreference.Service
{
    public class SalaryPreferenceService: ISalaryPreferenceService
    {
        private readonly IBaseRepository<SalaryPreferenceModel> baseRepository;
        private readonly IMapper mapper;
        public SalaryPreferenceService(IBaseRepository<SalaryPreferenceModel> baseRepository, IMapper mapper)
        {
            this.baseRepository = baseRepository;
            this.mapper = mapper;
        }

        public async Task<Result> Add(SalaryPreferenceDto dto)
        {
            dto.Monto = dto.Monto.Replace("S/", string.Empty);
            var entity = mapper.Map<SalaryPreferenceModel>(dto);
            await baseRepository.Add(entity);
            dto.Id = entity.Id;

            return new Result
            {
                Data = dto,
                StateCode = Constants.StateCodeResult.STATE_CODE_OK
            };
        }

        public async Task<Result> GetSalaryByPostulant(int IdPerson)
        {
            var entites = await baseRepository.FindAllPredicate(x => x.IdPerson == IdPerson && x.Active == true);
            
            var dto = mapper.Map<List<SalaryPreferenceDto>>(entites);
            
            return new Result
            {
                StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                Data = dto
            };
        }

        public async Task<Result> Update(SalaryPreferenceDto dto)
        {
            dto.Monto = dto.Monto.Replace("S/", string.Empty);
            var entity = mapper.Map<SalaryPreferenceModel>(dto);
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
