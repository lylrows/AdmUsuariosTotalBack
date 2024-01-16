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
    public class UpdateEvaluationProficiencyCommand: IRequest<Result>
    {
        public EvaluationProficiencyDto dto { get; set; }
    }

    public class UpdateEvaluationProficiencyCommandHandler : IRequestHandler<UpdateEvaluationProficiencyCommand, Result>
    {
        private readonly IBaseRepository<EvaluationProficiency> baseRepository;
        private readonly IMapper mapper;
        public UpdateEvaluationProficiencyCommandHandler(IBaseRepository<EvaluationProficiency> baseRepository, IMapper mapper)
        {
            this.baseRepository = baseRepository;
            this.mapper = mapper;
        }
        public async Task<Result> Handle(UpdateEvaluationProficiencyCommand request, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<EvaluationProficiency>(request.dto);

            if (entity.Id == 0)
            {
                await baseRepository.Add(entity);
            }
            else
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
