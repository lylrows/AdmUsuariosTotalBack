using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using HumanManagementApi.RegisterIoC;
using HumanManagement.Application.Filters;
using HumanManagement.CrossCutting.Utils;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using HumanManagement.Domain.Security.Entities;
using HumanManagement.Domain.Recruitment.Options;

namespace HumanManagementApi
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
            services.Configure<RequestTemplateHtml>(options => Configuration.GetSection("TemplateHtmlRequest").Bind(options));
            services.Configure<IISOptions>(options =>
            {
            });
            services.AddControllers();
            
            services.AddCors(option =>
            {
                option.AddPolicy(name: MyCors, builder =>
                {
                    builder.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                    //builder.AllowAnyHeader()
                    //.AllowAnyMethod()
                    //.SetIsOriginAllowed((Host) => true)
                    //.AllowCredentials();
                });
            });
            services.AddSignalR();

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
            RegisterEvent.ResolveEvents(services);
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
                    );
                endpoints.MapHub<Notifications>("api/cnn");
            });
        }
    }
}
