using AutoMapper;
using HumanManagement.Application.Response;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.Cargo.Dto;
using HumanManagement.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.Cargo.Commands.Edit
{
    public class EditCargoCommand : IRequest<Result>
    {
        public CargoDto cargoDto { get; set; }
    }

    public class EditCargoCommandHandler : IRequestHandler<EditCargoCommand, Result>
    {
        private readonly IBaseRepository<Domain.Cargo.Models.Cargo> baseRepository;
        private IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public EditCargoCommandHandler(IBaseRepository<Domain.Cargo.Models.Cargo> baseRepository,
                                    IMapper mapper,
                                    IUnitOfWork unitOfWork)
        {
            this.baseRepository = baseRepository;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }
        public async Task<Result> Handle(EditCargoCommand request, CancellationToken cancellationToken)
        {
            var output = new Result();
            var entity = mapper.Map<Domain.Cargo.Models.Cargo>(request.cargoDto);
            // LOGICA DE SI ES GERENCIA, AREA O SUBAREA
            if (request.cargoDto.IdGerenciaCombo > 0 && request.cargoDto.IdAreaCombo == 0 && request.cargoDto.IdSubAreaCombo == 0)
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
            }
            else
            {
                entity.IdArea = 0;
            }

            //entity.DateRegister = DateTime.Now;
            entity.DateUpdate = DateTime.Now;
            //await baseRepository.Update(entity);
            await baseRepository.UpdatePartial(entity, x => x.IdEmpresa,
                                                        x => x.IdUpperCargo,
                                                        x => x.IdArea,
                                                        x => x.NameCargo,
                                                        x => x.Active,
                                                        x => x.DateUpdate,
                                                        x => x.CodecCharge,
                                                        x => x.IdUserUpdate);
            output.StateCode = 1;
            output.Data = entity;
            return output;
        }
    }

}
