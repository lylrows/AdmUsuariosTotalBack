using HumanManagement.Domain.Common;
using HumanManagement.Domain.StaffRequest.Contracts;
using HumanManagement.MsSql.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HumanManagement.MsSql.Repository.StaffRequest
{
    public class PermitTypeRepository : IPermitTypeRepository
    {
        private readonly DbContextMsSql context;
        public PermitTypeRepository(DbContextMsSql context)
        {
            this.context = context;
        }
        public async Task<List<ResultForSelectDto>> GetForSelect()
        {
            var result = await(from r in context.tb_permit_type
                               where r.Active == true
                               select new ResultForSelectDto
                               {
                                   Id = r.Id,
                                   Description = r.Name
                               }).ToListAsync();

            return result;
        }
    }
}
