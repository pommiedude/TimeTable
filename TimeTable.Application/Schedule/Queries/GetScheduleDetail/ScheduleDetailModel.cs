using System;

namespace TimeTable.Application.Schedule.Queries.GetScheduleDetail
{
    public class ScheduleDetailModel
    {
        public int ScheduleId { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Line { get; set; }
    }
}
