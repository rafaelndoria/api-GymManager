using FluentValidation;
using GymManager.Application.Commands.StartSubscription;

namespace GymManager.Application.Validators
{
    public class StartSubscriptionCommandValidator :  AbstractValidator<StartSubscriptionCommand>
    {
        public StartSubscriptionCommandValidator()
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
