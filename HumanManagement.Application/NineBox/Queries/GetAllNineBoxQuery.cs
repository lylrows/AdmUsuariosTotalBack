using HumanManagement.Application.Response;
using HumanManagement.Domain.Cargo.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using HumanManagement.Domain.NineBox.Contracts;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.Areas.QueryFilter;
using HumanManagement.Domain.NineBox.QueryFilter;

namespace HumanManagement.Application.NineBox.Queries
{
    public class GetAllNineBoxQuery : IRequest<Result>
    {
        public NineBoxQueryFilter nineBoxQueryFilter { get; set; }
        public class GetAllNineBoxQueryHandler : IRequestHandler<GetAllNineBoxQuery, Result>
        {
            private readonly INineBoxRepository _nineBoxRepository;

            public GetAllNineBoxQueryHandler(INineBoxRepository nineBoxRepository)
            {
                this._nineBoxRepository = nineBoxRepository;
            }
            public async Task<Result> Handle(GetAllNineBoxQuery request, CancellationToken cancellationToken)
            {

                var result = await _nineBoxRepository.GetListNineBox(request.nineBoxQueryFilter);

                return new Result
                {
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                    Data = result
                };
            }
        }
    }
}
