using GymManager.Application.ViewModels;
using GymManager.Core.Interfaces;
using MediatR;

namespace GymManager.Application.Queries.GetPlanById
{
    public class GetPlanByIdHandler : IRequestHandler<GetPlanByIdQuery, PlanViewModel>
    {
        private readonly IPlanRepository _planRepository;

        public GetPlanByIdHandler(IPlanRepository planRepository)
        {
            _planRepository = planRepository;
        }

        public async Task<PlanViewModel> Handle(GetPlanByIdQuery request, CancellationToken cancellationToken)
        {
            var plan = await _planRepository.GetPlanByIdAsync(request.Id);
            if (plan == null)
                return null;

            var planViewModel = new PlanViewModel(plan.Id, plan.Name, plan.Price, plan.EntriesPerDay, plan.Active, plan.DateCreated);
            return planViewModel;   
        }
    }
}
