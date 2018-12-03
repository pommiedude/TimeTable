using System;

namespace TimeTable.Application.Schedule.Queries.GetScheduleList
{
    public class ScheduleLookupModel
    {
        public int ScheduleId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
    }
}
