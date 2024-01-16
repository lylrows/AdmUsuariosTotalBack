using AutoMapper;
using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.EvaluationPostulant.Dto;
using HumanManagement.Domain.EvaluationPostulant.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.EvaluationPostulants.Command
{
    public class CreateEvaluationTestCommand: IRequest<Result>
    {
        public EvaluationExternTestDto Dto { get; set; }
    }

    public class CreateEvaluationTestCommandHandle : IRequestHandler<CreateEvaluationTestCommand, Result>
    {
        private readonly IBaseRepository<EvaluationExternTest> baseRepository;
        private readonly IMapper mapper;

        public CreateEvaluationTestCommandHandle(IBaseRepository<EvaluationExternTest> baseRepository, IMapper mapper)
        {
            this.baseRepository = baseRepository;
            this.mapper = mapper;
        }
        public async Task<Result> Handle(CreateEvaluationTestCommand request, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<EvaluationExternTest>(request.Dto);

            if (entity.Id == 0)
            {
                await baseRepository.Add(entity);
            } else
            {
                await baseRepository.Update(entity);
            }

            return new Result
            {
                Data = entity,
                StateCode = Constants.StateCodeResult.STATE_CODE_OK
            };
        }
    }
}
