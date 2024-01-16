using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.SalaryBand.Contracts;
using HumanManagement.Domain.SalaryBand.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.SalaryBand.Queries
{
    public class GetSalaryStructureQuery : IRequest<Result>
    {
        public SalaryStructureFilter filter { get; set; }
        public class GetSalaryStructureQueryHandler : IRequestHandler<GetSalaryStructureQuery, Result>
        {
            private readonly IEconomicConditionRepository economicConditionRepository;
            public GetSalaryStructureQueryHandler(IEconomicConditionRepository economicConditionRepository)
            {
                this.economicConditionRepository = economicConditionRepository;
            }
            public async Task<Result> Handle(GetSalaryStructureQuery query, CancellationToken cancellationToken)
            {
                var resultPagination = await economicConditionRepository.GetSalaryStructure(query.filter);
                return new Result
                {
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                    Data = resultPagination
                };
            }
        }
    }
}
