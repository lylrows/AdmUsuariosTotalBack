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
    public class UpdateEvaluationFortalezasInternCommand: IRequest<Result>
    {
        public EvaluationFortalezasInternDto dto { get; set; }
    }

    public class UpdateEvaluationFortalezasInternCommandHandle : IRequestHandler<UpdateEvaluationFortalezasInternCommand, Result>
    {
        private readonly IBaseRepository<EvaluationFortalezasIntern> baseRepository;
        private readonly IMapper mapper;

        public UpdateEvaluationFortalezasInternCommandHandle(IBaseRepository<EvaluationFortalezasIntern> baseRepository, IMapper mapper)
        {
            this.baseRepository = baseRepository;
            this.mapper = mapper;
        }
        public async Task<Result> Handle(UpdateEvaluationFortalezasInternCommand request, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<EvaluationFortalezasIntern>(request.dto);
            await baseRepository.Update(entity);

            return new Result
            {
                Data = entity,
                StateCode = Constants.StateCodeResult.STATE_CODE_OK
            };
        }
    }
}
