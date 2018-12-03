using MediatR;

namespace TimeTable.Application.Schedule.Queries.GetScheduleList
{
    public class GetScheduleListQuery : IRequest<ScheduleListViewModel>
    {
    }
}
