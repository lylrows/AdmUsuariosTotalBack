using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace HumanManagement.Domain.Events
{
    public class DomainEventsContainer : IContainer
    {
        private readonly ServiceProvider _serviceProvider;

        public DomainEventsContainer(ServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public object GetService(Type serviceType)
        {
            return _serviceProvider.GetService(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _serviceProvider.GetServices(serviceType);
        }
    }
}
