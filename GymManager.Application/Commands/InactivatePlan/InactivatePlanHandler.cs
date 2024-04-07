using GymManager.Core.Interfaces;
using MediatR;

namespace GymManager.Application.Commands.InactivatePlan
{
    public class InactivatePlanHandler : IRequestHandler<InactivatePlanCommand, bool>
    {
        private readonly IPlanRepository _planRepository;

        public InactivatePlanHandler(IPlanRepository planRepository)
        {
            _planRepository = planRepository;
        }

        public async Task<bool> Handle(InactivatePlanCommand request, CancellationToken cancellationToken)
        {
            var plan = await _planRepository.GetPlanByIdAsync(request.Id);
            if (plan == null)
                return false;
            plan.Inactivate();
            await _planRepository.UpdatePlanAsync(plan);
            return true;
        }
    }
}
