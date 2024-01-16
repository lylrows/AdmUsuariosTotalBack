using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.Cargo.Contracts;
using HumanManagement.Domain.Employee.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.Cargo.Queries
{
    public class GetJefeByChargeQuery: IRequest<Result>
    {
        public int IdCharge { get; set; }

        public class GetJefeByChargeQueryHandle : IRequestHandler<GetJefeByChargeQuery, Result>
        {
            private readonly ICargoRepository cargoRepository;
            private IBaseRepository<EmployeeModel> baseRepository;

            public GetJefeByChargeQueryHandle(ICargoRepository cargoRepository , IBaseRepository<EmployeeModel> baseRepository)
            {
                this.cargoRepository = cargoRepository;
                this.baseRepository = baseRepository;
            }

            public async Task<Result> Handle(GetJefeByChargeQuery request, CancellationToken cancellationToken)
            {
                int position = 0;
                var output = await cargoRepository.GetJefeByCharge(request.IdCharge);
                if (output != 0)
                {
                    var employee = await baseRepository.FindPredicate(x => x.Id == output);
                    position = employee.IdPosition;
                }

                return new Result
                {
                    Data = position,
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK
                };
            }
        }
    }
}
