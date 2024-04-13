using FluentValidation;
using GymManager.Application.Commands.UpdateCustomer;

namespace GymManager.Application.Validators
{
    public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
    {
        public UpdateCustomerCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("The name is required")
                .MaximumLength(80).WithMessage("The maximum length for name is 80")
                .MinimumLength(2).WithMessage("The minimum length for name is 2");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("The email is required")
                .EmailAddress().WithMessage("The email is invalid");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("The phone number is required")
                .Length(14).WithMessage("The phone number must be exactly 14 characteres. Format: +55(XX)9XXXXYYYY");

            RuleFor(x => x.PlanId)
                .NotNull().WithMessage("The plan id is required")
                .GreaterThan(0).WithMessage("The plan id must have more than zero characters");
        }
    }
}
