using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.Areas.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.Areas.Queries
{
    public class GetAreaByCompanyQuery : IRequest<Result>
    {
        public int IdCompany { get; set; }

        public class GetAreaByCompanyQueryHandler : IRequestHandler<GetAreaByCompanyQuery, Result>
        {
            private readonly IAreaRepository areaRepository;

            public GetAreaByCompanyQueryHandler(IAreaRepository areaRepository)
            {
                this.areaRepository = areaRepository;
            }
            public async Task<Result> Handle(GetAreaByCompanyQuery request, CancellationToken cancellationToken)
            {
                
                var result = await areaRepository.GetByEmpresa(request.IdCompany);
                

                return new Result
                {
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                    Data = result
                };
            }
        }
    }
}
