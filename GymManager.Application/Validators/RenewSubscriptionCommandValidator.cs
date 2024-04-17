using FluentValidation;
using GymManager.Application.Commands.RenewSubscription;

namespace GymManager.Application.Validators
{
    public class RenewSubscriptionCommandValidator : AbstractValidator<RenewSubscriptionCommand>
    {
        public RenewSubscriptionCommandValidator()
        {
            RuleFor(x => x.TypePaymentId)
                .NotEmpty().WithMessage("The type payment id is required")
                .Must(BeValidTypePayment).WithMessage("Invalid type payment specified. Only (1.CreditCard, 2.DebitCard, 3.PIX, 4.Money)");
        }

        private bool BeValidTypePayment(int typePaymentId)
        {
            if (typePaymentId < 1 || typePaymentId > 4)
                return false;

            return true;
        }
    }
}
