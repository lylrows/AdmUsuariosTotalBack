using AutoMapper;
using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.EvaluationPostulant.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EvaluationModel = HumanManagement.Domain.EvaluationPostulant.Models.Evaluation;

namespace HumanManagement.Application.EvaluationPostulants.Command
{
    public class UpdateEvaluationExternProcessCommand: IRequest<Result>
    {
        public EvaluationDto dto { get; set; }

    }

    public class UpdateEvaluationExternProcessCommandHandle : IRequestHandler<UpdateEvaluationExternProcessCommand, Result>
    {
        private readonly IMapper mapper;
        private readonly IBaseRepository<EvaluationModel> baseRepository;
        public UpdateEvaluationExternProcessCommandHandle(IMapper mapper, IBaseRepository<EvaluationModel> baseRepository)
        {
            this.mapper = mapper;
            this.baseRepository = baseRepository;
        }
        public async Task<Result> Handle(UpdateEvaluationExternProcessCommand request, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<EvaluationModel>(request.dto);
            await baseRepository.UpdatePartial(entity, x=> x.Process);

            return new Result
            {
                Data = entity,
                StateCode = Constants.StateCodeResult.STATE_CODE_OK
            };
        }
    }
}
