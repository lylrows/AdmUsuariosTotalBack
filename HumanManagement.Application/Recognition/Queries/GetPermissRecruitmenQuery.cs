using HumanManagement.Application.Helpers;
using HumanManagement.Application.Response;
using HumanManagement.Domain.Recognition.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.Recognition.Queries
{
    public class GetPermissRecruitmenQuery : IRequest<Result>
    {
        public int IdOrigin { get; set; }
        public int IdNivel { get; set; }
        public class GetPermissRecruitmenQueryHandler : IRequestHandler<GetPermissRecruitmenQuery, Result>
        {
            private readonly IRecognitionRepository _recognitionRepository;
            private readonly SessionManager _sessionManager;
            public GetPermissRecruitmenQueryHandler(IRecognitionRepository recognitionRepository, SessionManager sessionManager)
            {
                this._recognitionRepository = recognitionRepository;
                this._sessionManager = sessionManager;
            }

            public async Task<Result> Handle(GetPermissRecruitmenQuery query, CancellationToken cancellationToken)
            {
                var list = await _recognitionRepository.GetFlowConfiguration(query.IdOrigin, query.IdNivel);
                return new Result
                {
                    StateCode = 200,
                    Data = list
                };
            }
        }
    }
}
