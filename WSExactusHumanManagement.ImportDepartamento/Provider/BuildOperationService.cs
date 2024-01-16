using HumanManagement.Application.Helpers;
using HumanManagement.Domain.Areas.Contracts;
using HumanManagement.Domain.Areas.Models;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.Contracts;
using HumanManagement.Domain.Empresa.Contracts;
using HumanManagement.Domain.General.Contracts;
using HumanManagement.Domain.WindowsService.Exactus.Contracts;
using HumanManagement.MsSql.Connections;
using HumanManagement.MsSql.Context;
using HumanManagement.MsSql.Repository;
using HumanManagement.MsSql.Repository.General;
using HumanManagement.MsSqlExactus.Connections;
using HumanManagement.MsSqlExactus.Context;
using HumanManagement.MsSqlExactus.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSHumanManagement.Application.Exactus.Departamento.IServices;
using WSHumanManagement.Application.Exactus.Departamento.Services;

namespace WSExactusHumanManagement.ImportDepartamento.Provider
{
    public static class BuildOperationService
    {

        

        public static IServiceCollection ConfigureDI(this IServiceCollection services, string conexionSql)
        {
            

            
            services.AddDbContext<DbContextMsSql>(option => option.UseSqlServer(conexionSql));
            services.AddDbContext<HumanManagementDbContext>(options =>options.UseSqlServer(conexionSql));
            
            services.AddScoped<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<HumanManagement.Application.Helpers.SessionManager>();
            services.AddScoped<SitePostulant.Application.Helpers.SessionManager>();


            services.AddScoped<IExactusDbContext>(provider => provider.GetService<ExactusDbContext>());
            services.AddScoped<IExactusWriteDbConnection, ExactusWriteDbConnection>();
            services.AddScoped<IExactusReadDbConnection, ExactusReadDbConnection>();


            services.AddScoped<IHumanManagementDbContext>(provider => provider.GetService<HumanManagementDbContext>());
            services.AddScoped<IHumanManagementWriteDbConnection, HumanManagementWriteDbConnection>();
            services.AddScoped<IHumanManagementReadDbConnection, HumanManagementReadDbConnection>();
            services.AddScoped<IExactusDepartamentoLogic, ExactusDepartamentoLogic>();
            services.AddScoped<IEmpresaRepository, EmpresaRepository>();
            services.AddScoped<IExactusDepartamentoRepository, ExactusDepartamentoRepository>();
            services.AddScoped<IAreaRepository, AreaRepository>();
            services.AddScoped<IBaseRepository<Areas>, BaseRepository<Areas>>();

            services.AddScoped<ICoreParameterRepository, CoreParameterRepository>();
            

            return services;
        }
    }
}
