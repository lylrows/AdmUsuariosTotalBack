using HumanManagement.MsSql.Context;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HumanManagement.Domain.General.Contracts;

namespace HumanManagement.MsSql.Repository.General
{
    public class BankRepository : IBankRepository
    {
        private readonly DbContextMsSql context;
        public BankRepository(DbContextMsSql context)
        {
            this.context = context;
        }

        public async Task<int> GetIdByCode(string codeBank)
        {
            var bank = await context.Bank.Where(x => x.CodeBank.Equals(codeBank)).SingleOrDefaultAsync();

            return bank == null ? 0 : bank.Id;
        }
    }
}
