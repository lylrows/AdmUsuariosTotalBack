using AutoMapper;
using HumanManagement.Application.Response;
using HumanManagement.CrossCutting.Utils;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.RecruitmentArea.Dto;
using HumanManagement.Domain.RecruitmentArea.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.JobsInternal.Queries
{
    public class GetJobsAreaQuery: IRequest<Result>
    {
        public class GetJobsAreaQueryHandle : IRequestHandler<GetJobsAreaQuery, Result>
        {
            private readonly IBaseRepository<RecruitmentArea> baseRepository;
            private readonly IMapper mapper;
            public GetJobsAreaQueryHandle(IBaseRepository<RecruitmentArea> baseRepository, IMapper mapper)
            {
                this.baseRepository = baseRepository;
                this.mapper = mapper;
            }
            public async Task<Result> Handle(GetJobsAreaQuery request, CancellationToken cancellationToken)
            {
                var entity = await baseRepository.GetAll();
                var dtos = mapper.Map<List<RecruitmentAreaDto>>(entity);

                return new Result
                {
                    Data = dtos,
                    StateCode = Constants.StateCodeResult.STATE_CODE_OK
                };
            }
        }
    }
}
