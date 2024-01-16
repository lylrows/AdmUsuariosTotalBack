using HumanManagement.Domain.StaffRequest.Contracts;
using HumanManagement.Domain.StaffRequest.Dto;
using HumanManagement.MsSql.Context;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace HumanManagement.MsSql.Repository.StaffRequest
{
    public class StaffRequestPermitRepository : IStaffRequestPermitRepository
    {
        private readonly DbContextMsSql context;
        public StaffRequestPermitRepository(DbContextMsSql context)
        {
            this.context = context;
        }
        public async Task<StaffRequestPermitDto> GetById(int id)
        {
            var result = await(from p in context.tb_staff_request_permit
                               join t in context.tb_permit_type on p.IdPermitType equals t.Id
                               where p.IdStaffRequest == id
                               select new StaffRequestPermitDto
                               {
                                   IdStaffRequest = p.IdStaffRequest,
                                   PermitTypeName = t.Name,
                                   IdPermitType = p.IdPermitType,
                                   Support = p.Support,
                                   PermitDate = p.PermitDate,
                                   EndTime = p.EndTime,
                                   StartTime = p.StartTime,
                                   PathFileDocument = p.PathFileDocument
                               }).SingleOrDefaultAsync();

            return result;
        }
    }
}
