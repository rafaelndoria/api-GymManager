using GymManager.Application.ViewModels;
using GymManager.Core.Interfaces;
using MediatR;

namespace GymManager.Application.Queries.GetAllPlans
{
    public class GetAllPlansHandler : IRequestHandler<GetAllPlansQuery, IEnumerable<PlanViewModel>>
    {
        private readonly IPlanRepository _planRepository;

        public GetAllPlansHandler(IPlanRepository planRepository)
        {
            _planRepository = planRepository;
        }

        public async Task<IEnumerable<PlanViewModel>> Handle(GetAllPlansQuery request, CancellationToken cancellationToken)
        {
            var plans = await _planRepository.GetAllPlansAsync(request.Query);
            if (plans == null)
                return null;

            var planViewModel = plans
                .Select(x => new PlanViewModel(x.Id, x.Name, x.Price, x.EntriesPerDay, x.Active, x.DateCreated)).ToList();

            return planViewModel;
        }
    }
}
