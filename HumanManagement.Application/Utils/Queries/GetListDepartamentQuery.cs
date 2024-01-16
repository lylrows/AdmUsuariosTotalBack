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
    public class GetListDepartamentQuery : IRequest<Result>
    {
        public class GetListDepartamentQueryQueryHandler : IRequestHandler<GetListDepartamentQuery, Result>
        {
            private readonly IUtilRepository _utilRepository;
            public GetListDepartamentQueryQueryHandler(IUtilRepository utilRepository)
            {
                this._utilRepository = utilRepository;
            }

            public async Task<Result> Handle(GetListDepartamentQuery query, CancellationToken cancellationToken)
            {
                var listdepartament = await _utilRepository.GetDepartament();
                return new Result
                {
                    StateCode = 200,
                    Data = new { data = listdepartament }
                };
            }
        }
    }
}
