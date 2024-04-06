using FluentValidation;
using GymManager.Application.Commands.UpdateUser;

namespace GymManager.Application.Validators
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("The user name is required")
                .MaximumLength(20).WithMessage("The user name cannot be longer than 20 characters");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("The password is required")
                .MaximumLength(20).WithMessage("The password cannot be longer than 30 characters")
                .MinimumLength(6).WithMessage("The minimum password is 6 characters");

            RuleFor(x => x.Role)
                .NotEmpty().WithMessage("The role is required")
                .Must(BeValidRole).WithMessage("Invalid role specified. Only (Admin, Customer, Manager)");
        }

        private bool BeValidRole(string role)
        {
            var validRoles = new List<string> { "admin", "customer", "manager" };
            return validRoles.Contains(role.ToLower());
        }
    }
}
