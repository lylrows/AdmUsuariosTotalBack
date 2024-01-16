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
   
    public class GetChargesByCompanyAreaMultiQuery : IRequest<Result>
    {
        public ChargesByCompanyAreaMultiFilter chargesByCompanyAreaFilter { get; set; }

        public class GetChargesByCompanyAreaMultiQueryHandler : IRequestHandler<GetChargesByCompanyAreaMultiQuery, Result>
        {
            private readonly ICargoRepository cargoRepository;

            public GetChargesByCompanyAreaMultiQueryHandler(ICargoRepository cargoRepository)
            {
                this.cargoRepository = cargoRepository;
            }
            public async Task<Result> Handle(GetChargesByCompanyAreaMultiQuery request, CancellationToken cancellationToken)
            {
                var result = await cargoRepository.GetChargesByCompanyAreaMulti(request.chargesByCompanyAreaFilter);

                return new Result
                {
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                    Data = result
                };
            }
        }
    }
}
