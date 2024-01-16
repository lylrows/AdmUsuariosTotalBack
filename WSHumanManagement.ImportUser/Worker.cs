using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HumanManagement.Application.ImportEmployeeService;
using HumanManagement.Domain.General.Contracts;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WSHumanManagement.Application.ImportUser;

namespace WSHumanManagement.ImportUser
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly ImportUserService importUserService;
        private readonly ICoreParameterRepository coreParameterRepository;
        private readonly IImportEmployeeService importEmployeeService;
        public Worker(ILogger<Worker> logger, 
                        ICoreParameterRepository coreParameterRepository,
                        IImportEmployeeService importEmployeeService)
        {
            _logger = logger;
            importUserService = new ImportUserService(coreParameterRepository, importEmployeeService);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    importUserService.Start();
                }
                catch
                {
                    _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                }
                finally
                {
                    await Task.Delay(1000, stoppingToken);
                }
            }
        }
    }
}
