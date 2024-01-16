using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.Cargo.Contracts;
using HumanManagement.Domain.Cargo.QueryFilter;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.Cargo.Queries
{
   
    public class GetChargesByCompanyAreav2Query : IRequest<Result>
    {
        public ChargesByCompanyAreaFilter chargesByCompanyAreaFilter { get; set; }

        public class GetChargesByCompanyAreav2QueryHandler : IRequestHandler<GetChargesByCompanyAreav2Query, Result>
        {
            private readonly ICargoRepository cargoRepository;

            public GetChargesByCompanyAreav2QueryHandler(ICargoRepository cargoRepository)
            {
                this.cargoRepository = cargoRepository;
            }
            public async Task<Result> Handle(GetChargesByCompanyAreav2Query request, CancellationToken cancellationToken)
            {
                var result = await cargoRepository.GetChargesByCompanyAreav2(request.chargesByCompanyAreaFilter);

                return new Result
                {
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                    Data = result
                };
            }
        }
    }
}
