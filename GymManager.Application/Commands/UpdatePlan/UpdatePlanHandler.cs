using GymManager.Core.Interfaces;
using MediatR;

namespace GymManager.Application.Commands.UpdatePlan
{
    public class UpdatePlanHandler : IRequestHandler<UpdatePlanCommand, bool>
    {
        private readonly IPlanRepository _planRepository;

        public UpdatePlanHandler(IPlanRepository planRepository)
        {
            _planRepository = planRepository;
        }

        public async Task<bool> Handle(UpdatePlanCommand request, CancellationToken cancellationToken)
        {
            var plan = await _planRepository.GetPlanByIdAsync((int)request.Id);
            if (plan == null)
                return false;
            plan.Update(request.Name, request.Price, request.EntriesPerDay, request.PlanTypeId);
            await _planRepository.UpdatePlanAsync(plan);
            return true;
        }
    }
}
