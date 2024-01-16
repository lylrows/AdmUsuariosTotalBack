using HumanManagement.Domain.Postulant.Area.Contracts;
using HumanManagement.Domain.Postulant.Area.Dto;
using HumanManagement.MsSql.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanManagement.MsSql.Repository.Recruitment
{
    public class RecruitmentAreaRepository : IRecruitmentAreaRepository
    {
        private readonly DbContextMsSql context;
        public RecruitmentAreaRepository(DbContextMsSql context)
        {
            this.context = context;
        }
        public async Task<List<AreaForSelectDto>> GetForSelect()
        {
            var result = await(from p in context.tb_AreaRecruitment
                               where p.Active == true
                               select new AreaForSelectDto
                               {
                                   Id = p.Id_Area,
                                   AreaName = p.AreaName
                               }).ToListAsync();
            return result;
        }
    }
}
