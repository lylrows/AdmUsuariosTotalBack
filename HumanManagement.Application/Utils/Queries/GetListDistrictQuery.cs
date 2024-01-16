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
    public class GetListDistrictQuery : IRequest<Result>
    {
        public int Id { get; set; } 
        public class GetListDistrictQueryQueryHandler : IRequestHandler<GetListDistrictQuery, Result>
        {
            private readonly IUtilRepository _utilRepository;
            public GetListDistrictQueryQueryHandler(IUtilRepository utilRepository)
            {
                this._utilRepository = utilRepository;
            }

            public async Task<Result> Handle(GetListDistrictQuery query, CancellationToken cancellationToken)
            {
                var listdistrict = await _utilRepository.GetDistrict(query.Id);
                return new Result
                {
                    StateCode = 200,
                    Data = new { data = listdistrict }
                };
            }
        }
    }
}
