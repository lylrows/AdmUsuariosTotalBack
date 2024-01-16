using AutoMapper;
using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.EvaluationPostulant.Dto;
using HumanManagement.Domain.EvaluationPostulant.Models;
using MediatR;
using System;

using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.EvaluationPostulants.Command
{
    public class DeleteEvaluationTestCommand : IRequest<Result>
    {
        public EvaluationExternTestDto Dto { get; set; }
    }

    public class DeleteEvaluationTestCommandHandle : IRequestHandler<DeleteEvaluationTestCommand, Result>
    {
        private readonly IBaseRepository<EvaluationExternTest> baseRepository;
        private readonly IMapper mapper;

        public DeleteEvaluationTestCommandHandle(IBaseRepository<EvaluationExternTest> baseRepository, IMapper mapper)
        {
            this.baseRepository = baseRepository;
            this.mapper = mapper;
        }
        public async Task<Result> Handle(DeleteEvaluationTestCommand request, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<EvaluationExternTest>(request.Dto);
           
            try
            {
                await baseRepository.Delete(entity);
            }
            catch (Exception ex)
            {

            }

            return new Result
            {
                Data = entity,
                StateCode = Constants.StateCodeResult.STATE_CODE_OK
            };
        }
    }
}
