using HumanManagement.Domain.Areas.Models;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.Cargo.Models;
using HumanManagement.Domain.Contracts;
using HumanManagement.Domain.Empresa.Contracts;
using HumanManagement.Domain.SalaryBand.Models;
using HumanManagement.Domain.WindowsService.Exactus.Contracts;
using HumanManagement.MsSql.Connections;
using HumanManagement.MsSql.Context;
using HumanManagement.MsSql.Repository;
using HumanManagement.MsSqlExactus.Connections;
using HumanManagement.MsSqlExactus.Context;
using HumanManagement.MsSqlExactus.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSHumanManagement.Application.Exactus.Puesto.IServices;
using WSHumanManagement.Application.Exactus.Puesto.Services;

namespace WSExactusHumanManagement.ImportPuesto.Provider
{
    public static class BuildOperationService
    {

        public static IServiceCollection ConfigureDI(this IServiceCollection services, string conexionSql)
        {
            services.AddDbContext<DbContextMsSql>(option => option.UseSqlServer(conexionSql));
            services.AddDbContext<HumanManagementDbContext>(options => options.UseSqlServer(conexionSql));

            services.AddScoped<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<HumanManagement.Application.Helpers.SessionManager>();
            services.AddScoped<SitePostulant.Application.Helpers.SessionManager>();


            services.AddScoped<IExactusDbContext>(provider => provider.GetService<ExactusDbContext>());
            services.AddScoped<IExactusWriteDbConnection, ExactusWriteDbConnection>();
            services.AddScoped<IExactusReadDbConnection, ExactusReadDbConnection>();


            services.AddScoped<IHumanManagementDbContext>(provider => provider.GetService<HumanManagementDbContext>());
            services.AddScoped<IHumanManagementWriteDbConnection, HumanManagementWriteDbConnection>();
            services.AddScoped<IHumanManagementReadDbConnection, HumanManagementReadDbConnection>();


            services.AddScoped<IEmpresaRepository, EmpresaRepository>();
            services.AddScoped<IExactusPuestoLogic, ExactusPuestoLogic>();
            services.AddScoped<IExactusPuestoRepository, ExactusPuestoRepository>();
            services.AddScoped<IBaseRepository<Cargo>, BaseRepository<Cargo>>();
            services.AddScoped<IBaseRepository<Areas>, BaseRepository<Areas>>();
            services.AddScoped<IBaseRepository<SalaryBand>, BaseRepository<SalaryBand>>();

            return services;
        }
    }
}
