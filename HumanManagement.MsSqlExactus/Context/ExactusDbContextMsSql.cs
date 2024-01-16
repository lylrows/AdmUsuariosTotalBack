using HumanManagement.Domain.WindowsService.Exactus.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanManagement.MsSqlExactus.Context
{
    
    public class ExactusDbContextMsSql : DbContext
    {

        public ExactusDbContextMsSql(DbContextOptions<ExactusDbContextMsSql> option): base(option)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ParameterConfig(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }
        private void ParameterConfig(ModelBuilder modelBuilder)
        {
            #region HumanManagement

            modelBuilder.Entity<ExactusEALLEmpleado>(e =>
            {
                e.ToTable("EMPLEADO", "E_ALL")
                .HasKey(x => x.EMPLEADO);
                e.Property(c => c.EMPLEADO);
            });


            #endregion


        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            
              return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
