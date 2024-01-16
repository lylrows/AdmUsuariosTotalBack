using AutoMapper;
using HumanManagement.Application.Response;
using HumanManagement.Domain.Recruitment.Contracts;
using HumanManagement.Domain.Recruitment.Dto;
using HumanManagement.Domain.Recruitment.QueryFilter;
using HumanManagement.Domain.BaseRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.Recruitment.Queries
{
    public class GetEmployeeChargeQuery : IRequest<EmployeeChargeDto>
    {
        public int requestDto { get; set; }
        public class GetEmployeeChargeHandler : IRequestHandler<GetEmployeeChargeQuery, EmployeeChargeDto>
        {
            private readonly IRequestRepository requestRepository;
            private IMapper mapper;

            public GetEmployeeChargeHandler(IMapper mapper,
                                       IRequestRepository requestRepository)
            {
                this.mapper = mapper;
                this.requestRepository = requestRepository;
            }
            public async Task<EmployeeChargeDto> Handle(GetEmployeeChargeQuery request, CancellationToken cancellationToken)
            {
                var result = await requestRepository.GetEmployeeChargeByUser(request.requestDto);
                return result;
            }
        }



    }
}
