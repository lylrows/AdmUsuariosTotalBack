using HumanManagement.Application.Response;
using HumanManagement.Domain.BaseRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.Areas.Commands.Validar
{
    public class ValidarEditCommand : IRequest<Result>
    {
        public int Id { get; set; }
        public bool Active { get; set; }
    }

    public class ValidarEditCommandHandler : IRequestHandler<ValidarEditCommand, Result>
    {
        private readonly IBaseRepository<Domain.Areas.Models.Areas> baseRepository;

        public ValidarEditCommandHandler(IBaseRepository<Domain.Areas.Models.Areas> baseRepository)
        {
            this.baseRepository = baseRepository;
        }
        public async Task<Result> Handle(ValidarEditCommand request, CancellationToken cancellationToken)
        {
            var output = new Result();

            var actual = await baseRepository.Find(request.Id);
            if (actual.Active == true && request.Active == false)
            {
                var all = await baseRepository.GetAll();
                var espadre = all.Where(x => x.IdUpperArea == request.Id).ToList();
                if (espadre == null || espadre.Count == 0)
                {
                    output.StateCode = 1;
                    return output;
                }
                else
                {
                    output.MessageError.Add("El área requerida a anular es padre de otras áreas");
                    output.StateCode = 2;
                    return output;
                }
            }
            else
            {
                output.StateCode = 1;
                return output;
            }
        }
    }
}
