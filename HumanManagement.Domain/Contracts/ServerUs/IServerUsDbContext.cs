using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanManagement.Domain.Contracts.ServerUs
{
    
    public interface IServerUsDbContext
    {
        public IDbConnection Connection { get; }
        DatabaseFacade Database { get; }

    }
}
