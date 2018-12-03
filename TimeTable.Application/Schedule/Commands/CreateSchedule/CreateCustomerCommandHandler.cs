using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TimeTable.Persistance;

namespace TimeTable.Application.Schedule.Commands.CreateSchedule
{
    public class CreateScheduleCommandHandler : IRequestHandler<CreateScheduleCommand, Unit>
    {
        private readonly TimeTableContext _context;

        public CreateScheduleCommandHandler(TimeTableContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateScheduleCommand request, CancellationToken cancellationToken)
        {
            var entity = new Domain.Entities.Schedule
            {
                Title = request.Title,
                Line = request.Line,
                Date = request.Date
            };

            _context.Schedules.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
