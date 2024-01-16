using System;
using System.Collections.Generic;

namespace HumanManagement.Domain.Events
{
    public interface IContainer
    {
        object GetService(Type serviceType);
        IEnumerable<object> GetServices(Type serviceType);
    }
}
