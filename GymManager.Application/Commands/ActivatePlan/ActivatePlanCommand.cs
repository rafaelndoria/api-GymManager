using MediatR;

namespace GymManager.Application.Commands.ActivatePlan
{
    public class ActivatePlanCommand : IRequest<bool>
    {
        public ActivatePlanCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
