using HumanManagement.Domain.Postulant.Area.Contracts;
using HumanManagement.Domain.Postulant.Area.Dto;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.Recruitment.Queries
{
    public class RecruitmentAreaGetForSelectQuery: IRequest<List<AreaForSelectDto>>
    {
        public class RecruitmentAreaGetForSelectQueryHandler : IRequestHandler<RecruitmentAreaGetForSelectQuery, List<AreaForSelectDto>>
        {
            private readonly IRecruitmentAreaRepository recruitmentAreaRepository;
            public RecruitmentAreaGetForSelectQueryHandler(IRecruitmentAreaRepository recruitmentAreaRepository)
            {
                this.recruitmentAreaRepository = recruitmentAreaRepository;
            }
            public async Task<List<AreaForSelectDto>> Handle(RecruitmentAreaGetForSelectQuery request, CancellationToken cancellationToken)
            {
                return await recruitmentAreaRepository.GetForSelect();
            }
        }
    }
}
