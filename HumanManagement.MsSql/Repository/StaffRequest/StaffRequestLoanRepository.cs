using HumanManagement.Domain.StaffRequest.Contracts;
using HumanManagement.Domain.StaffRequest.Dto;
using HumanManagement.MsSql.Context;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using HumanManagement.Domain.Contracts;
using Dapper;
using System.Data;

namespace HumanManagement.MsSql.Repository.StaffRequest
{
    public class StaffRequestLoanRepository : IStaffRequestLoanRepository
    {
        private readonly DbContextMsSql context;
        private readonly IHumanManagementReadDbConnection humanManagementReadDbConnection;
        public StaffRequestLoanRepository(DbContextMsSql context, IHumanManagementReadDbConnection humanManagementReadDbConnection)
        {
            this.context = context;
            this.humanManagementReadDbConnection = humanManagementReadDbConnection;
        }

        public async Task<StaffRequestLoanDto> GetById(int id)
        { 
            try
            {
                var result = await (from v in context.tb_staff_request_loan
                                    join t in context.tb_type_loan on v.IdTypeLoan equals t.Id
                                    join re in context.tb_staff_request on v.IdStaffRequest equals re.Id
                                    where v.IdStaffRequest == id
                                    select new StaffRequestLoanDto
                                    {
                                        IdStaffRequest = v.IdStaffRequest,
                                        IdTypeLoan = v.IdTypeLoan,
                                        TypeLoanName = t.Name,
                                        Amount = v.Amount,
                                        AmountMonthlyFee = v.AmountMonthlyFee,
                                        NumberFee = v.NumberFee,
                                        DetailReasonLoan = v.DetailReasonLoan,
                                        PathFileDocument = v.PathFileDocument,
                                        ntypecase = v.ntypecase,
                                        ncoutaselect = v.ncoutaselect,
                                        monthPay = re.monthPay,
                                        yearPay = re.yearPay,
                                        CobroGratificacion = v.CobroGratificacion,
                                        CobroUtilidad = v.CobroUtilidad,
                                        Balance = v.Balance,
                                        Comment = re.Comment,
                                        TerminosYCond = re.TerminosYCond,
                                        DateLoan = v.DateLoan,
                                        bGrati = v.bGrati==null? false: v.bGrati.Value,
                                        bUtil= v.bUtil == null ? false : v.bUtil.Value,
                                        nAddGrati = v.nAddGrati??0,
                                        nAddUtilidad= v.nAddUtilidad??0
                                    }).SingleOrDefaultAsync();


                return result;
            }
            catch (System.Exception ex)
            {
                var x = "";
            }
            return null;
        }

        public async Task<List<RequestDetailtLoanDto>> GetDetailtById(int id)
        {
            var queryParameters = new DynamicParameters();

            queryParameters.Add("@nid_request", id);


            var list = await humanManagementReadDbConnection.QueryAsync<RequestDetailtLoanDto>(
                 "sp_request_loand_detail_sel",
                 queryParameters, commandType: CommandType.StoredProcedure);


            return list.ToList();
        }

        public async Task<List<RequestDetailtLoanDto>> CalculateTimeLine(StaffRequestLoanDto payload)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@nid_staff_request", 0);
            
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

            var list = await humanManagementReadDbConnection.QueryAsync<RequestDetailtLoanDto>(
                 "staff.sps_temp_request_loan_detail_ins",
                 queryParameters, commandType: CommandType.StoredProcedure);


            return list.ToList();
        }
    }
}
