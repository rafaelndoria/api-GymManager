using GymManager.Application.ViewModels;
using GymManager.Core.Interfaces;
using MediatR;

namespace GymManager.Application.Queries.GetSubscriptionById
{
    public class GetSubscriptionByIdHandler : IRequestHandler<GetSubscriptionByIdQuery, SubscriptionViewModel>
    {
        private readonly ISubscriptionRepository _subscriptionRepository;

        public GetSubscriptionByIdHandler(ISubscriptionRepository subscriptionRepository)
        {
            _subscriptionRepository = subscriptionRepository;
        }

        public async Task<SubscriptionViewModel> Handle(GetSubscriptionByIdQuery request, CancellationToken cancellationToken)
        {
            var subscription = await _subscriptionRepository.GetByIdAsync(request.Id);
            if (subscription == null)
                return null;

            var subscriptionViewModel = new SubscriptionViewModel(subscription.Id,
                                                                  subscription.DateSubscription,
                                                                  subscription.Status,
                                                                  (DateTime)subscription.AccessPermittedUntil,
                                                                  subscription.Customer.Name,
                                                                  subscription.Customer.PhoneNumber,
                                                                  subscription.Customer.Email);

            return subscriptionViewModel;
        }
    }
}
