using FluentValidation;
using GymManager.Application.Commands.EntryCustomer;

namespace GymManager.Application.Validators
{
    public class EntryCustomerCommandValidator : AbstractValidator<EntryCustomerCommand>
    {
        public EntryCustomerCommandValidator()
        {
            RuleFor(x => x.Cpf)
                .NotNull().WithMessage("The cpf is required")
                .MaximumLength(11).WithMessage("The max length is 11")
                .MinimumLength(11).WithMessage("The min length is 11");
        }
    }
}
