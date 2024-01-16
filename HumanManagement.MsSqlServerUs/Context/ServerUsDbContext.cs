using HumanManagement.Domain.Contracts.ServerUs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.MsSqlServerUs.Context
{
   
    public class ServerUsDbContext : DbContext, IServerUsDbContext
    {
        public ServerUsDbContext(DbContextOptions<ServerUsDbContext> options)
            : base(options)
        {

        }
        
        public IDbConnection Connection => Database.GetDbConnection();
    }
}
