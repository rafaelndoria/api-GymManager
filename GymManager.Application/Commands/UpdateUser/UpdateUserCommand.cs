using MediatR;

namespace GymManager.Application.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
