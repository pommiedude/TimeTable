using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TimeTable.Persistance;

namespace TimeTable.Application.Schedule.Queries.GetScheduleList
{
    public class GetScheduleListQueryHandler : IRequestHandler<GetScheduleListQuery, ScheduleListViewModel>
    {
        private readonly TimeTableContext _context;

        public GetScheduleListQueryHandler(TimeTableContext context)
        {
            _context = context;
        }

        public async Task<ScheduleListViewModel> Handle(GetScheduleListQuery request, CancellationToken cancellationToken)
        {
            var vm = new ScheduleListViewModel
            {
                Schedules = await _context.Schedules.Select(c =>
                    new ScheduleLookupModel
                    {
                        ScheduleId = c.ScheduleId,
                        Name = c.Line,
                        Date = c.Date
                    }).ToListAsync(cancellationToken)
            };
            return vm;
        }
    }
}
