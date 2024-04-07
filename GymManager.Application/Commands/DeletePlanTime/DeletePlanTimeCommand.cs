using MediatR;

namespace GymManager.Application.Commands.DeletePlanTime
{
    public class DeletePlanTimeCommand : IRequest<bool>
    {
        public DeletePlanTimeCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
