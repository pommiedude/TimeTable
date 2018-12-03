using FluentValidation;

namespace TimeTable.Application.Schedule.Commands.DeleteSchedule
{ 
    public class DeleteScheduleCommandValidator : AbstractValidator<DeleteScheduleCommand>
    {
        public DeleteScheduleCommandValidator()
        {
            RuleFor(v => v.Id).GreaterThan(0);
        }
    }
}
