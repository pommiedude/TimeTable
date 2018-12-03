using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TimeTable.Persistance;

namespace TimeTable.Application.Schedule.Queries.GetScheduleDetail
{
    public class GetScheduleDetailQueryHandler : IRequestHandler<GetScheduleDetailQuery, ScheduleDetailModel>
    {
        private readonly TimeTableContext _context;

        public GetScheduleDetailQueryHandler(TimeTableContext context)
        {
            _context = context;
        }

        public async Task<ScheduleDetailModel> Handle(GetScheduleDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Schedules.FindAsync(request.Id);

            if (entity == null)
                throw new Exception();
            //throw new Exception($"Entity '{nameof(Domain.Entities.Schedule)}' ({request.Id})) was not found.");

            return new ScheduleDetailModel
            {
                ScheduleId = entity.ScheduleId,
                Line = entity.Line,
                Title = entity.Title,
                Date = entity.Date
            };
        }
    }
}
