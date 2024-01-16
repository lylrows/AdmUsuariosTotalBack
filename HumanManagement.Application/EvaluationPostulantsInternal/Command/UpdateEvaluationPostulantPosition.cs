using AutoMapper;
using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.EvaluationPostulantInternal.Contracts;
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
    public class UpdateEvaluationPostulantPosition: IRequest<Result>
    {
        public EvaluationPostulantPositionDto dto { get; set; }
    }

    public class UpdateEvaluationPostulantPositionHandle : IRequestHandler<UpdateEvaluationPostulantPosition, Result>
    {
        private readonly IBaseRepository<EvaluationPostulantPosition> baseRepository;
        private readonly IMapper mapper;
        private readonly IEvaluationInternalRepository evaluationInternalRepository;

        public UpdateEvaluationPostulantPositionHandle(IBaseRepository<EvaluationPostulantPosition> baseRepository, 
            IMapper mapper,
            IEvaluationInternalRepository evaluationInternalRepository)
        {
            this.baseRepository = baseRepository;
            this.mapper = mapper;
            this.evaluationInternalRepository = evaluationInternalRepository;
        }

        public async Task<Result> Handle(UpdateEvaluationPostulantPosition request, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<EvaluationPostulantPosition>(request.dto);

            if (entity.Id == 0)
            {
                await baseRepository.Add(entity);
            } else
            {
                await baseRepository.Update(entity);
            }

            
            var _resultDelete = await evaluationInternalRepository.DeletePositionPostulant(entity.IdEvaluationPostulant);
            foreach(var _position in request.dto.PositionsCompany)
            {
                _position.nuser = entity.IdUserRegister;
                _position.IdEvaluationPostulant = entity.IdEvaluationPostulant;
                var _resultInsert = await evaluationInternalRepository.InsertPositionPostulant(_position);
            }

            return new Result
            {
                Data = entity,
                StateCode = Constants.StateCodeResult.STATE_CODE_OK
            };
        }
    }
}
