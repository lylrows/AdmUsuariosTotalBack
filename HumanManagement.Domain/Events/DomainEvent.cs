using System.Threading.Tasks;

namespace HumanManagement.Domain.Events
{
    public class DomainEvent
    {
        public static IContainer Container { get; set; }

        public static void Raise<T>(T args) where T : IDomainEvent
        {
            if (Container != null)
            {
                foreach (var handler in Container.GetServices(typeof(IEventHandling<T>)))
                    Task.Run(() => ((IEventHandling<T>)handler).Handler(args));
            }
        }
    }
}
