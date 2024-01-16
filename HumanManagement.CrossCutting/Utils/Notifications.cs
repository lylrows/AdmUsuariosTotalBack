using Microsoft.AspNetCore.SignalR;

using System.Threading.Tasks;

namespace HumanManagement.CrossCutting.Utils
{
    public class Notifications : Hub
    {
        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }
        public Task NotificationAll(string mensaje)
        {
            return Clients.All.SendAsync("send-notification", mensaje);
        }
    }
}
