using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.Utils.Constracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.EvaluationPostulantsInternal.Queries
{
    public class PortulantFileDeleteQuery : IRequest<Result>
    {
        public int nidinformationfile { get; set; }
        public class PortulantFileDeleteQueryHandle : IRequestHandler<PortulantFileDeleteQuery, Result>
        {
            private readonly IUtilRepository _utilRepository;
            public PortulantFileDeleteQueryHandle(IUtilRepository utilRepository)
            {
                _utilRepository = utilRepository;
            }
            public async Task<Result> Handle(PortulantFileDeleteQuery request, CancellationToken cancellationToken)
            {
                var dto = await _utilRepository.InformationFilesDelete(request.nidinformationfile);
                return new Result
                {
                    Data = dto,
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK
                };
            }
        }
    }
}
