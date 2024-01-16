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
    
    public class GetEcoConditionExportXLSQuery : IRequest<Result>
    {
        public EcoConditionFilter ecoQueryFilter { get; set; }
        public class GetEcoConditionExportXLSQueryHandler : IRequestHandler<GetEcoConditionExportXLSQuery, Result>
        {
            private readonly ISalaryBandRepository _salarybandRepository;
            public GetEcoConditionExportXLSQueryHandler(ISalaryBandRepository salarybandRepository)
            {
                this._salarybandRepository = salarybandRepository;
            }
            public async Task<Result> Handle(GetEcoConditionExportXLSQuery query, CancellationToken cancellationToken)
            {
                var resultPagination = await _salarybandRepository.GetEcoConditionList(query.ecoQueryFilter);

                foreach (var item in resultPagination)
                {
                    item.Increase_ant = item.Increase;
                    item.IncreasePassive_ant = item.IncreasePassive;
                    item.Presupuestado = item.IdEconomicCondition > 0 ? "SI" : "NO";
                }

              

                return new Result
                {
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                    Data = resultPagination
                };
            }
        }
    }
}
