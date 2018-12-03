using Microsoft.EntityFrameworkCore;
using TimeTable.Domain.Entities;

namespace TimeTable.Persistance
{
    public class TimeTableContext : DbContext
    {
        public DbSet<Schedule> Schedules { get; set; }

        public TimeTableContext(DbContextOptions<TimeTableContext> options)
            : base(options)
        {
        }
    }
}
