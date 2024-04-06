using FluentValidation;
using GymManager.Application.Commands.LoginUser;

namespace GymManager.Application.Validators
{
    public class LoginUserCommandValidator : AbstractValidator<LoginUserCommand>
    {
        public LoginUserCommandValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("The user name is required")
                .MaximumLength(20).WithMessage("The user name cannot be longer than 20 characters");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("The password is required")
                .MaximumLength(20).WithMessage("The password cannot be longer than 30 characters")
                .MinimumLength(6).WithMessage("The minimum password is 6 characters");
        }
    }
}
