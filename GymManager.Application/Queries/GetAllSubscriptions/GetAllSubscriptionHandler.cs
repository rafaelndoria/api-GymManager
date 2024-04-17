using GymManager.Application.ViewModels;
using GymManager.Core.Interfaces;
using MediatR;

namespace GymManager.Application.Queries.GetAllSubscriptions
{
    public class GetAllSubscriptionHandler : IRequestHandler<GetAllSubscriptionQuery, IEnumerable<SubscriptionViewModel>>
    {
        private readonly ISubscriptionRepository _subscriptionRepository;

        public GetAllSubscriptionHandler(ISubscriptionRepository subscriptionRepository)
        {
            _subscriptionRepository = subscriptionRepository;
        }

        public async Task<IEnumerable<SubscriptionViewModel>> Handle(GetAllSubscriptionQuery request, CancellationToken cancellationToken)
        {
            var subscriptions = await _subscriptionRepository.GetAllAsync();
            if (subscriptions == null)
                return null;

            var subscriptionsViewModel = subscriptions
                .Select(x => new SubscriptionViewModel(x.Id, 
                                                       x.DateSubscription,
                                                       x.Status, 
                                                       (DateTime)x.AccessPermittedUntil, 
                                                       x.Customer.Name, 
                                                       x.Customer.PhoneNumber, 
                                                       x.Customer.Email));

            return subscriptionsViewModel;
        }
    }
}
