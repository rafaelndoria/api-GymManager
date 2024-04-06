using MediatR;

namespace GymManager.Application.Commands.LoginUser
{
    public class LoginUserCommand : IRequest<string>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
