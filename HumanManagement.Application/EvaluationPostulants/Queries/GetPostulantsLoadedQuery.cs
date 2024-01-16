using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.Job.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.EvaluationPostulants.Queries
{
    public class GetPostulantsLoadedQuery: IRequest<Result>
    {
        public int Job { get; set; }

        public class GetPostulantsLoadedQueryHandle : IRequestHandler<GetPostulantsLoadedQuery, Result>
        {
            private readonly IJobPostulantRepository jobRepository;
            public GetPostulantsLoadedQueryHandle(IJobPostulantRepository jobRepository)
            {
                this.jobRepository = jobRepository;
            }
            public async Task<Result> Handle(GetPostulantsLoadedQuery request, CancellationToken cancellationToken)
            {
                var dto = await jobRepository.GetPostulantLoad(request.Job);

                return new Result
                {
                    Data = dto,
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK
                };
            }
        }
    }
}
