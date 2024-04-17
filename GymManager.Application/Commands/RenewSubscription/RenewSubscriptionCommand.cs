using MediatR;

namespace GymManager.Application.Commands.RenewSubscription
{
    public class RenewSubscriptionCommand : IRequest<Unit>
    {
        public int TypePaymentId { get; set; }
        public int? CustomerId { get; set; }
    }
}
