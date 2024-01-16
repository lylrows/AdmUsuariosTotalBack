using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WSHumanManagement.Application.Exactus.Empleado.IServices;

namespace WSExactusHumanManagement.ImportEmpleado
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IExactusEmpleadoService exactusEmpleadoService;
        public Worker(ILogger<Worker> logger,
                        IServiceProvider serviceProvider)
        {
            _logger = logger;
            exactusEmpleadoService = serviceProvider.CreateScope().ServiceProvider.GetRequiredService<IExactusEmpleadoService>();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            await base.StopAsync(stoppingToken);

            try
            {
                exactusEmpleadoService.Import();
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            }
            finally
            {
                await Task.Delay(600000);
                await base.StartAsync(stoppingToken);
            }

        }
    }
}
