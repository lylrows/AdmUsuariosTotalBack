using AutoMapper;
using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.BaseRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EvaluationModel = HumanManagement.Domain.EvaluationPostulant.Models.Evaluation;

namespace HumanManagement.Application.EvaluationPostulants.Queries
{
    public class GetIdEvaluationPostulantQuery: IRequest<Result>
    {
        public int IdJob { get; set; }
        public class GetIdEvaluationPostulantQueryHandle : IRequestHandler<GetIdEvaluationPostulantQuery, Result>
        {
            private readonly IBaseRepository<EvaluationModel> baseRepository;
            private readonly IMapper mapper;
            public GetIdEvaluationPostulantQueryHandle(IBaseRepository<EvaluationModel> baseRepository,
                                                       IMapper mapper)
            {
                this.baseRepository = baseRepository;
                this.mapper = mapper;
            }
            public async Task<Result> Handle(GetIdEvaluationPostulantQuery request, CancellationToken cancellationToken)
            {
                var entity = await baseRepository.FindPredicate(x => x.IdJob == request.IdJob);
                return new Result
                {
                    Data = entity?.Id,
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK
                };
            }
        }
    }
}
