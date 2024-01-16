using HumanManagement.Domain.Contracts;
using HumanManagement.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace HumanManagement.MsSql.Context
{
    public class HumanManagementDbContext : DbContext, IHumanManagementDbContext
    {
        public HumanManagementDbContext(DbContextOptions<HumanManagementDbContext> options)
            :base(options)
        {

        }
        public DbSet<User> User { get; set; }
        public IDbConnection Connection => Database.GetDbConnection();
    }
}
