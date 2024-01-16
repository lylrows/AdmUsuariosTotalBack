using AutoMapper;
using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.InformationPostulant.Dto;
using HumanManagement.Domain.InformationPostulant.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.InformationPostulant.Queries
{
    public class GetInformationLangPostulantQuery: IRequest<Result>
    {
        public int IdPerson { get; set; }
        public class GetInformationLangPostulantQueryHandle : IRequestHandler<GetInformationLangPostulantQuery, Result>
        {
            private readonly IBaseRepository<InformationLangModel> baseRepositoryLang;
            private readonly IMapper mapper;
            public GetInformationLangPostulantQueryHandle(IBaseRepository<InformationLangModel> baseRepositoryLang, IMapper mapper)
            {
                this.baseRepositoryLang = baseRepositoryLang;
                this.mapper = mapper;
            }
            public async Task<Result> Handle(GetInformationLangPostulantQuery request, CancellationToken cancellationToken)
            {
                var entityLang = await baseRepositoryLang.FindAllPredicate(x => x.IdPostulant == request.IdPerson);
                var dto = mapper.Map<List<InformationLangDto>>(entityLang);

                return new Result
                {
                    Data = dto,
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK
                };
            }
        }
    }
}
