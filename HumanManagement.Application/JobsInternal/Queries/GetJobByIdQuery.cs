using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.Job.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.JobsInternal.Queries
{
    public class GetJobByIdQuery: IRequest<Result>
    {
        public int IdJob { get; set; }

        public class GetJobByIdQueryHandle : IRequestHandler<GetJobByIdQuery, Result>
        {
            private readonly IJobInternalRepository jobInternalRepository;
            public GetJobByIdQueryHandle(IJobInternalRepository jobInternalRepository)
            {
                this.jobInternalRepository = jobInternalRepository;
            }
            public async Task<Result> Handle(GetJobByIdQuery request, CancellationToken cancellationToken)
            {
                var dto = await jobInternalRepository.GetById(request.IdJob);

                return new Result
                {
                    Data = dto,
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK
                };
            }
        }
    }
}
