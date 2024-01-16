using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.Postulant.Education.Contracts;
using HumanManagement.Domain.Postulant.Education.Dto;
using SitePostulant.Application.EducationPostulant.IServices;
using HumanManagement.Domain.Postulant.Education.Models;
using SitePostulant.Application.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HumanManagement.CrossCutting.Utils;
using AutoMapper;
using EducationPostulantModel = HumanManagement.Domain.Postulant.Education.Models.EducationPostulant;

namespace SitePostulant.Application.EducationPostulant.Services
{
    public class EducationPostulantService: IEducationPostulantService
    {
        private readonly IEducationPostulantRepository educationPostulantRepository;
        private readonly IBaseRepository<EducationPostulantModel> educationBaseRepository;
        private readonly IMapper mapper;
        public EducationPostulantService(IEducationPostulantRepository educationPostulantRepository, IBaseRepository<HumanManagement.Domain.Postulant.Education.Models.EducationPostulant> educationBaseRepository,
            IMapper mapper)
        {
            this.educationPostulantRepository = educationPostulantRepository;
            this.educationBaseRepository = educationBaseRepository;
            this.mapper = mapper;
        }

        public async Task<Result> Add(EducationPostulantDto dto)
        {
           var entity = mapper.Map<EducationPostulantModel>(dto);
           await educationBaseRepository.Add(entity);
            dto.Id = entity  .Id;

            return new Result
            {
                Data = dto,
                StateCode = Constants.StateCodeResult.STATE_CODE_OK
            };
        }

        public async Task<Result> GetEducationPostulant(int IdPerson)
        {
            var dto = await educationPostulantRepository.GetEducationByPostulant(IdPerson);

            return new Result
            {
                StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                Data = dto
            };
        }

        public async Task<Result> Update(EducationPostulantDto dto)
        {
            var entity = mapper.Map<EducationPostulantModel>(dto);
            await educationBaseRepository.Update(entity);
            dto.Id = entity.Id;

            return new Result
            {
                Data = dto,
                StateCode = Constants.StateCodeResult.STATE_CODE_OK
            };
        }
    }
}
