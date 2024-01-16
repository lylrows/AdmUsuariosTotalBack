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
    public class UpdateEvaluationRatingPostulantCommand: IRequest<Result>
    {
        public EvaluationRatingPostulantDto dto { get; set; }
    }

    public class UpdateEvaluationRatingPostulantCommandHandle : IRequestHandler<UpdateEvaluationRatingPostulantCommand, Result>
    {
        private readonly IBaseRepository<EvaluationRatingPostulant> baseRepository;
        private readonly IMapper mapper;
        public UpdateEvaluationRatingPostulantCommandHandle(IBaseRepository<EvaluationRatingPostulant> baseRepository,
                                                            IMapper mapper)
        {
            this.baseRepository = baseRepository;
            this.mapper = mapper;
        }
        public async Task<Result> Handle(UpdateEvaluationRatingPostulantCommand request, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<EvaluationRatingPostulant>(request.dto);
            await baseRepository.Update(entity);

            return new Result
            {
                Data = entity,
                StateCode = Constants.StateCodeResult.STATE_CODE_OK
            };
        }
    }
}
