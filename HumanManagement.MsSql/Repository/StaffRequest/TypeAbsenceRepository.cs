﻿using HumanManagement.Domain.Common;
using HumanManagement.Domain.StaffRequest.Contracts;
using HumanManagement.MsSql.Context;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace HumanManagement.MsSql.Repository.StaffRequest
{
    public class TypeAbsenceRepository : ITypeAbsenceRepository
    {
        private readonly DbContextMsSql context;
        public TypeAbsenceRepository(DbContextMsSql context)
        {
            this.context = context;
        }
        public async Task<List<ResultForSelectDto>> GetForSelect()
        {
            var result = await(from r in context.tb_type_absence
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
