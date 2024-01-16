using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.Contracts;
using HumanManagement.Domain.Job.Contracts;
using HumanManagement.Domain.Utils.Dto;
using MediatR;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.PostJobOffer.Queries
{
    public class GetJobByIdQuery : IRequest<Result>
    {
        public int IdRequest { get; set; }
        public class GetJobByIdQueryHandler : IRequestHandler<GetJobByIdQuery, Result>
        {
            private readonly IJobRepository jobRepository;
            private readonly IJobIdiomRepository jobIdiomRepository;
            private readonly IJobKeyWordRepository jobKeyWordRepository;
            private readonly IJobPregradoRepository jobPregradoRepository;
            private readonly IJobPostgradoRepository jobPostgradoRepository;
            public GetJobByIdQueryHandler(IJobRepository jobRepository,
                                          IJobIdiomRepository jobIdiomRepository,
                                          IJobKeyWordRepository jobKeyWordRepository
                                          ,IJobPregradoRepository jobPregradoRepository,
                                          IJobPostgradoRepository jobPostgradoRepository
                                          )
            {
                this.jobRepository = jobRepository;
                this.jobIdiomRepository = jobIdiomRepository;
                this.jobKeyWordRepository = jobKeyWordRepository;
                this.jobPregradoRepository = jobPregradoRepository;
                this.jobPostgradoRepository = jobPostgradoRepository;
            }
            public async Task<Result> Handle(GetJobByIdQuery request, CancellationToken cancellationToken)
            {
                var job = await jobRepository.GetByIdRequest(request.IdRequest);
                if (job != null)
                {
                    job.JobIdiomList = await jobIdiomRepository.GetIdiomList(job.Id_Job);
                    job.JobKeyWordList = await jobKeyWordRepository.GetKeyWordList(job.Id_Job);
                    job.JobPregradoList = await jobPregradoRepository.GetPregradoList(job.Id_Job);
                    job.JobPostgradoList = await jobPostgradoRepository.GetPostgradoList(job.Id_Job);
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
