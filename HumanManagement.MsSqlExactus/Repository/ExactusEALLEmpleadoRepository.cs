using HumanManagement.Domain.Contracts;
using HumanManagement.Domain.WindowsService.Exactus.Contracts;
using HumanManagement.Domain.WindowsService.Exactus.Models;
using HumanManagement.MsSqlExactus.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.MsSqlExactus.Repository
{
  
    public class ExactusEALLEmpleadoRepository : ExactusBaseRepository<ExactusEALLEmpleado>, IExactusEALLEmpleadoRepository
    {

        private readonly IExactusReadDbConnection exactusReadDbConnection;
        public ExactusEALLEmpleadoRepository(IExactusReadDbConnection exactusReadDbConnection,
                              ExactusDbContextMsSql context)
            : base(context)
        {
            this.exactusReadDbConnection= exactusReadDbConnection;
        }


    }
}
