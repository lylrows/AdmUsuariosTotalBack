using HumanManagement.Domain.StaffRequest.Contracts;
using HumanManagement.Domain.StaffRequest.Dto;
using HumanManagement.MsSql.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HumanManagement.MsSql.Repository.StaffRequest
{
    public class StaffRequestApproverRepository : IStaffRequestApproverRepository
    {
        private readonly DbContextMsSql context;
        public StaffRequestApproverRepository(DbContextMsSql context)
        {
            this.context = context;
        }
        public async Task<List<StaffRequestApproverListDto>> GetListById(int idStaffRequest)
        {
            var result = await (from p in context.tb_staff_request_approver
                                join em in context.Employee on p.IdEmployee equals em.Id
                                join per in context.Person on em.IdPerson equals per.Id
                                join c in context.tb_charge on em.IdPosition equals c.Id
                                join a in context.tb_area on c.IdArea equals a.Id
                                join e in context.tb_company on c.IdEmpresa equals e.Id
                                join u in context.User on per.Id equals u.IdPerson
                                join pu in context.ProfileUser on u.Id equals pu.IdUser
                                where p.IdStaffRequest == idStaffRequest
                                select new StaffRequestApproverListDto
                                {
                                    IdEmployee = per.Id,
                                    IdProfile = pu.IdProfile,
                                    Charge = c.NameCargo,
                                    Area = a.NameArea,
                                    Company = e.Descripcion,
                                    FullName = per.FirstName + " " + per.LastName,
                                    FullNameComplete = per.FirstName + " " + (string.IsNullOrEmpty(per.SecondName)?"":per.SecondName) + " " + per.LastName + " " + per.MotherLastName,
                                    Level = p.Level,
                                    State = p.State,
                                    ReviewDate = p.DateRegister
                                }).ToListAsync(); 

            return result;
        }

        public async Task<DateTime?> GetDateEvaluation(int idStaffRequest)
        {
            var result = await context.tb_staff_request_approver
                        .Where(d => d.IdStaffRequest == idStaffRequest)
                        .MaxAsync(f => f.DateRegister as DateTime?);

            return result;
        }
    }
}
