using AutoMapper;
using HumanManagement.Application.Response;
using HumanManagement.Domain.Areas.Dto;
using HumanManagement.Domain.BaseRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.Areas.Commands.Edit
{
    public class EditAreaCommand : IRequest<Result>
    {
        public AreasDto areasDto { get; set; }
    }

    public class EditAreaCommandHandler : IRequestHandler<EditAreaCommand, Result>
    {

        private readonly IBaseRepository<Domain.Areas.Models.Areas> baseRepository;
        private IMapper mapper;

        public EditAreaCommandHandler(IBaseRepository<Domain.Areas.Models.Areas> baseRepository,
                                       IMapper mapper)
        {
            this.baseRepository = baseRepository;
            this.mapper = mapper;
        }

        public async Task<Result> Handle(EditAreaCommand request, CancellationToken cancellationToken)
        {
            var output = new Result();

            var actual = await baseRepository.Find(request.areasDto.Id);
            if (actual.Active == true && request.areasDto.Active ==false)
            {
                var all = await baseRepository.GetAll();
                var espadre = all.Where(x => x.IdUpperArea == request.areasDto.Id).ToList();
                if (espadre == null || espadre.Count == 0)
                {
                    var entity = mapper.Map<Domain.Areas.Models.Areas>(request.areasDto);
                    entity.DateRegister = DateTime.Now;
                    entity.DateUpdate = DateTime.Now;
                    await baseRepository.Update(entity);
                    output.StateCode = 1;
                    output.Data = entity;
                    return output;
                } else
                {
                    output.MessageError.Add("El area requerida a eliminar es padre de otras areas");
                    output.StateCode = 2;
                    return output;
                }
            } else
            {
                var entity = mapper.Map<Domain.Areas.Models.Areas>(request.areasDto);
                entity.DateRegister = DateTime.Now;
                entity.DateUpdate = DateTime.Now;
                await baseRepository.Update(entity);
                output.StateCode = 1;
                output.Data = entity;
                return output;
            }

        }
    }
}
