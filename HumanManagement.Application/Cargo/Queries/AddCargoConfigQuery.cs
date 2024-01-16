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
    public class AddCargoConfigQuery : IRequest<int>
    {
        public List<CargoCompetenciaDto> listCargoDto { get; set; }
        public class AddCargoConfigQueryHandler : IRequestHandler<AddCargoConfigQuery, int>
        {
            private readonly IBaseRepository<Domain.Home.Models.Document> baseRepository;
            private readonly ICargoRepository cargoRepository;
            private IMapper mapper;

            public AddCargoConfigQueryHandler(IBaseRepository<Domain.Home.Models.Document> baseRepository,
                                       IMapper mapper,
                                       ICargoRepository cargoRepository)
            {
                this.baseRepository = baseRepository;
                this.mapper = mapper;
                this.cargoRepository = cargoRepository;
            }
            public async Task<int> Handle(AddCargoConfigQuery request, CancellationToken cancellationToken)
            {
                var output = await cargoRepository.AddCargoConfig(request.listCargoDto);
                return output;
            }
        }
    }
}
