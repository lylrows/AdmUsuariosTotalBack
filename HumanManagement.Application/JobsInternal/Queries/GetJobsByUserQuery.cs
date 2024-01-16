using HumanManagement.Application.Helpers;
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
    public class GetJobsByUserQuery: IRequest<Result>
    {
        public JobQueryFilter filter { get; set; }
        public class GetJobsByUserQueryHandle : IRequestHandler<GetJobsByUserQuery, Result>
        {
            private readonly IJobInternalRepository jobInternalRepository;
            private readonly SessionManager sessionManager;

            public GetJobsByUserQueryHandle(IJobInternalRepository jobInternalRepository, SessionManager sessionManager)
            {
                this.jobInternalRepository = jobInternalRepository;
                this.sessionManager = sessionManager;
            }
            public async Task<Result> Handle(GetJobsByUserQuery request, CancellationToken cancellationToken)
            {
                var dto = await jobInternalRepository.GetJobsByUser(request.filter);

                return new Result
                {
                    Data = dto,
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK
                };
            }
        }
    }
}
