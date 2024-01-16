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
    public class GetAreaByManagementQuery : IRequest<Result>
    {
        public int IdManagement { get; set; }

        public class GetAreaByCompanyQueryHandler : IRequestHandler<GetAreaByManagementQuery, Result>
        {
            private readonly IAreaRepository areaRepository;

            public GetAreaByCompanyQueryHandler(IAreaRepository areaRepository)
            {
                this.areaRepository = areaRepository;
            }
            public async Task<Result> Handle(GetAreaByManagementQuery request, CancellationToken cancellationToken)
            {

                var result = await areaRepository.GetAreaByManagement(request.IdManagement);


                return new Result
                {
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                    Data = result
                };
            }
        }
    }
}
