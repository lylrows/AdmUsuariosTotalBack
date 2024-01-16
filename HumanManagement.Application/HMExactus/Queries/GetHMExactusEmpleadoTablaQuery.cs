using HumanManagement.Application.Response;
using HumanManagement.Domain.BaseDto;
using HumanManagement.Domain.WindowsService.Exactus.Contracts;
using HumanManagement.Domain.WindowsService.Exactus.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.HMExactus.Queries
{
    public class GetHMExactusEmpleadoTablaQuery : IRequest<Result>
    {
        public ExactusEmpleadoTablaFilterDto filterDto { get; set; }


        public class GetHMExactusEmpleadoTablaQueryHandler : IRequestHandler<GetHMExactusEmpleadoTablaQuery, Result>
        {
            private readonly IExactusEmpleadoRepository exactusEmpleadoRepository;
            

            public GetHMExactusEmpleadoTablaQueryHandler(IExactusEmpleadoRepository exactusEmpleadoRepository)
            {
                this.exactusEmpleadoRepository = exactusEmpleadoRepository;
            }

            public async Task<Result> Handle(GetHMExactusEmpleadoTablaQuery request, CancellationToken cancellationToken)
            {

                List<DropDownListDto<string>> listreturn = new List<DropDownListDto<string>>();

                var listEntity = await exactusEmpleadoRepository.GetEmpleadoTabla(request.filterDto);

                foreach (var item in listEntity)
                {
                    DropDownListDto<string> dto = new DropDownListDto<string>();
                    dto.Code = item.codigo;
                    dto.Description = item.descripcion;
                    listreturn.Add(dto);
                }

                return new Result
                {
                    StateCode = 200,
                    Data = listreturn
                };
            }
        }
    }
}
