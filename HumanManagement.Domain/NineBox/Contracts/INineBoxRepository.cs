using HumanManagement.Domain.Common;
using HumanManagement.Domain.NineBox.Dto;
using HumanManagement.Domain.NineBox.QueryFilter;

using System.Threading.Tasks;

namespace HumanManagement.Domain.NineBox.Contracts
{
    public interface INineBoxRepository
    {
        Task<ResultPaginationListDto<ListNineBoxDto>> GetListNineBox(NineBoxQueryFilter filter);
        Task<int> EditConfigNineBox(NineBoxDto dto);

    }

}
