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
    public class UpdateEvaluationProficiencyInternCommand: IRequest<Result>
    {
        public EvaluationProficiencyInternDto dto { get; set; }
    }

    public class UpdateEvaluationProficiencyInternCommandHandle : IRequestHandler<UpdateEvaluationProficiencyInternCommand, Result>
    {
        private readonly IBaseRepository<EvaluationProficiencyIntern> baseRepository;
        private readonly IMapper mapper;

        public UpdateEvaluationProficiencyInternCommandHandle(IBaseRepository<EvaluationProficiencyIntern> baseRepository, IMapper mapper)
        {
            this.baseRepository = baseRepository;
            this.mapper = mapper;
        }
        public async Task<Result> Handle(UpdateEvaluationProficiencyInternCommand request, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<EvaluationProficiencyIntern>(request.dto);
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
