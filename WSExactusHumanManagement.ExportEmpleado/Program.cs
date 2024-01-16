using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging.EventLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSExactusHumanManagement.ExportEmpleado.Provider;

namespace WSExactusHumanManagement.ExportEmpleado
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

              .ConfigureServices((hostContext, services) =>
              {
                  IConfiguration configuration = hostContext.Configuration;
                  var conexionSql = configuration.GetConnectionString("ConnectionStringSqlServer");
                  var conexionExactusSql = configuration.GetConnectionString("ConnectionStringExactusBd"); 

                  services.AddHostedService<Worker>();


                  services.ConfigureDI(conexionSql, conexionExactusSql)
                  .Configure<EventLogSettings>(config =>
                  {
                      config.LogName = "Logs";
                      config.SourceName = "GRUPOFE_EXPORT_EMPLEADO";

                  });



              });
    }
}
