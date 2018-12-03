using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using TrainTimeTable.Hubs;

namespace TrainTimeTable.Services
{
    public class NotifyService : INotifyService
    {
        private readonly IHubContext<ScheduleHub> _hub;

        public NotifyService(IHubContext<ScheduleHub> hub)
        {
            _hub = hub;
        }

        public Task SendNotificationAsync(string message)
        {
            return _hub.Clients.All.SendAsync("ReceiveMessage", message);
        }
    }

}
