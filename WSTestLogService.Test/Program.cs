using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging.EventLog;
using Microsoft.Extensions.Logging;
using Serilog;

namespace WSTestLogService.Test
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
           Host.CreateDefaultBuilder(args)
               
               .ConfigureLogging(options => options.AddFilter<EventLogLoggerProvider>(level => level >= LogLevel.Information))
               .ConfigureServices((hostContext, services) =>
               {
                   IConfiguration configuration = hostContext.Configuration;
                   Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(hostContext.Configuration).CreateLogger();
                   var conexion = configuration.GetConnectionString("BDFacturacion");
                   services.AddHostedService<Worker>();
                   
                   services.AddHostedService<Worker>()
                       .Configure<EventLogSettings>(config =>
                       {
                           config.LogName = "Logs";
                           config.SourceName = "TAM_FE_SAP_FACTBOL";

                       });
                   

               })
               .UseSerilog((hostContext, services, logger) => {
                   logger.ReadFrom.Configuration(hostContext.Configuration);
               });

    }
}
