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
    public class DeleteKeyWordCommand : IRequest<Result>
    {
        public JobKeyWordDto jobKeyWordDto { get; set; }
    }

    public class DeleteKeyWordCommandHandler : IRequestHandler<DeleteKeyWordCommand, Result>
    {
        private readonly IBaseRepository<Domain.Job.Models.JobKeyWords> baseRepository;
        private IMapper mapper;

        public DeleteKeyWordCommandHandler(IBaseRepository<Domain.Job.Models.JobKeyWords> baseRepository,
                                        IMapper mapper)
        {
            this.baseRepository = baseRepository;
            this.mapper = mapper;
        }

        public async Task<Result> Handle(DeleteKeyWordCommand request, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<Domain.Job.Models.JobKeyWords>(request.jobKeyWordDto);
            await baseRepository.Delete(entity);
            return new Result
            {
                StateCode = Constants.StateCodeResult.STATE_CODE_OK
            };
        }
    }
}
