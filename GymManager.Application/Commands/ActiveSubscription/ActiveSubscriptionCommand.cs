using MediatR;

namespace GymManager.Application.Commands.ActiveSubscription
{
    public class ActiveSubscriptionCommand : IRequest<Unit>
    {
        public ActiveSubscriptionCommand(int customerId)
        {
            CustomerId = customerId;
        }

        public int CustomerId { get; private set; }
    }
}
