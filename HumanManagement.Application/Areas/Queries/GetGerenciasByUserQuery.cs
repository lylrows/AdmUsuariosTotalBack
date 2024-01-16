using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.Areas.Contracts;
using HumanManagement.Domain.Areas.QueryFilter;
using MediatR;

using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.Areas.Queries
{
    public class GetGerenciasByUserQuery : IRequest<Result>
    {
        
        public AreasComboQueryFilter areasComboQueryFilter { get; set; }

        public class GetAreaByCompanyQueryHandler : IRequestHandler<GetGerenciasByUserQuery, Result>
        {
            private readonly IAreaRepository areaRepository;

            public GetAreaByCompanyQueryHandler(IAreaRepository areaRepository)
            {
                this.areaRepository = areaRepository;
            }
            public async Task<Result> Handle(GetGerenciasByUserQuery request, CancellationToken cancellationToken)
            {

                var result = await areaRepository.GetGerenciasByUser(request.areasComboQueryFilter);


                return new Result
                {
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                    Data = result
                };
            }
        }
    }
}
