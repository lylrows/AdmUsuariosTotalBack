using HumanManagement.Application.Response;
using HumanManagement.Domain.Recognition.Contracts;
using HumanManagement.Domain.Recruitment.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.Recognition.Queries
{
    public class RecognitionByIdQuery : IRequest<Result>
    {
        public int Id { get; set; }
        public class RecognitionByIdQueryHandler : IRequestHandler<RecognitionByIdQuery, Result>
        {
            private readonly IRequestRepository _requestRepository;
            public RecognitionByIdQueryHandler(IRequestRepository requestRepository)
            {
                this._requestRepository = requestRepository;
            }

            public async Task<Result> Handle(RecognitionByIdQuery query, CancellationToken cancellationToken)
            {
                var data = await _requestRepository.GetRequestById(query.Id);
                return new Result
                {
                    StateCode = 200,
                    Data = data
                };
            }
        }
    }
}
