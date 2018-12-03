using MediatR;
using System;

namespace TimeTable.Application.Schedule.Commands.CreateSchedule
{
    public class CreateScheduleCommand : IRequest
    {
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Line { get; set; }
    }
}
