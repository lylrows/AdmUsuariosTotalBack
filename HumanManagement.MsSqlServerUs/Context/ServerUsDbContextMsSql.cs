using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace HumanManagement.MsSqlServerUs.Context
{
  
    public class ServerUsDbContextMsSql : DbContext
    {
        public ServerUsDbContextMsSql(DbContextOptions<ServerUsDbContextMsSql> option)
            : base(option)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ParameterConfig(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }
        private void ParameterConfig(ModelBuilder modelBuilder)
        {
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
