using HumanManagement.Domain.StaffRequest.Contracts;
using HumanManagement.Domain.StaffRequest.Dto;
using HumanManagement.MsSql.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HumanManagement.Domain.Contracts;
using Dapper;
using System.Data;
using HumanManagement.Domain.StaffRequest.Models;

namespace HumanManagement.MsSql.Repository.StaffRequest
{
    public class TypeStaffRequestApproverRepository : ITypeStaffRequestApproverRepository
    {
        private readonly DbContextMsSql context;
        private readonly IHumanManagementReadDbConnection humanManagementReadDbConnection;
        public TypeStaffRequestApproverRepository(DbContextMsSql context, IHumanManagementReadDbConnection humanManagementReadDbConnection)
        {
            this.context = context;
            this.humanManagementReadDbConnection = humanManagementReadDbConnection;

        }

        public async Task DeleteById(int id)
        {
            context.RemoveRange(context.tb_type_staff_request_approver
                                .Where(x => x.IdTypeStaffRequest == id));
            await context.SaveChangesAsync();
        }

        public async Task<List<TypeStaffRequestApproverDto>> GetListById(int id)
        {
            var list = await (from n in context.tb_type_staff_request_approver
                              join c in context.Profile on n.IdProfile equals c.Id
                              where n.IdTypeStaffRequest == id
                              orderby n.Level ascending
                              select new TypeStaffRequestApproverDto
                              {
                                  IdApprover = n.IdApprover,
                                  IdCharge = n.IdCharge,
                                  IdProfile = n.IdProfile,
                                  AllowApproveAll = n.AllowApproveAll,
                                  Level = n.Level,
                                  Profile = c.Name,
                                  Name = "Aprobador " + n.Level
                              }).ToListAsync();

            return list;
        }

        public async Task<TypeStaffRequestApproverDto> GetByLevel(int id, int level)
        {
            var result = await (from n in context.tb_type_staff_request_approver
                              join c in context.Profile on n.IdProfile equals c.Id
                              where n.IdTypeStaffRequest == id
                              && n.Level == level
                              select new TypeStaffRequestApproverDto
                              {
                                  IdApprover = n.IdApprover,
                                  IdProfile = n.IdProfile,
                                  AllowApproveAll = n.AllowApproveAll
                              }).SingleOrDefaultAsync();

            return result;
        }

        public async Task<int> GetTotalLevels(int id) 
        {
            int totalLevels = await(from n in context.tb_type_staff_request_approver
                              where n.IdTypeStaffRequest == id
                              select n).CountAsync();

            return totalLevels;
        }

        public async Task InsertLoanDetail(StaffRequestLoanDto payload, int id)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid_staff_request", id);
            
            queryParameters.Add("@amount", payload.Amount); 
            queryParameters.Add("@ncuotas", payload.NumberFee);
            queryParameters.Add("@ncoutafija", payload.AmountMonthlyFee);
            
            queryParameters.Add("@doblecouta", payload.ntypecase);
            queryParameters.Add("@ncoutaselect", payload.ncoutaselect);
            queryParameters.Add("@smonth_pay", payload.monthPay);
            queryParameters.Add("@syear_pay", payload.yearPay);
            queryParameters.Add("@ddate_loan", payload.DateLoan);
            queryParameters.Add("@namount_grati", payload.CobroGratificacion);
            queryParameters.Add("@namount_uti", payload.CobroUtilidad);
            queryParameters.Add("@nrateexactus", payload.RateExactus);

            var list = await humanManagementReadDbConnection.QueryAsync<StaffRequestListDto>(
                 "staff.sp_request_loan_detail_ins",
                 queryParameters, commandType: CommandType.StoredProcedure);
        }

        public async Task InsertLevelRequest(StaffRequestModel request)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid_user", request.IdUserRegister);
            queryParameters.Add("@nid_staff_request", request.Id);

            var list = await humanManagementReadDbConnection.QueryAsync<StaffRequestListDto>(
                 "staff.sp_save_level_request",
                 queryParameters, commandType: CommandType.StoredProcedure);
        }

        public async Task AproveLevelRequest(StaffRequestApprover request)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid_user", request.Id);
            queryParameters.Add("@nid_staff_request", request.IdStaffRequest);
            queryParameters.Add("@scoment", request.Comment);

            var list = await humanManagementReadDbConnection.QueryAsync<StaffRequestListDto>(
                 "staff.sp_aprobe_level_request",
                 queryParameters, commandType: CommandType.StoredProcedure);
        }
    }
}
