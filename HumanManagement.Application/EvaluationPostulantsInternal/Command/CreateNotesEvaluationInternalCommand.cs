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
    public class CreateNotesEvaluationInternalCommand: IRequest<Result>
    {
        public NotesEvaluationInternalDto dto { get; set; }
    }

    public class CreateNotesEvaluationInternalCommandHandle : IRequestHandler<CreateNotesEvaluationInternalCommand, Result>
    {
        private readonly IBaseRepository<NotesEvaluationInternal> baseRepository;
        private readonly IMapper mapper;
        public CreateNotesEvaluationInternalCommandHandle(IBaseRepository<NotesEvaluationInternal> baseRepository,
            IMapper mapper)
        {
            this.baseRepository = baseRepository;
            this.mapper = mapper;
        }
        public async Task<Result> Handle(CreateNotesEvaluationInternalCommand request, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<NotesEvaluationInternal>(request.dto);
            await baseRepository.Add(entity);

            return new Result
            {
                StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                Data = entity
            };
        }
    }
}
