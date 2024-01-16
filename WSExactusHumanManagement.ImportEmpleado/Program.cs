using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.EventLog;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSExactusHumanManagement.ImportEmpleado.Provider;

namespace WSExactusHumanManagement.ImportEmpleado
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
                  var conexionExactusSql = configuration.GetConnectionString("ConnectionStringExactusBd");

                  services.AddHostedService<Worker>();


                  services.ConfigureDI(conexionSql,conexionExactusSql)
                  .Configure<EventLogSettings>(config =>
                  {
                      config.LogName = "Logs";
                      config.SourceName = "GRUPOFE_IMPORT_EMPLEADO";

                  });
              }).UseSerilog((hostContext, services, logger) =>
              {
                  logger.ReadFrom.Configuration(hostContext.Configuration);
              });
    }
}
