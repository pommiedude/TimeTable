using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace TimeTable.Application.Hub
{
    public interface ITypedHubClient
    {
        Task BroadcastMessage(string type, List<Domain.Entities.Schedule> schedules);
        Task BroadcastMessage(string type, string payload);
    }

    public class ScheduleHub : Hub<ITypedHubClient>
    {
        public async Task Send(string type, string payload)
        {
            await Clients.All.BroadcastMessage(type, payload);
        }

        public async Task Send(string type, List<Domain.Entities.Schedule> schedules)
        {
            await Clients.All.BroadcastMessage("scheduleList", schedules);
        }
    }
}
