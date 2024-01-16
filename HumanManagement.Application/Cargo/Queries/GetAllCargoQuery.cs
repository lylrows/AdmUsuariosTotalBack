using HumanManagement.Application.Response;
using HumanManagement.Domain.Cargo.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace HumanManagement.Application.Cargo.Queries
{
    public class GetAllCargoQuery : IRequest<Result>
    {
        public class GetAllCargoQueryHandler : IRequestHandler<GetAllCargoQuery, Result>
        {
            private readonly ICargoRepository cargoRepository;

            public GetAllCargoQueryHandler(ICargoRepository cargoRepository)
            {
                this.cargoRepository = cargoRepository;
            }
            public async Task<Result> Handle(GetAllCargoQuery request, CancellationToken cancellationToken)
            {
                var output = new Result();
                var dto = await cargoRepository.GetListCargo();
                dto = dto.OrderBy(x => x.NameCargo).ToList();
                output.Data = dto;
                output.StateCode = 1;
                return output;    
            }
        }
    }
}
