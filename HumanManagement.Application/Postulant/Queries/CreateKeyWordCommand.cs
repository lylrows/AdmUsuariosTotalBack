using AutoMapper;
using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.Job.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.Postulant.Queries
{
    public class CreateKeyWordCommand : IRequest<Result>
    {
        public JobKeyWordDto  jobKeyWordDto { get; set; }
    }

    public class CreateKeyWordCommandHandler : IRequestHandler<CreateKeyWordCommand, Result>
    {
        private readonly IBaseRepository<Domain.Job.Models.JobKeyWords> baseRepository;
        private IMapper mapper;

        public CreateKeyWordCommandHandler(IBaseRepository<Domain.Job.Models.JobKeyWords> baseRepository,
                                        IMapper mapper)
        {
            this.baseRepository = baseRepository;
            this.mapper = mapper;
        }

        public async Task<Result> Handle(CreateKeyWordCommand request, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<Domain.Job.Models.JobKeyWords>(request.jobKeyWordDto);
            await baseRepository.Add(entity);
            return new Result
            {
                StateCode = Constants.StateCodeResult.STATE_CODE_OK
            };
        }
    }
}
