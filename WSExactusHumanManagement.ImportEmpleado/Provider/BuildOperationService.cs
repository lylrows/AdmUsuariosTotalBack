using HumanManagement.Domain.Areas.Models;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.Domain.Cargo.Models;
using HumanManagement.Domain.Contracts;
using HumanManagement.Domain.Employee.Contracts;
using HumanManagement.Domain.Employee.Models;
using HumanManagement.Domain.Empresa.Contracts;
using HumanManagement.Domain.General.Models;
using HumanManagement.Domain.Mail.Contracts;
using HumanManagement.Domain.MasterTable.Contracts;
using HumanManagement.Domain.Models;
using HumanManagement.Domain.Person.Contracts;
using HumanManagement.Domain.Person.Models;
using HumanManagement.Domain.Security.Contracts;
using HumanManagement.Domain.Security.Models;
using HumanManagement.Domain.WindowsService.Exactus.Contracts;
using HumanManagement.Domain.WindowsService.Exactus.Models;
using HumanManagement.Mail.Repository;
using HumanManagement.MsSql.Connections;
using HumanManagement.MsSql.Context;
using HumanManagement.MsSql.Repository;
using HumanManagement.MsSqlExactus.Connections;
using HumanManagement.MsSqlExactus.Context;
using HumanManagement.MsSqlExactus.Repository;
using HumanManagement.ReadHtml.HtmlMinifiers;
using HumanManagement.Security.Encryption;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSExactusHumanManagement.ImportEmpleado.Helper;
using WSHumanManagement.Application.Exactus.Empleado.IServices;
using WSHumanManagement.Application.Exactus.Empleado.Services;


namespace WSExactusHumanManagement.ImportEmpleado.Provider
{
 
    public static class BuildOperationService
    {

        public static IServiceCollection ConfigureDI(this IServiceCollection services, string conexionSql, string conexionExactusSql)
        {
            services.AddDbContext<DbContextMsSql>(option => option.UseSqlServer(conexionSql));
            services.AddDbContext<HumanManagementDbContext>(options => options.UseSqlServer(conexionSql));

            services.AddDbContext<ExactusDbContextMsSql>(option => option.UseSqlServer(conexionExactusSql));
            services.AddDbContext<ExactusDbContext>(options => options.UseSqlServer(conexionExactusSql));

            services.AddScoped<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<HumanManagement.Application.Helpers.SessionManager>();
            services.AddScoped<SitePostulant.Application.Helpers.SessionManager>();

            services.AddScoped<IExactusDbContext>(provider => provider.GetService<ExactusDbContext>());
            services.AddScoped<IExactusWriteDbConnection, ExactusWriteDbConnection>();
            services.AddScoped<IExactusReadDbConnection, ExactusReadDbConnection>();

            services.AddScoped<IHumanManagementDbContext>(provider => provider.GetService<HumanManagementDbContext>());
            services.AddScoped<IHumanManagementWriteDbConnection, HumanManagementWriteDbConnection>();
            services.AddScoped<IHumanManagementReadDbConnection, HumanManagementReadDbConnection>();

            services.AddScoped<IExactusEmpleadoService, ExactusEmpleadoService>();
            services.AddScoped<IExactusEmpleadoRepository, ExactusEmpleadoRepository>();
            services.AddScoped<IEmpresaRepository, EmpresaRepository>();

            services.AddScoped<IBaseRepository<Cargo>, BaseRepository<Cargo>>();
            services.AddScoped<IBaseRepository<Areas>, BaseRepository<Areas>>();
            services.AddScoped<IBaseRepository<EmployeeModel>, BaseRepository<EmployeeModel>>();
            services.AddScoped<IBaseRepository<Bank>, BaseRepository<Bank>>();
            services.AddScoped<IBaseRepository<PersonModel>, BaseRepository<PersonModel>>();
            services.AddScoped<IBaseRepository<EmployeeFile>, BaseRepository<EmployeeFile>>();
            services.AddScoped<IBaseRepository<User>, BaseRepository<User>>();
            services.AddScoped<IBaseRepository<Address>, BaseRepository<Address>>();
            services.AddScoped<IBaseRepository<Phone>, BaseRepository<Phone>>();
            services.AddScoped<IBaseRepository<ProfileUser>, BaseRepository<ProfileUser>>();
            


            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IExactusBaseRepository<ExactusEALLEmpleado>, ExactusBaseRepository<ExactusEALLEmpleado>>();

            services.AddScoped<IMasterTableRepository, MasterTableRepository>();
            services.AddScoped<IPersonRepository, PersonRepository>();

            services.AddScoped<IExactusEALLEmpleadoRepository, ExactusEALLEmpleadoRepository>();

            services.AddScoped<IMailRepository, MailRepository>();
            services.AddTransient<IHtmlReader, HtmlReader>();




            services.AddTransient<ICryptography, Cryptography>();

            services.AddAutoMapper(typeof(BuildOperationService));
            services.AddAutoMapper(c => c.AddProfile<AutoMapping>(), typeof(BuildOperationService));

            return services;
        }
    }
}
