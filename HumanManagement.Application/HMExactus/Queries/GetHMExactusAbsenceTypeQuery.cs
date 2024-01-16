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

    public class GetHMExactusAbsenceTypeQuery : IRequest<Result>
    {

        public class GetHMExactusAbsenceTypeQueryHandler : IRequestHandler<GetHMExactusAbsenceTypeQuery, Result>
        {

            private readonly IBaseRepository<HMExactusAbsenceType> baseRepository;
            private IMapper mapper;

            public GetHMExactusAbsenceTypeQueryHandler(IBaseRepository<HMExactusAbsenceType> baseRepository, IMapper mapper)
            {
                this.baseRepository = baseRepository;
                this.mapper = mapper;

            }

            public async Task<Result> Handle(GetHMExactusAbsenceTypeQuery request, CancellationToken cancellationToken)
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
