using GymManager.Application.Services.Interfaces;
using GymManager.Core.Entities;
using GymManager.Core.Interfaces;
using MediatR;

namespace GymManager.Application.Commands.RenewSubscription
{
    public class RenewSubscriptionHandler : IRequestHandler<RenewSubscriptionCommand, Unit>
    {
        private readonly IPlanService _planService;
        private readonly ISubscriptionRepository _subscriptionRepository;
        private readonly IPaymentRepository _paymentRepository;

        public RenewSubscriptionHandler(IPlanService planService, ISubscriptionRepository subscriptionRepository, IPaymentRepository paymentRepository)
        {
            _planService = planService;
            _subscriptionRepository = subscriptionRepository;
            _paymentRepository = paymentRepository;
        }

        public async Task<Unit> Handle(RenewSubscriptionCommand request, CancellationToken cancellationToken)
        {
            var customer = await _planService.GetCustomerVerifyHasPlan((int)request.CustomerId);
    
            if (customer.Subscription == null)
                throw new Exception("Customer does not have an active subscription");

            var subscription = customer.Subscription;
            var periodInMonths = customer.Plan.PlanType.PeriodInMonths;
            var pricePlan = customer.Plan.Price;

            subscription.RenewSubscription(periodInMonths);

            var payment = new Payment(pricePlan, request.TypePaymentId, customer.Id);

            await _subscriptionRepository.UpdateAsync(subscription);
            await _paymentRepository.CreateAsync(payment);

            return Unit.Value;
        }
    }
}
