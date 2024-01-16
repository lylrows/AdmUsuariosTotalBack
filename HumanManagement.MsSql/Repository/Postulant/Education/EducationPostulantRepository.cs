using HumanManagement.Domain.Postulant.Education.Contracts;
using HumanManagement.Domain.Postulant.Education.Dto;
using HumanManagement.MsSql.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace HumanManagement.MsSql.Repository.Postulant.Education
{
    public class EducationPostulantRepository : IEducationPostulantRepository
    {
        private readonly DbContextMsSql contexto;
        public EducationPostulantRepository(DbContextMsSql contexto)
        {
            this.contexto = contexto;
        }
        public async Task<List<EducationPostulantDto>> GetEducationByPostulant(int IdPerson)
        {
            var dto = await (from p in contexto.EducationPostulant join mt in contexto.MasterTable
                             on p.IdTypeStudy equals mt.Id into DTypeStudy from tp in DTypeStudy.DefaultIfEmpty()
                             join ms in contexto.MasterTable on p.IdState equals ms.Id into DState from ds in DState.DefaultIfEmpty()
                             join c in contexto.Country on p.IdCountry equals c.Id
                             join mi in contexto.MasterTable on p.IdInstitution equals mi.Id into DInstituto from ins in DInstituto.DefaultIfEmpty()
                       where p.IdPerson == IdPerson && p.Active == true
                       orderby p.YearStart descending
                       select new EducationPostulantDto
                       {
                           Id = p.Id,
                           IdPerson = p.IdPerson,
                           Carreer = p.Carreer,
                           IdAreaStudy = p.IdAreaStudy,
                           IdCountry = p.IdCountry,
                           IdInstitution = p.IdInstitution,
                           IdState = p.IdState,
                           IdTypeStudy = p.IdTypeStudy,
                           MonthEnd = p.MonthEnd,
                           MonthStart = p.MonthStart,
                           YearEnd = p.YearEnd,
                           YearStart = p.YearStart,
                           DescriptionState = ds.DescriptionValue,
                           DescriptionTypeStudy = tp.DescriptionValue,
                           Present = p.Present,
                           Active = p.Active,
                           Country = c.Description,
                           Institution = ins.DescriptionValue,
                           OtherInstitution = p.OtherInstitution
                       }).ToListAsync();
            return dto;
        }
    }
}
