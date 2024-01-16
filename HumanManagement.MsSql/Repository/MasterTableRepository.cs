using HumanManagement.Domain.MasterTable.Contracts;
using HumanManagement.Domain.MasterTable.Dto;
using HumanManagement.MsSql.Context;

using System.Collections.Generic;

using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using HumanManagement.Domain.Contracts;

using System.Data;

namespace HumanManagement.MsSql.Repository
{
    public class MasterTableRepository : IMasterTableRepository
    {
        private readonly DbContextMsSql context;
        private readonly IHumanManagementReadDbConnection humanManagementReadDbConnection;
        public MasterTableRepository(DbContextMsSql context, IHumanManagementReadDbConnection humanManagementReadDbConnection)
        {
            this.context = context;
            this.humanManagementReadDbConnection = humanManagementReadDbConnection;
        }
        public async Task<IEnumerable<MasterTableDto>> GetByIdFather(int id, int nid_type)
        { 
            if (id == 1 && nid_type == 1)//Si es categoria y lista del home
            {
                var result1 = await (from p in context.MasterTable
                                     join d in context.Document on p.IdType equals d.IdCategory
                                    where p.IdFather == id
                                    && d.Active == true
                                    orderby p.DescriptionValue
                                    orderby p.Order
                                    select new MasterTableDto
                                    {
                                        Id = p.Id,
                                        IdType = p.IdType,
                                        IdFather = p.IdFather,
                                        ShortValue = p.ShortValue,
                                        Active = p.Active,
                                        DescriptionValue = (p.DescriptionValue == "F" ?
                                                            "Femenino" :
                                                            p.DescriptionValue == "M" ? "Masculino" : p.DescriptionValue),
                                        Comment = p.Comment,
                                        Order = p.Order,
                                        DateRegister = p.DateRegister,
                                        UserRegister = p.UserRegister,
                                        DateUpdate = p.DateUpdate,
                                        UserUpdate = p.UserUpdate
                                    }).Distinct().ToListAsync();
                return result1;
            } else
            {
                var result = await (from p in context.MasterTable
                                    where p.IdFather == id
                                    orderby p.DescriptionValue
                                    orderby p.Order
                                    select new MasterTableDto
                                    {
                                        Id = p.Id,
                                        IdType = p.IdType,
                                        IdFather = p.IdFather,
                                        ShortValue = p.ShortValue,
                                        Active = p.Active,
                                        DescriptionValue = (p.DescriptionValue == "F" ?
                                                            "Femenino" :
                                                            p.DescriptionValue == "M" ? "Masculino" : p.DescriptionValue),
                                        Comment = p.Comment,
                                        Order = p.Order,
                                        DateRegister = p.DateRegister,
                                        UserRegister = p.UserRegister,
                                        DateUpdate = p.DateUpdate,
                                        UserUpdate = p.UserUpdate
                                    }).ToListAsync();
                return result;
            }
        }
    }
}
