using System;
using System.Linq;
using System.Threading.Tasks;
using TimeTable.Domain.Entities;

namespace TimeTable.Persistance
{
    public class ApplicationDbInitializer
    {
        public static async Task Initialize(TimeTableContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Schedules.Any())
            {
                await context.Schedules.AddAsync(new Schedule { Title = "Dandenong", Line = "Dandenong", Date = DateTime.Now });
                await context.Schedules.AddAsync(new Schedule { Title = "Packenham", Line = "Packenham", Date = DateTime.Now });
                await context.Schedules.AddAsync(new Schedule { Title = "Sandringham", Line = "Sandringham", Date = DateTime.Now });
                await context.Schedules.AddAsync(new Schedule { Title = "Frankston", Line = "Frankston", Date = DateTime.Now });
                await context.SaveChangesAsync();
            }
        }
    }
}
