using GymManager.Application.Services.Interfaces;
using GymManager.Core.Entities;
using GymManager.Core.Interfaces;
using MediatR;

namespace GymManager.Application.Commands.StartSubscription
{
    public class StartSubscriptionHandler : IRequestHandler<StartSubscriptionCommand, Unit>
    {
        private readonly ISubscriptionRepository _subscriptionRepository;
        private readonly IPaymentRepository _paymentRepository;
        private readonly IPlanService _planService;

        public StartSubscriptionHandler(ISubscriptionRepository subscriptionRepository, IPaymentRepository paymentRepository, IPlanService planService)
        {
            _subscriptionRepository = subscriptionRepository;
            _paymentRepository = paymentRepository;
            _planService = planService;
        }

        public async Task<Unit> Handle(StartSubscriptionCommand request, CancellationToken cancellationToken)
        {
            var customer = await _planService.GetCustomerVerifyHasPlan((int)request.CustomerId);
            
            var periodInMonths = customer.Plan.PlanType.PeriodInMonths;
            var valuePlan = customer.Plan.Price;
            var planId = customer.PlanId;

            if (customer.Subscription != null)
                throw new Exception("Customer contains an subscription");

            var subscription = new Subscription(customer.Id, planId);

            subscription.StartSubscription(periodInMonths);

            var payment = new Payment(valuePlan, request.TypePaymentId, customer.Id);

            await _subscriptionRepository.CreateAsync(subscription);
            await _paymentRepository.CreateAsync(payment);

            return Unit.Value;
        }
    }
}
