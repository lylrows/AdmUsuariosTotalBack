using HumanManagement.Domain.General.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WSHumanManagement.Application.Exactus.Puesto.IServices;
using WSHumanManagement.Application.Exactus.Puesto.Services;

namespace WSExactusHumanManagement.ImportPuesto
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IExactusPuestoLogic exactusPuestoLogic;
        public Worker(ILogger<Worker> logger,
                        IServiceProvider serviceProvider)
        {
            _logger = logger;
            exactusPuestoLogic = serviceProvider.CreateScope().ServiceProvider.GetRequiredService<IExactusPuestoLogic>();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            await base.StopAsync(stoppingToken);

            try
            {
                exactusPuestoLogic.Import();
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
