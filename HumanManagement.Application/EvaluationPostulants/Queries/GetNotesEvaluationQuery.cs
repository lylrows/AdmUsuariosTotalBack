using HumanManagement.Application.Response;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.EvaluationPostulant.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using HumanManagement.CrossCutting.Utils;
using AutoMapper;
using HumanManagement.Domain.EvaluationPostulant.Dto;

namespace HumanManagement.Application.EvaluationPostulants.Queries
{
    public class GetNotesEvaluationQuery: IRequest<Result>
    {
        public int IdEvaluationPostulant { get; set; }
        public class GetNotesEvaluationQueryHandler : IRequestHandler<GetNotesEvaluationQuery, Result>
        {
            private readonly IBaseRepository<NotesEvaluation> baseRepository;
            private readonly IMapper mapper;
            public GetNotesEvaluationQueryHandler(IBaseRepository<NotesEvaluation> baseRepository, IMapper mapper)
            {
                this.baseRepository = baseRepository;
                this.mapper = mapper;
            }
            public async Task<Result> Handle(GetNotesEvaluationQuery request, CancellationToken cancellationToken)
            {
                var entity = await baseRepository.FindAllPredicate(x => x.IdEvaluationPostulant == request.IdEvaluationPostulant);
                var dto = mapper.Map<List<NotesEvaluationDto>>(entity);
                dto = dto.OrderBy(x => x.DateRegister).ToList();

                return new Result
                {
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                    Data = entity
                };
            }
        }
    }
}
