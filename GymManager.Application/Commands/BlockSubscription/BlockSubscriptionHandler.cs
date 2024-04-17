using GymManager.Application.Services.Interfaces;
using GymManager.Core.Interfaces;
using MediatR;

namespace GymManager.Application.Commands.BlockSubscription
{
    public class BlockSubscriptionHandler : IRequestHandler<BlockSubscriptionCommand, Unit>
    {
        private readonly IPlanService _planService;
        private readonly ISubscriptionRepository _subscriptionRepository;

        public BlockSubscriptionHandler(IPlanService planService, ISubscriptionRepository subscriptionRepository)
        {
            _planService = planService;
            _subscriptionRepository = subscriptionRepository;
        }

        public async Task<Unit> Handle(BlockSubscriptionCommand request, CancellationToken cancellationToken)
        {
            var customer = await _planService.GetCustomerVerifyHasPlan(request.CustomerId);
            var subscription = customer.Subscription;
            if (subscription == null)
                throw new Exception("Customer does not have an active subscription");

            subscription.BlockSubscription();
            await _subscriptionRepository.UpdateAsync(subscription);

            return Unit.Value;
        }
    }
}
