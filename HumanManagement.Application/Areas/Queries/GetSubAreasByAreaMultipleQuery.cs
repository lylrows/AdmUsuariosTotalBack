using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.Areas.Contracts;
using HumanManagement.Domain.Areas.QueryFilter;
using MediatR;

using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.Areas.Queries
{
    public class GetSubAreasByAreaMultipleQuery : IRequest<Result>
    {
        public SubAreasComboMultipleQueryFilter subAreasComboQueryFilter { get; set; }

        public class GetAreaByCompanyQueryHandler : IRequestHandler<GetSubAreasByAreaMultipleQuery, Result>
        {
            private readonly IAreaRepository areaRepository;

            public GetAreaByCompanyQueryHandler(IAreaRepository areaRepository)
            {
                this.areaRepository = areaRepository;
            }
            public async Task<Result> Handle(GetSubAreasByAreaMultipleQuery request, CancellationToken cancellationToken)
            {
                var result = await areaRepository.GetSubAreasByAreaMultiple(request.subAreasComboQueryFilter.IdArea);

                return new Result
                {
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                    Data = result
                };
            }
        }
    }
}
