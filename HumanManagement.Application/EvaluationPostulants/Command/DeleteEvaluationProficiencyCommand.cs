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
    public class DeleteEvaluationProficiencyCommand : IRequest<Result>
    {
        public EvaluationProficiencyDto dto { get; set; }
    }

    public class DeleteEvaluationProficiencyCommandHandler : IRequestHandler<DeleteEvaluationProficiencyCommand, Result>
    {
        private readonly IBaseRepository<EvaluationProficiency> baseRepository;
        private readonly IMapper mapper;
        public DeleteEvaluationProficiencyCommandHandler(IBaseRepository<EvaluationProficiency> baseRepository, IMapper mapper)
        {
            this.baseRepository = baseRepository;
            this.mapper = mapper;
        }
        public async Task<Result> Handle(DeleteEvaluationProficiencyCommand request, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<EvaluationProficiency>(request.dto);
            if (entity.Id == 0)
            {
                
            }
            else
            {
                await baseRepository.Delete(entity);
            }

            return new Result
            {
                Data = entity,
                StateCode = Constants.StateCodeResult.STATE_CODE_OK
            };
        }
    }
}
