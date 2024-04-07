using GymManager.Application.ViewModels;
using GymManager.Core.Interfaces;
using MediatR;

namespace GymManager.Application.Queries.GetPlanTimeByIdPlan
{
    public class GetPlanTimeByIdPlanHandler : IRequestHandler<GetPlanTimeByIdPlanQuery, IEnumerable<PlanTimeViewModel>>
    {
        private readonly IPlanRepository _planRepository;

        public GetPlanTimeByIdPlanHandler(IPlanRepository planRepository)
        {
            _planRepository = planRepository;
        }

        public async Task<IEnumerable<PlanTimeViewModel>> Handle(GetPlanTimeByIdPlanQuery request, CancellationToken cancellationToken)
        {
            var planTimes = await _planRepository.GetAllPlanTimeByIdPlanAsync(request.Id);
            if (planTimes == null)
                return null;

            var planTimeViewModel = planTimes
                .Select(x => new PlanTimeViewModel(x.Id, x.Week.Name, x.PlanId, x.StartTime, x.EndTime)).ToList();
            return planTimeViewModel;
        }
    }
}
