using HumanManagement.Application.Response;
using HumanManagement.Domain.Organigram.Contracts;

using MediatR;
using Microsoft.Extensions.Logging;

using System.Diagnostics;

using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.Organigram.Queries
{
  
    public class GetOrganigramV2Query : IRequest<Result>
    {
        public int IdEmpresa { get; set; }
        public class GetOrganigramV2QueryHandler : IRequestHandler<GetOrganigramV2Query, Result>
        {
            private readonly IOrganigramRepository organigramRepository;
            private readonly ILogger<GetOrganigramV2QueryHandler> _logger;
            public GetOrganigramV2QueryHandler(IOrganigramRepository organigramRepository, ILogger<GetOrganigramV2QueryHandler> _logger)
            {
                this.organigramRepository = organigramRepository;
                this._logger = _logger;
            }
            public async Task<Result> Handle(GetOrganigramV2Query request, CancellationToken cancellationToken)
            {
                Stopwatch timeMeasure = new Stopwatch();
                timeMeasure.Start();
                

                var data = await organigramRepository.GetOrganigramV2(request.IdEmpresa);
                foreach (var item in data)
                {
                    item.tags = item.stags.Split(',');
                    //if (!System.IO.File.Exists(item.img))
                    //{
                    //    item.img = "../../../../../assets/images/avatars/avatar.jpg";
                    //}
                }

                timeMeasure.Stop();
                _logger.LogInformation($"Tiempo Organigrama Principal: {timeMeasure.Elapsed.TotalSeconds} s");
                
                return new Result
                {
                    StateCode = 200,
                    Data = data
                };
            }

         
        }
    }
}
