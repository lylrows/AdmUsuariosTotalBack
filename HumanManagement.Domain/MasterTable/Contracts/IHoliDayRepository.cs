using HumanManagement.Domain.MasterTable.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HumanManagement.Domain.MasterTable.Contracts
{
    public interface IHoliDayRepository
    {
        Task<List<HoliDayDto>> GetListHoliDayActives();
    }
}
