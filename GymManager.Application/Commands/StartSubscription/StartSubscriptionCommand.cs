using MediatR;

namespace GymManager.Application.Commands.StartSubscription
{
    public class StartSubscriptionCommand : IRequest<Unit>
    {
        public int TypePaymentId { get; set; }
        public int? CustomerId { get; set; }
    }
}
