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
    public class InformationFamilyRepository : IInformationFamilyRepository
    {
        private readonly DbContextMsSql dbContext;

        public InformationFamilyRepository(DbContextMsSql dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<List<InformationFamilyDto>> GetInformationFamily(int IdPostulant, int IdEvaluation)
        {
            var dto = await (from p in dbContext.tb_information_family
                             where p.IdPostulant == IdPostulant && p.IdEvaluation == IdEvaluation
                             select new InformationFamilyDto
                             {
                                 Id = p.Id,
                                 IdPostulant = p.IdPostulant,
                                 Kinship = p.Kinship,
                                 Age = p.Age,
                                 BirthDate = p.BirthDate == null ? "": p.BirthDate.Value.ToString("yyyy-MM-dd"),
                                 Company = p.Company,
                                 FullName = p.FullName,
                                 Ocupation = p.Ocupation ,
                                 LastName  = p.LastName,
                                 MotherLastName = p.MotherLastName,
                                 FamilyType = p.FamilyType,
                                 DocumentNumber = p.DocumentNumber,
                                 TypeDocument = p.TypeDocument,
                                 IdEvaluation = p.IdEvaluation
                             }).ToListAsync();
            return dto;
        }

        public async Task<List<InformationFamilyDto>> GetInformationFamilyByPerson(int IdPostulant)
        {
            var dto = await (from p in dbContext.tb_information_family
                             where p.IdPostulant == IdPostulant
                             select new InformationFamilyDto
                             {
                                 Id = p.Id,
                                 IdPostulant = p.IdPostulant,
                                 Kinship = p.Kinship,
                                 Age = p.Age,
                                 BirthDate = p.BirthDate == null ? "" : p.BirthDate.Value.ToString("yyyy-MM-dd"),
                                 Company = p.Company,
                                 FullName = p.FullName,
                                 Ocupation = p.Ocupation,
                                 LastName = p.LastName,
                                 MotherLastName = p.MotherLastName,
                                 FamilyType = p.FamilyType,
                                 DocumentNumber = p.DocumentNumber,
                                 TypeDocument = p.TypeDocument,
                                 IdEvaluation = p.IdEvaluation
                             }).ToListAsync();
            return dto;
        }
    }
}
