using HumanManagement.Domain.Security.Contracts;
using HumanManagement.MsSql.Context;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HumanManagement.MsSql.Repository.Security
{
    public class LoginAttemptRepository : ILoginAttemptRepository
    {
        private readonly DbContextMsSql context;
        public LoginAttemptRepository(DbContextMsSql context)
        {
            this.context = context;
        }
        public async Task<int> GetByIdUser(int idUser)
        {
            int id = await context.LoginAttempt.Where(x => x.IdUser == idUser)
                                .Select(d => d.Id).SingleOrDefaultAsync();

            return id;
        }
        public async Task UpdateAttempt(int id)
        {


            var login = await context.LoginAttempt.FindAsync(id);
            login.NumberAttempts += 1;
            await context.SaveChangesAsync();
        }

        public async Task<int> GetNumberAttempts(int id)
        {
            var quantity = await context.LoginAttempt.Where(x => x.Id == id)
                                .Select(d => d.NumberAttempts).SingleOrDefaultAsync();

            return quantity;
        }
    }
}
