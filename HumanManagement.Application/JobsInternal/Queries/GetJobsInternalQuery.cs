using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.Job.Contracts;
using HumanManagement.Domain.Job.QueryFilter;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.JobsInternal.Queries
{
    public class GetJobsInternalQuery: IRequest<Result>
    {
        public JobInternalQueryFilter filter { get; set; }
        public class GetJobsInternalQueryHandle : IRequestHandler<GetJobsInternalQuery, Result>
        {
            private readonly IJobInternalRepository jobInternalRepository;
            public GetJobsInternalQueryHandle(IJobInternalRepository jobInternalRepository)
            {
                this.jobInternalRepository = jobInternalRepository;
            }
            public async Task<Result> Handle(GetJobsInternalQuery request, CancellationToken cancellationToken)
            {
                var dto = await jobInternalRepository.GetAllJobsInternal(request.filter);
                return new Result
                {
                    Data = dto,
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK
                };
            }
        }
    }
}
