using System;
using FluentValidation;

namespace TimeTable.Application.Schedule.Commands.CreateSchedule
{
    public class CreateScheduleCommandValidator : AbstractValidator<CreateScheduleCommand>
    {
        public CreateScheduleCommandValidator()
        {
            RuleFor(x => x.Title).MinimumLength(5).NotEmpty();
            RuleFor(x => x.Line).MinimumLength(10).NotEmpty();
        }
    }
}
