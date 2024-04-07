using MediatR;

namespace GymManager.Application.Commands.InactivatePlan
{
    public class InactivatePlanCommand : IRequest<bool>
    {
        public InactivatePlanCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
