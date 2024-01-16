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
    public class GetInformationSkillsPostulantQuery: IRequest<Result>
    {
        public int IdPerson { get; set; }
        public class GetInformationSkillsPostulantQueryHandle : IRequestHandler<GetInformationSkillsPostulantQuery, Result>
        {
            private readonly IBaseRepository<InformationComputerSkillsModel> baseRepositorySkills;
            private readonly IMapper mapper;
            public GetInformationSkillsPostulantQueryHandle(IBaseRepository<InformationComputerSkillsModel> baseRepositorySkills, IMapper mapper)
            {
                this.baseRepositorySkills = baseRepositorySkills;
                this.mapper = mapper;
            }
            public async Task<Result> Handle(GetInformationSkillsPostulantQuery request, CancellationToken cancellationToken)
            {
                var entitySkills = await baseRepositorySkills.FindAllPredicate(x => x.IdPostulant == request.IdPerson);
                var dto = mapper.Map<List<InformationComputerSkillsDto>>(entitySkills);

                return new Result
                {
                    Data = dto,
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK
                };
            }
        }
    }
}
