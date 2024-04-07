using GymManager.Application.ViewModels;
using GymManager.Core.Interfaces;
using MediatR;

namespace GymManager.Application.Queries.GetDetailsPlan
{
    public class GetDetailsPlanHandler : IRequestHandler<GetDetailsPlanQuery, PlanDetailsViewModel>
    {
        private readonly IPlanRepository _planRepository;

        public GetDetailsPlanHandler(IPlanRepository planRepository)
        {
            _planRepository = planRepository;
        }

        public async Task<PlanDetailsViewModel> Handle(GetDetailsPlanQuery request, CancellationToken cancellationToken)
        {
            var planDetails = await _planRepository.GetPlanDetailsByIdAsync(request.Id);
            if (planDetails == null)
                return null;

            var planDetailsViewModel = new PlanDetailsViewModel(
                planDetails.Id, planDetails.Name,
                planDetails.Price,
                planDetails.EntriesPerDay,
                planDetails.Active,
                planDetails.DateCreated,
                planDetails.PlanType.Name,
                planDetails.PlanType.PeriodInMonths);

            foreach (var planTime in planDetails.PlanTimes)
            {
                var planTimeAdd = new PlanTimeViewModel(planTime.Id, planTime.Week.Name, planTime.PlanId, planTime.StartTime, planTime.EndTime);
                planDetailsViewModel.PlanTimes.Add(planTimeAdd);
            }
            foreach (var subscription in planDetails.Subscriptions)
            {
                var subscriptionAdd = new SubscriptionViewModel(
                    subscription.Id,
                    subscription.DateSubscription,
                    subscription.Status,
                    (DateTime)subscription.AccessPermittedUntil,
                    subscription.Customer.Name,
                    subscription.Customer.PhoneNumber,
                    subscription.Customer.Email);

                planDetailsViewModel.Subscriptions.Add(subscriptionAdd);
            }

            return planDetailsViewModel;
        }
    }
}
