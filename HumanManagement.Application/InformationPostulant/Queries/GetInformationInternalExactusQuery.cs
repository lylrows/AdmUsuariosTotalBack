using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.InformationPostulant.Contracts;
using HumanManagement.Domain.InformationPostulant.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.InformationPostulant.Queries
{
    public class GetInformationInternalExactusQuery : IRequest<Result>
    {
        public FilterInformationExactusInternalDto dto { get; set; }
        public class GetInformationInternalExactusQueryHandle : IRequestHandler<GetInformationInternalExactusQuery, Result>
        {
            private readonly IInformationPostulantRepository postulantRepository;

            public GetInformationInternalExactusQueryHandle(IInformationPostulantRepository postulantRepository)
            {
                this.postulantRepository = postulantRepository;
            }

            public async Task<Result> Handle(GetInformationInternalExactusQuery request, CancellationToken cancellationToken)
            {
                var _result = await postulantRepository.GetInformationInternalExactus(request.dto);

                return new Result
                {
                    Data = _result,
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK
                };
            }
        }
    }
}
