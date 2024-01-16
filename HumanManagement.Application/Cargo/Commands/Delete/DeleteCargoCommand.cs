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

namespace HumanManagement.Application.Cargo.Commands.Delete
{
    public class DeleteCargoCommand : IRequest<Result>
    {
        public int Id { get; set; }
    }

    public class DeleteCargoCommandHandler : IRequestHandler<DeleteCargoCommand, Result>
    {
        private readonly IBaseRepository<Domain.Cargo.Models.Cargo> baseRepository;
        private IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public DeleteCargoCommandHandler(IBaseRepository<Domain.Cargo.Models.Cargo> baseRepository,
                                    IMapper mapper,
                                    IUnitOfWork unitOfWork)
        {
            this.baseRepository = baseRepository;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(DeleteCargoCommand request, CancellationToken cancellationToken)
        {
            var output = new Result();
            var entity = await baseRepository.Find(request.Id);
            if (entity != null)
            {
                entity.Active = false;
                await baseRepository.Update(entity);
                output.StateCode = 1;
            }

            return output;
        }
    }
}
