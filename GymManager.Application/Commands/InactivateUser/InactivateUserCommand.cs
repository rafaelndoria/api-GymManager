using MediatR;

namespace GymManager.Application.Commands.InactivateUser
{
    public class InactivateUserCommand : IRequest<bool>
    {
        public InactivateUserCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
