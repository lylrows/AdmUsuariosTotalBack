using AutoMapper;
using HumanManagement.Application.Response;
using HumanManagement.Domain.BaseDto;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.HMExactus.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.HMExactus.Queries
{
    

    public class GetHMExactusPayrollQuery : IRequest<Result>
    {

        public class GetHMExactusPayrollQueryHandler : IRequestHandler<GetHMExactusPayrollQuery, Result>
        {

            private readonly IBaseRepository<HMExactusPayroll> baseRepository;
            private IMapper mapper;

            public GetHMExactusPayrollQueryHandler(IBaseRepository<HMExactusPayroll> baseRepository, IMapper mapper)
            {
                this.baseRepository = baseRepository;
                this.mapper = mapper;

            }

            public async Task<Result> Handle(GetHMExactusPayrollQuery request, CancellationToken cancellationToken)
            {

                List<DropDownListDto<string>> listreturn = new List<DropDownListDto<string>>();

                var listEntity = baseRepository.GetAll().Result;

                foreach (var item in listEntity)
                {
                    DropDownListDto<string> dto = new DropDownListDto<string>();
                    dto.Code = item.Code;
                    dto.Description = item.Description;
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
