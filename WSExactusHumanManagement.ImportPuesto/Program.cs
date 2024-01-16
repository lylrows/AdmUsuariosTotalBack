using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.EventLog;
using Serilog;

using WSExactusHumanManagement.ImportPuesto.Provider;

namespace WSExactusHumanManagement.ImportPuesto
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

     

        public static IHostBuilder CreateHostBuilder(string[] args) =>

           Host.CreateDefaultBuilder(args)
               .UseWindowsService()
              .ConfigureLogging(options => options.AddFilter<EventLogLoggerProvider>(level => level >= LogLevel.Information))
               .ConfigureServices((hostContext, services) =>
               {
                   IConfiguration configuration = hostContext.Configuration;
                   Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(hostContext.Configuration).CreateLogger();
                   var conexionSql = configuration.GetConnectionString("ConnectionStringSqlServer");

                   services.AddHostedService<Worker>();


                   services.ConfigureDI(conexionSql)
                   .Configure<EventLogSettings>(config =>
                   {
                       config.LogName = "Logs";
                       config.SourceName = "GRUPOFE_IMPORT_PUESTO";
                   });
               }).UseSerilog((hostContext, services, logger) =>
               {
                   logger.ReadFrom.Configuration(hostContext.Configuration);
               });

    }
}
