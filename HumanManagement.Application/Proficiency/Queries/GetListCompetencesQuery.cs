using AutoMapper;
using HumanManagement.Application.Response;
using HumanManagement.Domain.BaseDto;
using HumanManagement.Domain.BaseRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.Proficiency.Queries
{
  public  class GetListCompetencesQuery : IRequest<Result>
    {
        public class GetListCompetencesQueryHandler : IRequestHandler<GetListCompetencesQuery, Result>
        {


            private readonly IBaseRepository<Domain.Proficiency.Models.Proficiency> baseRepository;
            private IMapper mapper;

            public GetListCompetencesQueryHandler(IBaseRepository<Domain.Proficiency.Models.Proficiency> baseRepository, IMapper mapper)
            {
                this.baseRepository = baseRepository;
                this.mapper = mapper;

            }

            public async Task<Result> Handle(GetListCompetencesQuery request, CancellationToken cancellationToken)
            {

                List<ListCompetencesDto<int>> listreturn = new List<ListCompetencesDto<int>>();

                var listEntity = await baseRepository.GetAll();

                foreach (var item in listEntity.Where(i => i.Active))
                {
                    ListCompetencesDto<int> dto = new ListCompetencesDto<int>();
                    dto.IdCompetence = item.IdProficiency;
                    dto.NameCompetence = item.NameProficiency;
                    dto.DescriptionCompetence = item.Description;
                    dto.DescriptionLevel1 = item.Level1;
                    dto.DescriptionLevel2 = item.Level2;
                    dto.DescriptionLevel3 = item.Level3;
                    dto.DescriptionLevel4 = item.Level4;
                    dto.NidSelected = 0;
                    dto.IdLevel = 0;
                    dto.IsExpanded = false;
                    dto.IconCompetence = item.IconProficiency;
                    dto.IsConfigured =false;


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
