using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using TrainTimeTable.Controllers;

namespace TrainTimeTable.Hubs
{
    public interface ITypedHubClient
    {
        Task BroadcastMessage(string name, string message);
    }

    public class ScheduleHub : Hub<ITypedHubClient>
    {
        public async Task Send(string nick, string message)
        {
            await Clients.All.BroadcastMessage("scheduleList", "scheduleList message b");
        }
    }
}
