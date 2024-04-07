using FluentValidation;
using GymManager.Application.Commands.CreatePlan;

namespace GymManager.Application.Validators
{
    public class UpdatePlanCommandValidator : AbstractValidator<CreatePlanCommand>
    {
        public UpdatePlanCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotNull().WithMessage("The name is required")
                .MaximumLength(20).WithMessage("The maximum length to name is 20");

            RuleFor(x => x.Price)
                .NotNull().WithMessage("The price is required")
                .GreaterThan(0).WithMessage("The price must be greater than 0"); ;

            RuleFor(x => x.EntriesPerDay)
                .NotNull().WithMessage("The entries per day is required")
                .GreaterThan(0).WithMessage("The entries per day must be greater than 0");

            RuleFor(x => x.PlanTypeId)
                .NotNull().WithMessage("The plan type id is required")
                .GreaterThan(0).WithMessage("The plan type id must be greater than 0");
        }
    }
}
