using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Microsoft.AspNetCore.Http;
using SitePostulantApi.FIlters;
using HumanManagement.MsSql.Context;
using HumanManagement.Domain.Contracts;
using HumanManagement.MsSql.Connections;
using HumanManagement.Domain.Postulant.Security.Contracts;
using HumanManagement.MsSql.Repository.Postulant;
using HumanManagement.Domain.Postulant.Security.Models;
using HumanManagement.Domain.Postulant.Security.Services;
using HumanManagement.Domain.Postulant.Security.Entities;
using HumanManagement.Domain.BaseRepository;
using HumanManagement.MsSql.Repository;
using UserRepository = HumanManagement.MsSql.Repository.Postulant.UserRepository;
using PersonRepository = HumanManagement.MsSql.Repository.Postulant.Person.PersonRepository;
using HumanManagement.Domain.Postulant.Models;
using SitePostulant.Application.Helpers;
using SitePostulant.Application.Filters;
using HumanManagement.Domain.Models;
using SitePostulant.Application.Security.IServices;
using SitePostulant.Application.Security.Services;
using HumanManagement.Domain.Postulant.Person.Models;
using HumanManagement.Domain.Postulant.Person.Contracts;
using HumanManagement.Domain.Mail.Contracts;
using HumanManagement.Mail.Repository;
using SitePostulant.Application.Job.IServices;
using SitePostulant.Application.Job.Services;
using HumanManagement.Domain.Job.Contracts;
using HumanManagement.ReadHtml.HtmlMinifiers;
using HumanManagement.Domain.Job.Models;
using SitePostulant.Application.EducationPostulant.IServices;
using SitePostulant.Application.EducationPostulant.Services;
using SitePostulant.Application.LanguagePostulant.IServices;
using SitePostulant.Application.LanguagePostulant.Services;
using SitePostulant.Application.SkillsPostulant.IServices;
using SitePostulant.Application.SkillsPostulant.Services;
using HumanManagement.Domain.Postulant.Education.Models;
using HumanManagement.Domain.Postulant.Languages.Models;
using HumanManagement.Domain.Postulant.Skills.Models;
using HumanManagement.Domain.Postulant.Education.Contracts;
using HumanManagement.MsSql.Repository.Postulant.Education;
using HumanManagement.Domain.Postulant.Languages.Contracts;
using HumanManagement.MsSql.Repository.Postulant.Language;
using HumanManagement.Domain.Postulant.Skills.Contracts;
using HumanManagement.MsSql.Repository.Postulant.Skills;
using HumanManagement.Domain.MasterTable.Contracts;
using SitePostulant.Application.MasterTable.IServices;
using SitePostulant.Application.MasterTable.Services;
using HumanManagement.Domain.Postulant.WorkExperience.Contracts;
using HumanManagement.MsSql.Repository.Postulant.WorkExperience;
using HumanManagement.Domain.Postulant.WorkExperience.Models;
using SitePostulant.Application.WorkExperience.IService;
using SitePostulant.Application.WorkExperience.Service;
using SitePostulant.Application.Country.IService;
using SitePostulant.Application.Country.Service;
using HumanManagement.Domain.Country.Models;
using SitePostulant.Application.RecruitmentArea.Services;
using SitePostulant.Application.RecruitmentArea.IServices;
using SitePostulant.Application.Skills.IServices;
using SitePostulant.Application.Skills.Service;
using SitePostulant.Application.JobObjective.IService;
using SitePostulant.Application.JobObjective.Service;
using SitePostulant.Application.SalaryPreference.IService;
using SitePostulant.Application.SalaryPreference.Service;
using SitePostulant.Application.Disability.IService;
using SitePostulant.Application.Disability.Service;
using HumanManagement.Domain.Postulant.JobObjective.Models;
using HumanManagement.Domain.Postulant.SalaryPreference.Models;
using HumanManagement.Domain.Postulant.Disability.Models;
using HumanManagement.Domain.Applicants.Contracts;
using HumanManagement.MsSql.Repository.Applicants;
using SitePostulant.Application.Applications.IServices;
using SitePostulant.Application.Applications.Services;
using SitePostulant.Application.Person.IServices;
using SitePostulant.Application.Person.Services;
using HumanManagement.Domain.Utils.Constracts;
using SitePostulant.Application.Util.IServices;
using SitePostulant.Application.Util.Services;
using HumanManagement.Domain.Areas.Contracts;

namespace SitePostulantApi.RegisterIoC
{
    public class Register
    {
        public static void Services(IServiceCollection services, IConfiguration configuration)
        {
           
            #region
            services.AddTransient<ICryptography, Cryptography>();
            services.AddTransient<ITokenGenerator, TokenGenerator>();
            services.AddTransient<IPersonService, PersonService>();
            services.AddTransient<IUtilService, UtilService>();
            services.AddTransient<ISkillsService, SkillsService>();
            services.AddTransient<ITokenUserService, TokenUserService>();
            services.AddTransient<ITokenUserRepository, TokenUserRepository>();
            services.AddTransient<ILoginService, LoginService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ITokenService, TokenService>();
            services.AddTransient<IJobService, JobService>();
            services.AddTransient<IEducationPostulantService, EducationPostulantService>();
            services.AddTransient<ILanguagePostulantService, LanguagePostulantService>();
            services.AddTransient<ISkillsPostulantService, SkillsPostulantService>();
            services.AddTransient<IWorkExperienceService, WorkExperienceService>();
            services.AddTransient<IMasterTableService, MasterTableService>();
            services.AddTransient<IApplicantService, ApplicantService>();
            services.AddTransient<ICountryService, CountryService>();
            services.AddTransient<IJobObjectiveService, JobObjectiveService>();
            services.AddTransient<ISalaryPreferenceService, SalaryPreferenceService>();
            services.AddTransient<IDisabilityService, DisabilityService>();
            services.AddTransient<IHtmlReader, HtmlReader>();
            services.AddTransient<IRecruitmentAreaService, RecruitmentAreaService>();
            services.AddTransient<IPersonService, PersonService>();

            services.AddScoped<IBaseRepository<JobObjectiveModel>, BaseRepository<JobObjectiveModel>>();
            services.AddScoped<IBaseRepository<SalaryPreferenceModel>, BaseRepository<SalaryPreferenceModel>>();
            services.AddScoped<IBaseRepository<DisabilityModel>, BaseRepository<DisabilityModel>>();
            services.AddScoped<IBaseRepository<Country>, BaseRepository<Country>>();
            services.AddScoped<IBaseRepository<WorkExperienceModel>, BaseRepository<WorkExperienceModel>>();
            services.AddScoped<IBaseRepository<EducationPostulant>, BaseRepository<EducationPostulant>>();
            services.AddScoped<IBaseRepository<LanguagePostulant>, BaseRepository<LanguagePostulant>>();
            services.AddScoped<IBaseRepository<SkillsPostulant>, BaseRepository<SkillsPostulant>>();
            services.AddScoped<IBaseRepository<UserPostulant>, BaseRepository<UserPostulant>>();
            services.AddScoped<IBaseRepository<TokenUserPostulant>, BaseRepository<TokenUserPostulant>>();
            services.AddScoped<IBaseRepository<PersonModelPostulant>, BaseRepository<PersonModelPostulant>>();
            services.AddScoped<IBaseRepository<ProfileUserPostulant>, BaseRepository<ProfileUserPostulant>>();

            services.AddScoped<IAreaRepository, AreaRepository>();
            services.AddScoped<IUtilRepository, UtilRepository>();
            services.AddScoped<ISkillsRepository, SkillsRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IMailRepository, MailRepository>();
            services.AddScoped<IProfileUserRepository, ProfileUserRepository>();
            services.AddScoped<IJobRepository, JobRepository>();
            services.AddScoped<IJobPostulantRepository, JobPostulantRepository>();
            services.AddScoped<IBaseRepository<JobPostulant>, BaseRepository<JobPostulant>>();
            services.AddScoped<IEducationPostulantRepository, EducationPostulantRepository>();
            services.AddScoped<ILanguagesPostulantRepository, LanguageRepository>();
            services.AddScoped<ISkillsPostulantRepository, SkillsPostulantRepository>();
            services.AddScoped<IWorkExperienceRepository, WorkExperienceRepository>();
            services.AddScoped<IMasterTableRepository, MasterTableRepository>();
            services.AddScoped<IApplicantRepository, ApplicantRepository>();

            services.AddScoped<IBaseRepository<HumanManagement.Domain.RecruitmentArea.Models.RecruitmentArea>, BaseRepository<HumanManagement.Domain.RecruitmentArea.Models.RecruitmentArea>>();


            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddAutoMapper(typeof(Register));
            services.AddAutoMapper(c => c.AddProfile<AutoMapping>(), typeof(Register));
            #endregion

            services.AddMvc(options =>
            {
                options.Filters.Add<ValidationFilterAsync>();
            }).AddFluentValidation(option =>
            {
                option.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
            });

            services.AddMvcCore(options =>
            {
                options.Filters.Add<ValidationFilterAsync>();
            }).AddFluentValidation(option =>
            {
                option.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
            });

            services.AddMvcCore(option =>
            {
                option.Filters.Add(typeof(CustomAuthorization));
            });
        }

        public static void DataBaseContext(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DbContextMsSql>(option => option.UseSqlServer(
                configuration.GetConnectionString("ConnectionStringSqlServer")));
            services.AddDbContext<HumanManagementDbContext>(options =>
                     options
                     .UseSqlServer(configuration.GetConnectionString("ConnectionStringSqlServer"))
            );
            services.AddScoped<IHumanManagementDbContext>(provider => provider.GetService<HumanManagementDbContext>());
            services.AddScoped<IHumanManagementWriteDbConnection, HumanManagementWriteDbConnection>();
            services.AddScoped<IHumanManagementReadDbConnection, HumanManagementReadDbConnection>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<SessionManager>();
            services.AddScoped<HumanManagement.Application.Helpers.SessionManager>();
        }

        public static void AddOptions(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<TokenOption>(option =>
            {
                configuration.GetSection("TokenOption")
                .Bind(option);
            });
            services.Configure<JwtOptions>(option =>
            {
                configuration.GetSection("jwt")
                .Bind(option);
            });
        }
    }
}
