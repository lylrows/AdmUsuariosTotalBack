using HumanManagement.Domain.InformationPostulant.Contracts;
using HumanManagement.Domain.InformationPostulant.Dto;
using HumanManagement.MsSql.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace HumanManagement.MsSql.Repository.InformationPostulant
{
    public class InformationEducationRepository : IInformationEducationRepository
    {
        private readonly DbContextMsSql dbContext;

        public InformationEducationRepository(DbContextMsSql dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<List<InformationEducationDto>> GetInformationEducation(int IdPostulant, int idEvaluation)
        {
            var dtos = await (from p in dbContext.tb_information_education
                              where p.IdPostulant == IdPostulant && p.IdEvaluation == idEvaluation
                              select new InformationEducationDto
                              {
                                  Id = p.Id,
                                  IdPostulant = p.IdPostulant,
                                  Instruction = p.Instruction,
                                  City = p.City,
                                  DateFinish = p.DateFinish ==null ? "" : p.DateFinish.Value.ToString("yyyy-MM-dd"),
                                  DateStart = p.DateStart == null ? "" : p.DateStart.Value.ToString("yyyy-MM-dd"),
                                  Speciality = p.Speciality,
                                  StudyCenter = p.StudyCenter,
                                  Carrer = p.Carrer,
                                  IdInstruction = p.IdInstruction??0,
                                  CurrentCycle = p.CurrentCycle??0,
                                  IdEvaluation = p.IdEvaluation
                              }).ToListAsync();
            return dtos;
        }

        public async Task<List<InformationEducationDto>> GetInformationEducationByPerson(int IdPostulant)
        {
            var dtos = await (from p in dbContext.tb_information_education
                              where p.IdPostulant == IdPostulant
                              select new InformationEducationDto
                              {
                                  Id = p.Id,
                                  IdPostulant = p.IdPostulant,
                                  Instruction = p.Instruction,
                                  City = p.City,
                                  DateFinish = p.DateFinish == null ? "" : p.DateFinish.Value.ToString("yyyy-MM-dd"),
                                  DateStart = p.DateStart == null ? "" : p.DateStart.Value.ToString("yyyy-MM-dd"),
                                  Speciality = p.Speciality,
                                  StudyCenter = p.StudyCenter,
                                  Carrer = p.Carrer,
                                  IdInstruction = p.IdInstruction ?? 0,
                                  CurrentCycle = p.CurrentCycle ?? 0,
                                  IdEvaluation = p.IdEvaluation
                              }).ToListAsync();
            return dtos;
        }
    }
}
