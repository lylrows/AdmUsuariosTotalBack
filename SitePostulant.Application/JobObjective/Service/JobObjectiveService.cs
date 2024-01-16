using AutoMapper;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.Postulant.JobObjective.Dto;
using HumanManagement.Domain.Postulant.JobObjective.Models;
using SitePostulant.Application.JobObjective.IService;
using SitePostulant.Application.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SitePostulant.Application.JobObjective.Service
{
    public class JobObjectiveService: IJobObjectiveService
    {
        private readonly IBaseRepository<JobObjectiveModel> baseRepository;
        private readonly IMapper mapper;
        public JobObjectiveService(IBaseRepository<JobObjectiveModel> baseRepository, IMapper mapper)
        {
            this.baseRepository = baseRepository;
            this.mapper = mapper;
        }

        public async Task<Result> Add(JobObjectiveDto dto)
        {
            var entity = mapper.Map<JobObjectiveModel>(dto);
            await baseRepository.Add(entity);
            dto.Id = entity.Id;

            return new Result
            {
                Data = dto,
                StateCode = Constants.StateCodeResult.STATE_CODE_OK
            };
        }

        public async Task<Result> GetObjectivesByPostulant(int IdPerson)
        {
            var entites = await baseRepository.FindAllPredicate(x => x.IdPerson == IdPerson && x.Active == true);
            var dto = mapper.Map<List<JobObjectiveDto>>(entites);
            return new Result
            {
                StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                Data = dto
            };
        }

        public async Task<Result> Update(JobObjectiveDto dto)
        {
            var entity = mapper.Map<JobObjectiveModel>(dto);
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
