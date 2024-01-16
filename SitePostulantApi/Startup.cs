using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using SitePostulantApi.RegisterIoC;
using TokenOption = HumanManagement.Domain.Postulant.Security.Entities.TokenOption;
using SitePostulant.Application.Filters;
using HumanManagement.CrossCutting.Utils;

namespace SitePostulantApi
{
    public class Startup
    {
        private readonly string MyCors = "AllowCors";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        
        public void ConfigureServices(IServiceCollection services)
        {
            var appSettingsSection = Configuration.GetSection("AppSettings");
            var appSettings = appSettingsSection.Get<AppSettings>();

            services.Configure<AppSettings>(appSettingsSection);
            services.Configure<IISOptions>(options =>
            {
            });
            services.AddControllers();

            services.AddCors(option =>
            {
                option.AddPolicy(name: MyCors, builder =>
                {
                    //builder.WithOrigins(appSettings.SiteGrupoFeSeguro)
                    //.AllowAnyHeader()
                    //.AllowAnyMethod();

                    builder.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });

            var tokenOptionSection = Configuration.GetSection("TokenOption");
            var tokenOption = tokenOptionSection.Get<TokenOption>();
            var key = Encoding.ASCII.GetBytes(tokenOption.Secret);
            services.AddAuthentication(setup =>
            {
                setup.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                setup.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                }); ;

            services.AddMvcCore(option =>
            {
                option.Filters.Add(typeof(CustomExceptionFilter));
            });

            services.AddMvc().AddSessionStateTempDataProvider();
            services.AddSession();

            Register.AddOptions(services, Configuration);
            Register.Services(services, Configuration);
        
            Register.DataBaseContext(services, Configuration);
        }

        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            string pathLog = Configuration.GetSection("AppSettings:PathLog").Value;
            loggerFactory.AddFile(pathLog);
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseRouting();
            app.UseSession();
            app.UseCors(MyCors);
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                    ); ;
            });
        }
    }
}
