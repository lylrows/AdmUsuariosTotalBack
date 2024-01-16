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
    public class GetformationPostulantRequestQuery : IRequest<Result>
    {
        public FilterInformationPostulantRequest dto { get; set; }
        public class GetformationPostulantRequestQueryHandle : IRequestHandler<GetformationPostulantRequestQuery, Result>
        {
            private readonly IInformationPostulantRepository postulantRepository;
            public GetformationPostulantRequestQueryHandle(IInformationPostulantRepository postulantRepository)
            {
                this.postulantRepository = postulantRepository;
            }
            public async Task<Result> Handle(GetformationPostulantRequestQuery request, CancellationToken cancellationToken)
            {
                var result = await postulantRepository.GetInformationPostulantRequest(request.dto);
                return new Result
                {
                    Data = result,
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK
                };
            }
        }
    }
}
