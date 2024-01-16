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
    public class GetListProvinceQuery : IRequest<Result>
    {
        public int Id { get; set; }
        public class GetListProvinceQueryQueryHandler : IRequestHandler<GetListProvinceQuery, Result>
        {
            private readonly IUtilRepository _utilRepository;
            public GetListProvinceQueryQueryHandler(IUtilRepository utilRepository)
            {
                this._utilRepository = utilRepository;
            }

            public async Task<Result> Handle(GetListProvinceQuery query, CancellationToken cancellationToken)
            {
                var listprovince = await _utilRepository.GetProvince(query.Id);
                return new Result
                {
                    StateCode = 200,
                    Data = new { data = listprovince }
                };
            }
        }
    }
}
