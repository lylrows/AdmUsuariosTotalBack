using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.Job.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.Postulant.Queries
{
    public class GetListKeyWordJobQuery : IRequest<Result>
    {
        public int idJob { get; set; }
        public class GetListKeyWordJobQueryHandler : IRequestHandler<GetListKeyWordJobQuery, Result>
        {
            private readonly IJobKeyWordRepository jobKeyWordRepository;
            public GetListKeyWordJobQueryHandler(IJobKeyWordRepository jobKeyWordRepository)
            {
                this.jobKeyWordRepository = jobKeyWordRepository;
            }

            public async Task<Result> Handle(GetListKeyWordJobQuery request, CancellationToken cancellationToken)
            {
                var listJobKeyWords = await jobKeyWordRepository.GetKeyWordList(request.idJob);
                return new Result
                {
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                    Data = listJobKeyWords
                };
            }
        }
    }
}
