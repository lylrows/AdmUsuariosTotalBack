using AutoMapper;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.Postulant.WorkExperience.Contracts;
using HumanManagement.Domain.Postulant.WorkExperience.Dto;
using HumanManagement.Domain.Postulant.WorkExperience.Models;
using SitePostulant.Application.Response;
using SitePostulant.Application.WorkExperience.IService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SitePostulant.Application.WorkExperience.Service
{
    public class WorkExperienceService : IWorkExperienceService
    {
        private readonly IWorkExperienceRepository workExperienceRepository;
        private readonly IBaseRepository<WorkExperienceModel> baseRepository;
        private readonly IMapper mapper;
        public WorkExperienceService(IWorkExperienceRepository workExperienceRepository,
                                     IBaseRepository<WorkExperienceModel> baseRepository,
                                     IMapper mapper)
        {
            this.workExperienceRepository = workExperienceRepository;
            this.baseRepository = baseRepository;
            this.mapper = mapper;
        }

        public async Task<Result> Add(WorkExperienceDto dto)
        {
            dto.Salary = dto.Salary.Replace("S/", string.Empty);
            var entity = mapper.Map<WorkExperienceModel>(dto);
            entity.Salary = Convert.ToDecimal(entity.Salary);
            await baseRepository.Add(entity);
            dto.Id = entity.Id;

            return new Result
            {
                Data = dto,
                StateCode = Constants.StateCodeResult.STATE_CODE_OK
            };
        }

        public async Task<Result> GetWorkExperience(int IdPerson)
        {
            var dto = await workExperienceRepository.GetWorkExperience(IdPerson);

            return new Result
            {
                Data = dto,
                StateCode = Constants.StateCodeResult.STATE_CODE_OK
            };
        }

        public async Task<Result> Update(WorkExperienceDto dto)
        {
             
            dto.Salary = dto.Salary.Replace("S/", string.Empty);
            var entity = mapper.Map<WorkExperienceModel>(dto);
            entity.Salary= Convert.ToDecimal(entity.Salary);
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
