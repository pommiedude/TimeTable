using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace TimeTable.Application.Hub
{
    public interface ITypedHubClient
    {
        Task BroadcastMessage(string name, List<Domain.Entities.Schedule> schedules);
    }

    public class ScheduleHub : Hub<ITypedHubClient>
    {
        public async Task Send(string nick, List<Domain.Entities.Schedule> schedules)
        {
            await Clients.All.BroadcastMessage("scheduleList", schedules);
        }
    }
}
