using MediatR;

namespace GymManager.Application.Commands.ActivateUser
{
    public class ActivateUserCommand : IRequest<bool>
    {
        public ActivateUserCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
