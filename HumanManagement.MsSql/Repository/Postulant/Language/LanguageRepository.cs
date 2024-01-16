using HumanManagement.Domain.Postulant.Languages.Contracts;
using HumanManagement.Domain.Postulant.Languages.Dto;
using HumanManagement.MsSql.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace HumanManagement.MsSql.Repository.Postulant.Language
{
    public class LanguageRepository : ILanguagesPostulantRepository
    {
        private readonly DbContextMsSql context;

        public LanguageRepository(DbContextMsSql context)
        {
            this.context = context;
        }
        public async Task<List<LanguagePostulantDto>> GetLanguagePostulant(int IdPerson)
        {
            var dto = await (from p in context.LanguagePostulant join ml in context.MasterTable on p.IdLanguagePostulant equals ml.Id
                             join mw in context.MasterTable on p.IdWrittenLeven equals mw.Id
                             join mr in context.MasterTable on p.IdOralLeven equals mr.Id
                       where p.IdPerson == IdPerson && p.Active == true
                       select new LanguagePostulantDto
                       {
                           Id = p.Id,
                           IdPerson = p.IdPerson,
                           IdLanguagePostulant = p.IdLanguagePostulant,
                           IdOralLeven = p.IdOralLeven,
                           IdWrittenLeven = p.IdWrittenLeven,
                           DescripcionLang = ml.DescriptionValue,
                           DescriptionOralLeven = mr.DescriptionValue,
                           DescriptionWrittenLeven = mw.DescriptionValue
                       }).ToListAsync();
            return dto;
        }
    }
}
