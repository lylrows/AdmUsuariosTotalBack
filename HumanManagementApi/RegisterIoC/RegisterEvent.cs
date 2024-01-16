using HumanManagement.Domain.Contracts;
using HumanManagement.Domain.Events;
using HumanManagement.Domain.Recruitment.Contracts;
using HumanManagement.Domain.Recruitment.Events;
using HumanManagement.Domain.Security.Events;
using HumanManagement.Domain.StaffRequest.Events;
using HumanManagement.MsSql.Connections;
using HumanManagement.MsSql.Repository.Recruitment;
using Microsoft.Extensions.DependencyInjection;

namespace HumanManagementApi.RegisterIoC
{
    public static class RegisterEvent
    {
        public static void ResolveEvents(IServiceCollection services)
        {
            services.AddScoped<IHumanManagementReadDbConnection, HumanManagementReadDbConnection>();
            services.AddScoped<IRequestMailRepository, RequestMailRepository>();
            services.AddTransient<IEventHandling<UserRegistered>, UserRegisteredHandlerSendEmail>();

            services.AddTransient<IEventHandling<StaffRequestApproved>, StaffRequestApprovedHandlerSend>();
            services.AddTransient<IEventHandling<RequestRegistered>, RequestRegisteredHandlerSendEmail>();
            services.AddTransient<IEventHandling<RequestUpdated>, RequestUpdatedHandlerSendEmail>();
            DomainEvent.Container = new DomainEventsContainer(services.BuildServiceProvider());
        }
    }
}
