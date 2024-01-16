using AutoMapper;
using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.EvaluationPostulantInternal.Dto;
using HumanManagement.Domain.EvaluationPostulantInternal.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.EvaluationPostulantsInternal.Queries
{
    public class GetNotesEvaluationInternalQuery: IRequest<Result>
    {
        public int IdEvaluationPostulant { get; set; }

        public class GetNotesEvaluationInternalQueryHandle : IRequestHandler<GetNotesEvaluationInternalQuery, Result>
        {
            private readonly IBaseRepository<NotesEvaluationInternal> baseRepository;
            private readonly IMapper mapper;

            public GetNotesEvaluationInternalQueryHandle(IBaseRepository<NotesEvaluationInternal> baseRepository, IMapper mapper)
            {
                this.baseRepository = baseRepository;
                this.mapper = mapper;
            }
            public async Task<Result> Handle(GetNotesEvaluationInternalQuery request, CancellationToken cancellationToken)
            {

                var entity = await baseRepository.FindAllPredicate(x => x.IdEvaluationPostulant == request.IdEvaluationPostulant);
                var dto = mapper.Map<List<NotesEvaluationInternalDto>>(entity);
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
