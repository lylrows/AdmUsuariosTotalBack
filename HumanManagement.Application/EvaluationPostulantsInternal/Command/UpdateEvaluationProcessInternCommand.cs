using AutoMapper;
using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.EvaluationPostulantInternal.Dto;
using HumanManagement.Domain.EvaluationPostulantInternal.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.EvaluationPostulantsInternal.Command
{
    public class UpdateEvaluationProcessInternCommand: IRequest<Result>
    {
        public EvaluationVacantInternalDto dto { get; set; }
    }

    public class UpdateEvaluationProcessInternCommandHandle : IRequestHandler<UpdateEvaluationProcessInternCommand, Result>
    {
        private readonly IBaseRepository<EvaluationVacantInternal> baseRepository;
        private readonly IMapper mapper;

        public UpdateEvaluationProcessInternCommandHandle(IBaseRepository<EvaluationVacantInternal> baseRepository, IMapper mapper)
        {
            this.baseRepository = baseRepository;
            this.mapper = mapper;
        }
        public async Task<Result> Handle(UpdateEvaluationProcessInternCommand request, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<EvaluationVacantInternal>(request.dto);
            await baseRepository.UpdatePartial(entity, x => x.Process);

            return new Result
            {
                Data = entity,
                StateCode = Constants.StateCodeResult.STATE_CODE_OK
            };

        }
    }
}
