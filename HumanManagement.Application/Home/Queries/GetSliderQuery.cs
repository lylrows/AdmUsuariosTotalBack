using AutoMapper;
using HumanManagement.Application.Response;
using HumanManagement.Domain.Home.Contracts;
using HumanManagement.Domain.Home.Dto;
using HumanManagement.Domain.Home.QueryFilter;
using HumanManagement.Domain.BaseRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.Application.Home.Queries
{
    public class GetSliderQuery : IRequest<Result>
    {
        public SliderQueryFilter sliderQueryFilter { get; set; }
        public class GetSliderQueryHandler : IRequestHandler<GetSliderQuery, Result>
        {
            private readonly IBaseRepository<Domain.Home.Models.Slider> baseRepository;
            private readonly ISliderRepository sliderRepository;
            private IMapper mapper;

            public GetSliderQueryHandler(IBaseRepository<Domain.Home.Models.Slider> baseRepository,
                                       IMapper mapper,
                                       ISliderRepository sliderRepository)
            {
                this.baseRepository = baseRepository;
                this.mapper = mapper;
                this.sliderRepository = sliderRepository;
            }
            public async Task<Result> Handle(GetSliderQuery request, CancellationToken cancellationToken)
            {
                var output = new Result();
                var result = await sliderRepository.GetListSliderPagination(request.sliderQueryFilter);
                output.Data = result;
                return output;
            }
        }
    }
}
