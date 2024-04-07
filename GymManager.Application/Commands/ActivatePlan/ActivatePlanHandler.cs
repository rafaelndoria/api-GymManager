using GymManager.Core.Interfaces;
using MediatR;

namespace GymManager.Application.Commands.ActivatePlan
{
    public class ActivatePlanHandler : IRequestHandler<ActivatePlanCommand, bool>
    {
        private readonly IPlanRepository _planRepository;

        public ActivatePlanHandler(IPlanRepository planRepository)
        {
            _planRepository = planRepository;
        }

        public async Task<bool> Handle(ActivatePlanCommand request, CancellationToken cancellationToken)
        {
            var plan = await _planRepository.GetPlanByIdAsync(request.Id);
            if (plan == null)
                return false;
            plan.Activate();
            await _planRepository.UpdatePlanAsync(plan);
            return true;
        }
    }
}
