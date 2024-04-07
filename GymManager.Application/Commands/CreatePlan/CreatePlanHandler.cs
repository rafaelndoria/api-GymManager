using GymManager.Core.Entities;
using GymManager.Core.Interfaces;
using MediatR;

namespace GymManager.Application.Commands.CreatePlan
{
    public class CreatePlanHandler : IRequestHandler<CreatePlanCommand, int>
    {
        private readonly IPlanRepository _planRepository;

        public CreatePlanHandler(IPlanRepository planRepository)
        {
            _planRepository = planRepository;
        }

        public async Task<int> Handle(CreatePlanCommand request, CancellationToken cancellationToken)
        {
            var plan = new Plan(request.Name, request.Price, request.EntriesPerDay, request.PlanTypeId);
            var planId = await _planRepository.CreatePlanAsync(plan);
            return planId != 0 ? planId : 0;
        }
    }
}
