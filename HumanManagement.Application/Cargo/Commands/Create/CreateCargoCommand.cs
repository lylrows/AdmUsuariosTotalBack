using AutoMapper;
using HumanManagement.Application.Response;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.Cargo.Contracts;
using HumanManagement.Domain.Cargo.Dto;
using HumanManagement.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.Cargo.Commands.Create
{
    public class CreateCargoCommand: IRequest<Result>
    {
         public CargoDto cargoDto { get; set; }
    }

    public class CreateCargoCommandHandler : IRequestHandler<CreateCargoCommand, Result>
    {
        private readonly IBaseRepository<Domain.Cargo.Models.Cargo> baseRepository;
        private IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly ICargoRepository cargoRepository;

        public CreateCargoCommandHandler(IBaseRepository<Domain.Cargo.Models.Cargo> baseRepository,
                                     IMapper mapper,
                                     IUnitOfWork unitOfWork,
                                     ICargoRepository cargoRepository)
        {
            this.baseRepository = baseRepository;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.cargoRepository = cargoRepository;
        }
        public async Task<Result> Handle(CreateCargoCommand request, CancellationToken cancellationToken)
        {
            var output = new Result();
            var cargos = await cargoRepository.GetListCargo();
            var cargoExist = cargos.Where(x => x.IdEmpresa == request.cargoDto.IdEmpresa && x.NameCargo == request.cargoDto.NameCargo).ToList();
            if (cargoExist.Count == 0)
            {
                var entity = mapper.Map<Domain.Cargo.Models.Cargo>(request.cargoDto);
                // LOGICA DE SI ES GERENCIA, AREA O SUBAREA
                if (request.cargoDto.IdGerenciaCombo>0 && request.cargoDto.IdAreaCombo==0 && request.cargoDto.IdSubAreaCombo==0)
                {
                    entity.IdArea = request.cargoDto.IdGerenciaCombo;
                }
                else if (request.cargoDto.IdGerenciaCombo > 0 && request.cargoDto.IdAreaCombo > 0 && request.cargoDto.IdSubAreaCombo == 0)
                {
                    entity.IdArea = request.cargoDto.IdAreaCombo;
                }
                else if (request.cargoDto.IdGerenciaCombo > 0 && request.cargoDto.IdAreaCombo > 0 && request.cargoDto.IdSubAreaCombo > 0)
                {
                    entity.IdArea = request.cargoDto.IdSubAreaCombo;
                }else
                {
                    entity.IdArea = 0;
                }

                entity.DateRegister = DateTime.Now;
                entity.DateUpdate = DateTime.Now;
                await baseRepository.Add(entity);
                output.LastId = entity.Id;
                output.StateCode = 1;
                output.Data = entity;

            }
            else
            {
                output.StateCode = 2;
                output.MessageError.Add("Ya existe un cargo con el mismo nombre");
            }

            
            return output;
        }
    }
}
