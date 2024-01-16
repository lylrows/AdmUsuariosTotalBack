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
    public class GetListRecognitionQuery : IRequest<Result>
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public class GetListRecognitionQueryHandler : IRequestHandler<GetListRecognitionQuery, Result>
        {
            private readonly IRecognitionRepository _recognitionRepository;
            private readonly SessionManager _sessionManager;
            public GetListRecognitionQueryHandler(IRecognitionRepository recognitionRepository, SessionManager sessionManager)
            {
                this._recognitionRepository = recognitionRepository;
                this._sessionManager = sessionManager;
            }

            public async Task<Result> Handle(GetListRecognitionQuery query, CancellationToken cancellationToken)
            {
                var list = await _recognitionRepository.GetListRecognition(query.Id, _sessionManager.User.IdUser);
                return new Result
                {
                    StateCode = 200,
                    Data = list
                };
            }
        }
    }
}
