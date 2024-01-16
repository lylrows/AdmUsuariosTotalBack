using HumanManagement.Domain.StaffRequest.Contracts;
using HumanManagement.Domain.StaffRequest.Dto;
using HumanManagement.MsSql.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HumanManagement.MsSql.Repository.StaffRequest
{
    public class StaffRequestAbsenceRepository : IStaffRequestAbsenceRepository
    {
        private readonly DbContextMsSql context;
        public StaffRequestAbsenceRepository(DbContextMsSql context)
        {
            this.context = context;
        }
        public async Task<StaffRequestAbsenceDto> GetById(int id)
        {
            var result = await(from v in context.tb_staff_request_absence
                               join t in context.tb_type_absence on v.IdTypeAbsence equals t.Id
                               where v.IdStaffRequest == id
                               select new StaffRequestAbsenceDto
                               {
                                   IdStaffRequest = v.IdStaffRequest,
                                   TypeAbsenceName = t.Name,
                                   DateAbsence = v.DateAbsence,
                                   StartTime = v.StartTime,
                                   EndTime = v.EndTime,
                                   Support = v.Support,
                                   PathFileDocument = v.PathFileDocument
                               }).SingleOrDefaultAsync();

            return result;
        }
    }
}
