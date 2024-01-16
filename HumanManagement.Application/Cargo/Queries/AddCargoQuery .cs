using AutoMapper;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.Cargo.Contracts;
using HumanManagement.Domain.Cargo.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.Cargo.Queries
{
    public class AddCargoQuery : IRequest<int>
    {
        public CargoDto cargoDto { get; set; }
        public class AddCargoQueryHandler : IRequestHandler<AddCargoQuery, int>
        {
            private readonly IBaseRepository<Domain.Home.Models.Document> baseRepository;
            private readonly ICargoRepository cargoRepository;
            private IMapper mapper;

            public AddCargoQueryHandler(IBaseRepository<Domain.Home.Models.Document> baseRepository,
                                       IMapper mapper,
                                       ICargoRepository cargoRepository)
            {
                this.baseRepository = baseRepository;
                this.mapper = mapper;
                this.cargoRepository = cargoRepository;
            }
            public async Task<int> Handle(AddCargoQuery request, CancellationToken cancellationToken)
            {
                var output = await cargoRepository.AddCharge(request.cargoDto);
                return output;
            }
        }
    }
}
