using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.Job.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.PostJobOffer.Queries
{
    public class GetJobInternalByIdQuery: IRequest<Result>
    {
        public int IdRequest { get; set; }

        public class GetJobInternalByIdQueryHandle : IRequestHandler<GetJobInternalByIdQuery, Result>
        {
            private readonly IJobRepository jobRepository;
            private readonly IJobPregradoInternaRepository jobPregradoInternaRepository;
            private readonly IJobPostgradoInternaRepository jobPostgradoInternaRepository;
            public GetJobInternalByIdQueryHandle(IJobRepository jobRepository
                                                ,IJobPregradoInternaRepository jobPregradoInternaRepository,
                                                IJobPostgradoInternaRepository jobPostgradoInternaRepository)
            {
                this.jobRepository = jobRepository;
                this.jobPregradoInternaRepository = jobPregradoInternaRepository;
                this.jobPostgradoInternaRepository = jobPostgradoInternaRepository;
            }
            public async Task<Result> Handle(GetJobInternalByIdQuery request, CancellationToken cancellationToken)
            {
                var job = await jobRepository.GetJobInternByIdRequest(request.IdRequest);
                if (job != null)
                {
                    job.JobPregradoList = await jobPregradoInternaRepository.GetPregradoList(job.Id_Job);
                    job.JobPostgradoList = await jobPostgradoInternaRepository.GetPostgradoList(job.Id_Job);
                }

                return new Result
                {
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                    Data = job
                };
            }
        }
    }
}
