using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using TimeTable.Application.Hub;

namespace TimeTable.Application.Infrastructure
{
    public class RequestPostProcessorBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        IHubContext<ScheduleHub, ITypedHubClient> _scheduleUpdateHub;

        public RequestPostProcessorBehavior(IHubContext<ScheduleHub, ITypedHubClient> scheduleUpdateHub)
        {
        }

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            // TODO : Based on the type of command we can send back different notifications to the clients.
            // Delete   - send Id to be trimmed from the clients data
            // Add      - send the new schedule to be added to the clients data

            // Dummy code to send all schedules to the clients
            // List<Domain.Entities.Schedule> schedules = new List<Domain.Entities.Schedule>();
            // _scheduleUpdateHub.Clients.All.BroadcastMessage("updatedSchedule", schedules);

            return next();
        }
    }
}
