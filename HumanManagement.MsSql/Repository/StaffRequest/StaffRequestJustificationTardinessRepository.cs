using HumanManagement.Domain.StaffRequest.Contracts;
using HumanManagement.Domain.StaffRequest.Dto;
using HumanManagement.MsSql.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace HumanManagement.MsSql.Repository.StaffRequest
{    
    public class StaffRequestJustificationTardinessRepository : IStaffRequestJustificationTardinessRepository
    {
        private readonly DbContextMsSql context;
        public StaffRequestJustificationTardinessRepository(DbContextMsSql context)
        {
            this.context = context;
        }
        public async Task<StaffRequestJustificationTardinessDto> GetById(int id)
        {
            var result = await(from v in context.tb_staff_request_justification_tardiness
                               where v.IdStaffRequest == id
                               select new StaffRequestJustificationTardinessDto
                               {
                                   IdStaffRequest = v.IdStaffRequest,
                                   tardinessDate = v.tardinessDate,
                                   StartTime = v.StartTime,
                                   EndTime = v.EndTime,
                                   Support = v.Support,
                                   PathFileDocument = v.PathFileDocument
                               }).SingleOrDefaultAsync();

            return result;
        }
    }
}
