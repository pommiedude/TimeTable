using MediatR;

namespace TimeTable.Application.Schedule.Queries.GetScheduleDetail
{
    public class GetScheduleDetailQuery : IRequest<ScheduleDetailModel>
    {
        public int Id { get; set; }
    }
}
