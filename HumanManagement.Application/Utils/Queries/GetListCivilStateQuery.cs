using HumanManagement.Application.Response;
using HumanManagement.Domain.Utils.Constracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.Utils.Queries
{
    public class GetListCivilStateQuery : IRequest<Result>
    {
        public class GetListCivilStateQueryHandler : IRequestHandler<GetListCivilStateQuery, Result>
        {
            private readonly IUtilRepository _utilRepository;
            public GetListCivilStateQueryHandler(IUtilRepository utilRepository)
            {
                this._utilRepository = utilRepository;
            }

            public async Task<Result> Handle(GetListCivilStateQuery query, CancellationToken cancellationToken)
            {
                var listcivil = await _utilRepository.GetListCivil();
                return new Result
                {
                    StateCode = 200,
                    Data = new { data = listcivil }
                };
            }
        }
    }
}
