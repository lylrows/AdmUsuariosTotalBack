using HumanManagement.Domain.Person.Contracts;
using HumanManagement.MsSql.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanManagement.MsSql.Repository.Person
{
    public class PhoneRepository : IPhoneRepository
    {
        private readonly DbContextMsSql context;
        public PhoneRepository(DbContextMsSql context)
        {
            this.context = context;
        }
        public async Task DeleteByPerson(int idPerson)
        {
            context.Phone.RemoveRange(context.Phone
                                      .Where(x => x.IdPerson == idPerson).ToList());

            await context.SaveChangesAsync();
        }
    }
}
