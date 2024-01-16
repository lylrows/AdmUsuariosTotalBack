using HumanManagement.Application.Response;
using HumanManagement.Domain.Cargo.Contracts;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.Cargo.Queries
{
    public class GetCompetenciaByCargo : IRequest<Result>
    {
        public int IdCharge { get; set; }
        public int IdRequest { get; set; }
        public int PrimeraCarga { get; set; }
        public class GetCompetenciaByCargoQueryHandler : IRequestHandler<GetCompetenciaByCargo, Result>
        {
            private readonly ICargoRepository cargoRepository;

            public GetCompetenciaByCargoQueryHandler(ICargoRepository cargoRepository)
            {
                this.cargoRepository = cargoRepository;
            }
            public async Task<Result> Handle(GetCompetenciaByCargo request, CancellationToken cancellationToken)
            {
                var output = new Result();
                var dto = await cargoRepository.GetListCompetenciasByCargo(request.IdRequest, request.IdCharge, request.PrimeraCarga);
                
                output.Data = dto;
                output.StateCode = 1;
                return output;
            }
        }
    }
}
