using FluentValidation;
using GymManager.Application.Commands.UpdatePlanTime;

namespace GymManager.Application.Validators
{
    public class UpdatePlanTimeCommandValidator : AbstractValidator<UpdatePlanTimeCommand>
    {
        public UpdatePlanTimeCommandValidator()
        {
            RuleFor(x => x.PlanId)
                .NotNull().WithMessage("The plan id is required")
                .GreaterThan(0).WithMessage("The plan id must be greater than 0");

            RuleFor(x => x.StartTime)
                .NotNull().WithMessage("The start time is required")
                .MaximumLength(5).WithMessage("The start time must be in the format HH:mm")
                .Must(IsValidTime).WithMessage("The start time is invalid. Format HH:mm");

            RuleFor(x => x.EndTime)
                .NotNull().WithMessage("The end time is required")
                .MaximumLength(5).WithMessage("The end time must be in the format HH:mm")
                .Must(IsValidTime).WithMessage("The end time is invalid. Format HH:mm")
                .Must((command, endTime) => IsEndTimeValid(command.StartTime, endTime))
                    .WithMessage("The end time must be greater than the start time");
        }

        private bool IsValidTime(string time)
        {
            TimeSpan result;
            if (TimeSpan.TryParseExact(time, @"hh\:mm", System.Globalization.CultureInfo.InvariantCulture, out result))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool IsEndTimeValid(string startTime, string endTime)
        {
            TimeSpan start, end;
            if (TimeSpan.TryParseExact(startTime, @"hh\:mm", System.Globalization.CultureInfo.InvariantCulture, out start) &&
                TimeSpan.TryParseExact(endTime, @"hh\:mm", System.Globalization.CultureInfo.InvariantCulture, out end))
            {
                return end > start;
            }
            return false;
        }
    }
}
