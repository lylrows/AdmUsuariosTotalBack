using AutoMapper;
using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.Job.Dto;
using HumanManagement.Domain.Job.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.JobsInternal.Command
{
    public class CreateJobPostulantCommand: IRequest<Result>
    {
        public JobOffersInternalPostulantDto dto { get; set; }
    }

    public class CreateJobPostulantCommandHandle : IRequestHandler<CreateJobPostulantCommand, Result>
    {
        private readonly IBaseRepository<JobOffersInternalPostulant> baseRepository;
        private readonly IMapper mapper;
        public CreateJobPostulantCommandHandle(IMapper mapper, IBaseRepository<JobOffersInternalPostulant> baseRepository)
        {
            this.baseRepository = baseRepository;
            this.mapper = mapper;
        }
        public async Task<Result> Handle(CreateJobPostulantCommand request, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<JobOffersInternalPostulant>(request.dto);
            entity.IdState = 758;
            await baseRepository.Add(entity);

            return new Result
            {
                StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                Data = entity
            };
        }
    }
}
