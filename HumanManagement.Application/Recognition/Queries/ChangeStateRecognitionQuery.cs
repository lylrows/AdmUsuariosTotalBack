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
    public class ChangeStateRecognitionQuery : IRequest<Result>
    {
        public int Id { get; set; }
        public class ChangeStateRecognitionQueryHandler : IRequestHandler<ChangeStateRecognitionQuery, Result>
        {
            private readonly IRecognitionRepository _recognitionRepository;
            public ChangeStateRecognitionQueryHandler(IRecognitionRepository recognitionRepository)
            {
                this._recognitionRepository = recognitionRepository;
            }

            public async Task<Result> Handle(ChangeStateRecognitionQuery query, CancellationToken cancellationToken)
            {
                await _recognitionRepository.ChangeStateRecognition(query.Id);
                return new Result
                {
                    StateCode = 200,
                    Data = "Cambio a estado Leido el reconocimiento"
                };
            }
        }
    }
}
