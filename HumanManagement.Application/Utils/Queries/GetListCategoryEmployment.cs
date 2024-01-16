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
    public class GetListCategoryEmployment : IRequest<Result>
    {
        public class GetListCategoryEmploymentQueryQueryHandler : IRequestHandler<GetListCategoryEmployment, Result>
        {
            private readonly IUtilRepository _utilRepository;
            public GetListCategoryEmploymentQueryQueryHandler(IUtilRepository utilRepository)
            {
                this._utilRepository = utilRepository;
            }

            public async Task<Result> Handle(GetListCategoryEmployment query, CancellationToken cancellationToken)
            {
                var listdistrict = await _utilRepository.GetListCategoryEmployment();
                return new Result
                {
                    StateCode = 200,
                    Data = new { data = listdistrict }
                };
            }
        }
    }
}
