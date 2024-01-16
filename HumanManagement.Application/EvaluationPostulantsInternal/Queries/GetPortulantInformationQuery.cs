using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.EvaluationPostulantInternal.Contracts;
using HumanManagement.Domain.InformationPostulant.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.EvaluationPostulantsInternal.Queries
{
    public class GetPortulantInformationQuery : IRequest<Result>
    {
        public FilterParamDto filter { get; set; }
        public class GetPortulantInformationQueryHandle : IRequestHandler<GetPortulantInformationQuery, Result>
        {
            private readonly IEvaluationPostulantsInternalRepository _evaluationPostulantsInternalRepository;

            public GetPortulantInformationQueryHandle(IEvaluationPostulantsInternalRepository evaluationPostulantsInternalRepository)
            {
                _evaluationPostulantsInternalRepository = evaluationPostulantsInternalRepository;
            }
            public async Task<Result> Handle(GetPortulantInformationQuery request, CancellationToken cancellationToken)
            {
                var dto = await _evaluationPostulantsInternalRepository.GetEvaluationPostulantsAll(request.filter);

                return new Result
                {
                    Data = dto,
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK
                };
            }
        }
    }
}
