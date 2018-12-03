using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TimeTable.Persistance;

namespace TimeTable.Application.Schedule.Commands.DeleteSchedule
{
    public class DeleteScheduleCommandHandler : IRequestHandler<DeleteScheduleCommand>
    {
        private readonly TimeTableContext _context;

        public DeleteScheduleCommandHandler(TimeTableContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteScheduleCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Schedules.FindAsync(request.Id);

            if (entity == null)
            {
                throw new Exception($"Could not find the {nameof(Schedule)} with the identifier {request.Id}");
            }

            _context.Schedules.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
