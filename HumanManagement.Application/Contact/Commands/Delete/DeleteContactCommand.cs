using AutoMapper;
using HumanManagement.Application.Response;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.Contact.Commands.Delete
{

    public class DeleteContactCommand : IRequest<Result>
    {
        public int Id { get; set; }
    }

    public class DeleteContactCommandHandler : IRequestHandler<DeleteContactCommand, Result>
    {
        private readonly IBaseRepository<Domain.Contact.Models.Contact> baseRepository;
        private IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public DeleteContactCommandHandler(IBaseRepository<Domain.Contact.Models.Contact> baseRepository,
                                    IMapper mapper,
                                    IUnitOfWork unitOfWork)
        {
            this.baseRepository = baseRepository;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
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
