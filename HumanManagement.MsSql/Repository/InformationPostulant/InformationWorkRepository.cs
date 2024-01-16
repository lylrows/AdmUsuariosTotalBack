using HumanManagement.Domain.InformationPostulant.Contracts;
using HumanManagement.Domain.InformationPostulant.Dto;
using HumanManagement.MsSql.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HumanManagement.MsSql.Repository.InformationPostulant
{
   
    public class InformationWorkRepository : IInformationWorkRepository
    {
        private readonly DbContextMsSql dbContext;

        public InformationWorkRepository(DbContextMsSql dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<List<InformationWorkDto>> GetInformationWork(int IdPostulant, int IdEvaluation)
        {
            var dtos = await (from p in dbContext.tb_information_work
                              where p.IdPostulant == IdPostulant && p.IdEvaluation == IdEvaluation
                              select new InformationWorkDto
                              {
                                  Id = p.Id,
                                  IdPostulant = p.IdPostulant,
                                  DateFinish = p.DateFinish == null ? "" : p.DateFinish.Value.ToString("yyyy-MM-dd"),
                                  DateStart = p.DateStart == null ? "" : p.DateStart.Value.ToString("yyyy-MM-dd"),
                                  
                                  Company =  p.Company,
                                  LastPosition = p.LastPosition,
                                  MainFunction  = p.MainFunction,
                                  Salary = p.Salary,
                                  Reference = p.Reference,
                                  IdEvaluation = p.IdEvaluation
                              }).ToListAsync();
            return dtos;
        }
    }
}
