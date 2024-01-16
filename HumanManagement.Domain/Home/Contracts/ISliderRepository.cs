using HumanManagement.Domain.Home.Dto;
using HumanManagement.Domain.Home.QueryFilter;
using HumanManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace HumanManagement.Domain.Home.Contracts
{
    public interface  ISliderRepository

    {
        Task<ResultPaginationListDto<SliderDto>> GetListSliderPagination(SliderQueryFilter contactQueryFilter);
    }
}
