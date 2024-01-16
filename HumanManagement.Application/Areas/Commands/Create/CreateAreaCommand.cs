using AutoMapper;
using HumanManagement.Application.Response;
using HumanManagement.Domain.Areas.Dto;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.Areas.Commands.Create
{
    public class CreateAreaCommand : IRequest<Result>
    {
        public AreasDto areasDto { get; set; }
    }

    public class CreateAreaCommandHandler : IRequestHandler<CreateAreaCommand, Result>
    {
        private readonly IBaseRepository<Domain.Areas.Models.Areas> baseRepository;
        private IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public CreateAreaCommandHandler(IBaseRepository<Domain.Areas.Models.Areas> baseRepository,
                                        IMapper mapper,
                                        IUnitOfWork unitOfWork)
        {
            this.baseRepository = baseRepository;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(CreateAreaCommand request, CancellationToken cancellationToken)
        {
            var output = new Result();
            var areas = await baseRepository.GetAll();
            var areaExist = areas.Where(x => x.IdEmpresa == request.areasDto.IdEmpresa && x.NameArea == request.areasDto.NameArea).ToList();
            if (areaExist.Count == 0)
            {
                var entity = mapper.Map<Domain.Areas.Models.Areas>(request.areasDto);
                entity.DateRegister = DateTime.Now;
                entity.DateUpdate = DateTime.Now;
                await baseRepository.Add(entity);
                output.StateCode = 1;
                output.Data = entity;
            } else
            {
                output.StateCode = 2;
                output.MessageError.Add("Ya existe una área con el mismo nombre");
            }
            return output;
        }
    }
}
