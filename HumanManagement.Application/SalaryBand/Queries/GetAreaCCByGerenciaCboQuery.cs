using HumanManagement.Application.Response;
using HumanManagement.Domain.SalaryBand.Contracts;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.SalaryBand.Queries
{
    public class GetAreaCCByGerenciaCboQuery : IRequest<Result>
    {
        public int nid_gerencia { get; set; }

        public class GetAreaCCByGerenciaCboQueryHandler : IRequestHandler<GetAreaCCByGerenciaCboQuery, Result>
        {

            private readonly ISalaryBandRepository _salarybandRepository;
            public GetAreaCCByGerenciaCboQueryHandler(ISalaryBandRepository _salarybandRepository)
            {
                this._salarybandRepository = _salarybandRepository;
            }
            public async Task<Result> Handle(GetAreaCCByGerenciaCboQuery query, CancellationToken cancellationToken)
            {
                var listEntity = await _salarybandRepository.GetListAreaCCByGerencia(query.nid_gerencia);

                return new Result
                {
                    StateCode = 200,
                    Data = listEntity
                };

            }
        }
    }
}
