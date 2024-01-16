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
    public class DeleteRecognitionQuery : IRequest<Result>
    {
        public int Id { get; set; }
        public class DeleteRecognitionQueryHandler : IRequestHandler<DeleteRecognitionQuery, Result>
        {
            private readonly IRecognitionRepository _recognitionRepository;
            public DeleteRecognitionQueryHandler(IRecognitionRepository recognitionRepository)
            {
                this._recognitionRepository = recognitionRepository;
            }

            public async Task<Result> Handle(DeleteRecognitionQuery query, CancellationToken cancellationToken)
            {
                await _recognitionRepository.DeleteStateRecognition(query.Id);
                return new Result
                {
                    StateCode = 200,
                    Data = "Se cambio a estado inactivo este reconocimiento"
                };
            }
        }
    }
}
