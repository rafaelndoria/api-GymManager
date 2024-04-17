using MediatR;

namespace GymManager.Application.Commands.BlockSubscription
{
    public class BlockSubscriptionCommand : IRequest<Unit>
    {
        public BlockSubscriptionCommand(int customerId)
        {
            CustomerId = customerId;
        }

        public int CustomerId { get; private set; }
    }
}
