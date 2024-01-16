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
    public class CreateNotesEvaluationCommand: IRequest<Result>
    {
        public NotesEvaluationDto NotesEvaluationDto { get; set; }
    }

    public class CreateNotesEvaluationCommandHandler : IRequestHandler<CreateNotesEvaluationCommand, Result>
    {
        private readonly IBaseRepository<NotesEvaluation> baseRepository;
        private readonly IMapper mapper;
        public CreateNotesEvaluationCommandHandler(IBaseRepository<NotesEvaluation> baseRepository,
                                                  IMapper mapper)
        {
            this.baseRepository = baseRepository;
            this.mapper = mapper;
        }
        public async Task<Result> Handle(CreateNotesEvaluationCommand request, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<NotesEvaluation>(request.NotesEvaluationDto);
            try
            {
                await baseRepository.Add(entity);
            }
            catch (Exception ex)
            {
                var error = ex;
            }

            return new Result
            {
                StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                Data = entity
            };
        }
    }

}
