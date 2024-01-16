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

    public class GetAreaByUserQuery : IRequest<Result>
    {
        public int IdUser { get; set; }

        public class GetAreaByUserQueryHandler : IRequestHandler<GetAreaByUserQuery, Result>
        {
            private readonly IAreaRepository areaRepository;

            public GetAreaByUserQueryHandler(IAreaRepository areaRepository)
            {
                this.areaRepository = areaRepository;
            }
            public async Task<Result> Handle(GetAreaByUserQuery request, CancellationToken cancellationToken)
            {

                var result = await areaRepository.GetAreaByIdUser(request.IdUser);


                return new Result
                {
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                    Data = result
                };
            }
        }
    }
}
