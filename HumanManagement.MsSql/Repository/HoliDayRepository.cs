using HumanManagement.Domain.MasterTable.Contracts;
using HumanManagement.Domain.MasterTable.Dto;
using HumanManagement.MsSql.Context;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace HumanManagement.MsSql.Repository
{
    public class HoliDayRepository : IHoliDayRepository
    {
        private readonly DbContextMsSql context;
        public HoliDayRepository(DbContextMsSql context)
        {
            this.context = context;
        }
        public async Task<List<HoliDayDto>> GetListHoliDayActives()
        {
            var result = await(from r in context.tb_holiday
                               where r.Active == true
                               select new HoliDayDto
                               {
                                   Id = r.Id,
                                   Day = r.Day,
                                   Month = r.Month
                               }).ToListAsync();

            return result;
        }
    }
}
