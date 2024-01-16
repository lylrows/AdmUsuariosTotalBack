using HumanManagement.Domain.Contracts;
using Microsoft.EntityFrameworkCore;

using System.Data;


namespace HumanManagement.MsSqlExactus.Context
{
    
    public class ExactusDbContext : DbContext, IExactusDbContext
    {
        public ExactusDbContext(DbContextOptions<ExactusDbContext> options)
            : base(options)
        {

        }

        public IDbConnection Connection => Database.GetDbConnection();
    }
}
