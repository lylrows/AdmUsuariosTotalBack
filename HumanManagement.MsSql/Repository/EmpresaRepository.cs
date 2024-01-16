using HumanManagement.Domain.Empresa.Contracts;
using HumanManagement.Domain.Empresa.Dto;
using HumanManagement.MsSql.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Dapper;
using HumanManagement.Domain.Contracts;
using System.Data;

namespace HumanManagement.MsSql.Repository
{
    public class EmpresaRepository : IEmpresaRepository
    {
        private readonly DbContextMsSql context;
        private readonly IHumanManagementReadDbConnection humanManagementReadDbConnection;
        public EmpresaRepository(DbContextMsSql context, IHumanManagementReadDbConnection humanManagementReadDbConnection)
        {
            this.context = context;
            this.humanManagementReadDbConnection = humanManagementReadDbConnection;
        }
        public async Task<List<EmpresaDto>> GetAll()
        {
            var empresas = await (from p in context.tb_company
                                  where p.Active == true
                                  select new EmpresaDto
                                  {
                                      Id = p.Id,
                                      Descripcion = p.Descripcion,
                                      DateRegister = p.DateRegister,
                                      DateUpdate = p.DateUpdate,
                                      IdUserRegister = p.IdUserRegister,
                                      IdUserUpdate = p.IdUserUpdate,
                                      Schema = p.Schema,
                                      IdServerUs = p.IdServerUs,
                                      Ruc = p.Ruc
                                  }).ToListAsync();
            return empresas.OrderBy(c=>c.Descripcion).ToList();
        }

        public async Task<int> GetIdByName(string nameCompany)
        {
            var IdCompany = await context.tb_company.Where(x => x.Descripcion.Equals(nameCompany))
                                                .Select(d => d.Id)
                                                .SingleOrDefaultAsync();

            return IdCompany;
        }

        public async Task<List<EmpresaDto>> GetEmpresaByUser(int IdUser)
        {
            try
            {
                var queryParameters = new DynamicParameters();

                queryParameters.Add("@nid_user", IdUser);



                var listMyEvaluation = await humanManagementReadDbConnection.QueryAsync<EmpresaDto>(
                     "sps_empresabyuser",
                     queryParameters, commandType: CommandType.StoredProcedure);

                return listMyEvaluation.ToList();
            }
            catch (Exception ex)
            {
                return new List<EmpresaDto>();
                throw ex;
            }
            
        }


    }
}
