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
    public class GetListNacionalityQuery : IRequest<Result>
    {
        public class GetListNacionalityQueryHandler : IRequestHandler<GetListNacionalityQuery, Result>
        {
            private readonly IUtilRepository _utilRepository;
            public GetListNacionalityQueryHandler(IUtilRepository utilRepository)
            {
                this._utilRepository = utilRepository;
            }

            public async Task<Result> Handle(GetListNacionalityQuery query, CancellationToken cancellationToken)
            {
                var listnationality = await _utilRepository.GetListNationality();
                return new Result
                {
                    StateCode = 200,
                    Data = new { data = listnationality }
                };
            }
        }
    }
}
