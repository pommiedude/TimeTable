using MediatR;

namespace TimeTable.Application.Schedule.Commands.DeleteSchedule
{
    public class DeleteScheduleCommand : IRequest
    {
        public int Id { get; set; }
    }
}
