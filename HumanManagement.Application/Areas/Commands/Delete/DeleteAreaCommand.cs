using AutoMapper;
using HumanManagement.Application.Response;
using HumanManagement.Domain.BaseRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.Areas.Commands.Delete
{
    public class DeleteAreaCommand : IRequest<Result>
    {
        public int Id { get; set; }
    }

    public class DeleteAreaCommandHandler : IRequestHandler<DeleteAreaCommand, Result>
    {
        private readonly IBaseRepository<Domain.Areas.Models.Areas> baseRepository;
        private IMapper mapper;

        public DeleteAreaCommandHandler(IBaseRepository<Domain.Areas.Models.Areas> baseRepository,
                                      IMapper mapper)
        {
            this.baseRepository = baseRepository;
            this.mapper = mapper;
        }
        public async Task<Result> Handle(DeleteAreaCommand request, CancellationToken cancellationToken)
        {
            var output = new Result();
            var entity = await baseRepository.Find(request.Id);
            if (entity != null)
            {

                var all = await baseRepository.GetAll();
                var espadre = all.Where(x => x.IdUpperArea == request.Id).ToList();
                if (espadre == null || espadre.Count == 0)
                {
                    entity.Active = false;
                    await baseRepository.Update(entity);
                    output.StateCode = 1;
                    return output;
                }
                else
                {
                    output.MessageError.Add("El área requerida a anular es padre de otras áreas");
                    output.StateCode = 0;
                    return output;
                }
            }

            return output;
        }
    }
}
