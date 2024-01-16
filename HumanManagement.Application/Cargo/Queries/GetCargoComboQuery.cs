using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.Cargo.Contracts;
using HumanManagement.Domain.Cargo.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.Cargo.Queries
{
    
    public class GetCargoComboQuery : IRequest<Result>
    {
        public FilterCargoDto filter { get; set; }

        public class GetCargoComboQueryHandle : IRequestHandler<GetCargoComboQuery, Result>
        {
            private readonly ICargoRepository cargoRepository;
            

            public GetCargoComboQueryHandle(ICargoRepository cargoRepository)
            {
                this.cargoRepository = cargoRepository;
            }

            public async Task<Result> Handle(GetCargoComboQuery request, CancellationToken cancellationToken)
            {
                var listcargos = cargoRepository.GetCargoByEmpresa(request.filter).Result;

                return new Result
                {
                    Data = listcargos,
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK
                };
            }
        }
    }
}
