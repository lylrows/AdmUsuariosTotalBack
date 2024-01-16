using HumanManagement.Domain.StaffRequest.Contracts;
using HumanManagement.Domain.StaffRequest.Dto;
using HumanManagement.MsSql.Context;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace HumanManagement.MsSql.Repository.StaffRequest
{
    public class StaffRequestAccountChangeCtsRepository : IStaffRequestAccountChangeCtsRepository
    {
        private readonly DbContextMsSql context;
        public StaffRequestAccountChangeCtsRepository(DbContextMsSql context)
        {
            this.context = context;
        }
        public async Task<StaffRequestAccountChangeDto> GetById(int id)
        {
            var result = await (from v in context.tb_staff_request_account_change_cts
                                join bank_ori in context.tb_financialentity on v.BankingEntityChange equals bank_ori.Code
                                join bank_des in context.tb_financialentity on v.BankingDestinCts equals bank_des.Code
                                where v.IdStaffRequest == id
                                select new StaffRequestAccountChangeDto
                                {
                                    IdStaffRequest = v.IdStaffRequest,
                                    IdBankingEntityCurrent = v.IdBankingEntityCurrent,
                                    BankingEntityChange = v.BankingEntityChange,
                                    IdCurrencyAccountCurrent = v.IdCurrencyAccountCurrent,
                                    IdCurrencyAccountChange = v.IdCurrencyAccountChange,
                                    AccountNumberCts = v.AccountNumberCts,
                                    
                                    
                                    CurrencyAccountCurrent = v.IdBankingEntityCurrent == 1 ? "Soles" : "Dólares",
                                    
                                    PathFileDocument = v.PathFileDocument,
                                    AccountNewNumberCts = v.AccountNewNumberCts,
                                    AccountCCINewNumberCts = v.AccountCCINewNumberCts,
                                    OrigenCurrencyCts=v.IdCurrencyAccountChange == 1? "Soles" : "Dólares",
                                    BankingOrigenCts = bank_ori.Description,
                                    DestinCurrencyCts =v.DestinCurrencyCts=="1"?"Soles": "Dólares",
                                    BankingDestinCts= bank_des.Description

                                }).SingleOrDefaultAsync();

            return result;
        }
    }
}
