using AutoMapper;
using HumanManagement.Application.Response;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.MasterTable.Dto;
using HumanManagement.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.MasterTable.Commands.Create
{
    public class CreateMasterTableCommand : IRequest<Result>
    {
        public MasterTableDto masterTableDto { get; set; }
    }
    public class CreateMasterTableCommandHandler : IRequestHandler<CreateMasterTableCommand, Result>
    {
        private readonly IBaseRepository<Domain.MasterTable.Models.MasterTable> baseRepository;
        private IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public CreateMasterTableCommandHandler(IBaseRepository<Domain.MasterTable.Models.MasterTable> baseRepository,
                                     IMapper mapper,
                                     IUnitOfWork unitOfWork)
        {
            this.baseRepository = baseRepository;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }
        public async Task<Result> Handle(CreateMasterTableCommand request, CancellationToken cancellationToken)
        {
            var output = new Result();
            var masterTable = await baseRepository.GetAll();
            var masterTableExist = masterTable.Where(x => x.IdFather == request.masterTableDto.IdFather && x.DescriptionValue == request.masterTableDto.DescriptionValue).ToList();
            if (masterTableExist.Count == 0)
            {
                var entity = mapper.Map<Domain.MasterTable.Models.MasterTable>(request.masterTableDto);
                entity.DateRegister = DateTime.Now;
                entity.DateUpdate = DateTime.Now;
                await baseRepository.Add(entity);
                output.StateCode = 1;
                output.Data = entity;

            }
            else
            {
                output.StateCode = 2;
                output.MessageError.Add("Ya existe un registro con el mismo nombre");
            }


            return output;
        }
    }
}
