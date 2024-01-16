using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.Areas.Contracts;
using HumanManagement.Domain.Areas.QueryFilter;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.Areas.Queries
{

    public class GetGerenciasByCompanyQuery : IRequest<Result>
    {
        public GerenciasComboQueryFilter gerenciasComboQueryFilter { get; set; }

        public class GetGerenciasByCompanyQueryHandler : IRequestHandler<GetGerenciasByCompanyQuery, Result>
        {
            private readonly IAreaRepository areaRepository;

            public GetGerenciasByCompanyQueryHandler(IAreaRepository areaRepository)
            {
                this.areaRepository = areaRepository;
            }
            public async Task<Result> Handle(GetGerenciasByCompanyQuery request, CancellationToken cancellationToken)
            {

                var result = await areaRepository.GetGerenciasByCompany(request.gerenciasComboQueryFilter);


                return new Result
                {
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                    Data = result
                };
            }
        }
    }
}
