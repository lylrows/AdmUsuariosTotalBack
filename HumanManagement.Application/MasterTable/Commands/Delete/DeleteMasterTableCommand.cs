using AutoMapper;
using HumanManagement.Application.Response;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.MasterTable.Commands.Delete
{
    public class DeleteMasterTableCommand : IRequest<Result>
    {
        public int Id { get; set; }
    }
    public class DeleteMasterTableCommandHandler : IRequestHandler<DeleteMasterTableCommand, Result>
    {
        private readonly IBaseRepository<Domain.MasterTable.Models.MasterTable> baseRepository;
        private IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public DeleteMasterTableCommandHandler(IBaseRepository<Domain.MasterTable.Models.MasterTable> baseRepository,
                                    IMapper mapper,
                                    IUnitOfWork unitOfWork)
        {
            this.baseRepository = baseRepository;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(DeleteMasterTableCommand request, CancellationToken cancellationToken)
        {
            var output = new Result();
            var entity = await baseRepository.Find(request.Id);
            if (entity != null)
            {
                entity.Active = false;
                await baseRepository.Delete(entity);
                output.StateCode = 1;
            }

            return output;
        }
    }
}
