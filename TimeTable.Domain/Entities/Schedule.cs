using System;

namespace TimeTable.Domain.Entities
{
    public class Schedule
    {
        public int ScheduleId { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Line { get; set; }
    }
}
