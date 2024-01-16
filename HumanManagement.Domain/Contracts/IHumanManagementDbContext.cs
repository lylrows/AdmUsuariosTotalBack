using HumanManagement.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Data;

namespace HumanManagement.Domain.Contracts
{
   public interface IHumanManagementDbContext
    {
        public IDbConnection Connection { get; }
        DatabaseFacade Database { get; }
        public DbSet<User> User { get; set; }


    }
}
