using AutoMapper;
using HumanManagement.Application.Response;
using HumanManagement.Domain.BaseRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using HumanManagement.Domain.Cargo.Dto;
using Microsoft.EntityFrameworkCore;
using HumanManagement.Domain.Cargo.Contracts;
using HumanManagement.Domain.Areas.QueryFilter;
using HumanManagement.Domain.Cargo.QueryFilter;

namespace HumanManagement.Application.Cargo.Queries
{
    public class GetCargoQuery : IRequest<Result>
    {
        public CargoQueryFilter cargoQueryFilter { get; set; }
        public class GetCargoQueryHandler : IRequestHandler<GetCargoQuery, Result>
        {
            private readonly ICargoRepository cargoRepository;

            public GetCargoQueryHandler(ICargoRepository cargoRepository)
            {
                this.cargoRepository = cargoRepository;
            }
            public async Task<Result> Handle(GetCargoQuery request, CancellationToken cancellationToken)
            {
                var output = new Result();
                var dto = await cargoRepository.GetAll(request.cargoQueryFilter);
                output.Data = dto;
                output.StateCode = 1;
                return output;
            }
        }
    }
}
