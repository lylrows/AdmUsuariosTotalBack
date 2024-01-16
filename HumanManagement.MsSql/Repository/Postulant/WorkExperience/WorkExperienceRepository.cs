using HumanManagement.Domain.Postulant.WorkExperience.Contracts;
using HumanManagement.Domain.Postulant.WorkExperience.Dto;
using HumanManagement.MsSql.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace HumanManagement.MsSql.Repository.Postulant.WorkExperience
{
    public class WorkExperienceRepository : IWorkExperienceRepository
    {
        private readonly DbContextMsSql context;
        public WorkExperienceRepository(DbContextMsSql context)
        {
            this.context = context;
        }

        public async Task<List<WorkExperienceDto>> GetWorkExperience(int IdPerson)
        {
            var dto = await (from p in context.WorkExperience
                             where p.IdPerson == IdPerson && p.Active == true
                             orderby p.YearStart descending
                             select new WorkExperienceDto
                             {
                                 Id = p.Id,
                                 IdPerson = p.IdPerson,
                                 Present = p.Present,
                                 Company = p.Company,
                                 DescriptionResponsabilities = p.DescriptionResponsabilities,
                                 IdActivity = p.IdActivity,
                                 IdCountry = p.IdCountry,
                                 IdExperienceLevel = p.IdExperienceLevel,
                                 IdPeopleCharge = p.IdPeopleCharge,
                                 IdPositionArea = p.IdPositionArea,
                                 subArea = p.SubArea,
                                 MonthEnd = p.MonthEnd,
                                 MonthStart = p.MonthStart,
                                 Stand = p.Stand,
                                 YearEnd = p.YearEnd,
                                 YearStart = p.YearStart,
                                 Active = p.Active,
                                 Salary =Convert.ToString(p.Salary??0)

                             }).ToListAsync();
            return dto;
        }

        public async Task<List<WorkExperienceDto>> GetWorkExperiencePostulants(int[] arrayIdPostulant)
        {
            var dto = await (from p in context.WorkExperience
                             where arrayIdPostulant.Contains(p.IdPerson) && p.Active == true
                             orderby p.YearStart descending
                             select new WorkExperienceDto
                             {
                                 Id = p.Id,
                                 IdPerson = p.IdPerson,
                                 Present = p.Present,
                                 Company = p.Company,
                                 DescriptionResponsabilities = p.DescriptionResponsabilities,
                                 IdActivity = p.IdActivity,
                                 IdCountry = p.IdCountry,
                                 IdExperienceLevel = p.IdExperienceLevel,
                                 IdPeopleCharge = p.IdPeopleCharge,
                                 IdPositionArea = p.IdPositionArea,
                                 subArea = p.SubArea,
                                 MonthEnd = p.MonthEnd,
                                 MonthStart = p.MonthStart,
                                 Stand = p.Stand,
                                 YearEnd = p.YearEnd,
                                 YearStart = p.YearStart,
                                 Active = p.Active
                             }).ToListAsync();
            dto = dto.OrderBy(x => x.YearStart).ToList();
            return dto;
        }
    }
}