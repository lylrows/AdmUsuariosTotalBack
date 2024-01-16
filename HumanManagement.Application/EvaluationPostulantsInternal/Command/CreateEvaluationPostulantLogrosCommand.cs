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
    public class CreateEvaluationPostulantLogrosCommand: IRequest<Result>
    {
        public EvaluationPostulantInternalLogrosDto dto { get; set; }
    }

    public class CreateEvaluationPostulantLogrosCommandHandle : IRequestHandler<CreateEvaluationPostulantLogrosCommand, Result>
    {
        private readonly IBaseRepository<EvaluationPostulantInternalLogros> baseRepository;
        private readonly IMapper mapper;
        public CreateEvaluationPostulantLogrosCommandHandle(IBaseRepository<EvaluationPostulantInternalLogros> baseRepository, IMapper mapper)
        {
            this.baseRepository = baseRepository;
            this.mapper = mapper;

        }
        public async Task<Result> Handle(CreateEvaluationPostulantLogrosCommand request, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<EvaluationPostulantInternalLogros>(request.dto);
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
