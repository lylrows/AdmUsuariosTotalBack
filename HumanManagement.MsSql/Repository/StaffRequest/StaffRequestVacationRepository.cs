using HumanManagement.Domain.Contracts;
using HumanManagement.Domain.StaffRequest.Contracts;
using HumanManagement.Domain.StaffRequest.Dto;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HumanManagement.MsSql.Context;

namespace HumanManagement.MsSql.Repository.StaffRequest
{
    public class StaffRequestVacationRepository : IStaffRequestVacationRepository
    {
        private readonly IHumanManagementReadDbConnection humanManagementReadDbConnection;
        private readonly DbContextMsSql context;
        public StaffRequestVacationRepository(IHumanManagementReadDbConnection humanManagementReadDbConnection,
                                                DbContextMsSql context)
        {
            this.humanManagementReadDbConnection = humanManagementReadDbConnection;
            this.context = context;
        }
        public async Task<StaffRequestVacationDto> GetById(int id)
        {
            var result = await(from v in context.tb_staff_request_vacation
                               where v.IdStaffRequest == id
                               select new StaffRequestVacationDto
                               {
                                   IdStaffRequest = v.IdStaffRequest,
                                   StartVacation = v.StartVacation,
                                   EndVacation = v.EndVacation,
                                   NumberCalendarDays = v.NumberCalendarDays,
                                   NumberBusinessDays = v.NumberBusinessDays,
                                   VacationPeriod = v.VacationPeriod
                               }).SingleOrDefaultAsync();

            return result;
        }
    }
}
