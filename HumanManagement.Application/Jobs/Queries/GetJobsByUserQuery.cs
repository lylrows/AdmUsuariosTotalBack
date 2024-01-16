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
using System.Linq;

namespace HumanManagement.Application.Jobs.Queries
{
    public class GetJobsByUserQuery : IRequest<Result>
    {
        public JobQueryFilter filter { get; set; }

        public class GetJobsByUserQueryHandler : IRequestHandler<GetJobsByUserQuery, Result>
        {
            private readonly IJobRepository jobRepository;

            public GetJobsByUserQueryHandler(IJobRepository jobRepository)
            {
                this.jobRepository = jobRepository;
            }
            public async Task<Result> Handle(GetJobsByUserQuery request, CancellationToken cancellationToken)
            {
                var data = await jobRepository.GetJobsByUser(request.filter);
                data.TotalItems = data.list.Count();
                data.TotalPages = (int)Math.Ceiling((double)data.TotalItems / request.filter.pagination.ItemsPerPage);
                if (!string.IsNullOrEmpty(request.filter.Type))
                {
                    data.list = data.list.Where(x => x.Type == request.filter.Type).ToList();
                }
                data.list = data.list.Skip((request.filter.pagination.CurrentPage - 1) * request.filter.pagination.ItemsPerPage).Take(request.filter.pagination.ItemsPerPage).ToList();
                return new Result
                {
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK,
                    Data = data
                };
            }
        }
    }
}
