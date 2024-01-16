using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WSHumanManagement.Application.Exactus.Nomina.IServices;

namespace WSExactusHumanManagement.ImportNomina
{


    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IExactusNominaService exactusNominaService;
        public Worker(ILogger<Worker> logger,
                        IServiceProvider serviceProvider)
        {
            _logger = logger;
            exactusNominaService = serviceProvider.CreateScope().ServiceProvider.GetRequiredService<IExactusNominaService>();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            await base.StopAsync(stoppingToken);

            try
            {
                exactusNominaService.Import();
                //exactusNominaService.ImportLiquidacion();
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            }
            finally
            {
                await Task.Delay(TimeSpan.FromHours(24));
                await base.StartAsync(stoppingToken);
            }

        }
    }
}
