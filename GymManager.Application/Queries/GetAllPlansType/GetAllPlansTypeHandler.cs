using GymManager.Application.ViewModels;
using GymManager.Core.Interfaces;
using MediatR;

namespace GymManager.Application.Queries.GetAllPlansType
{
    public class GetAllPlansTypeHandler : IRequestHandler<GetAllPlansTypeQuery, IEnumerable<PlansTypeViewModel>>
    {
        private readonly IPlanRepository _planRepository;

        public GetAllPlansTypeHandler(IPlanRepository planRepository)
        {
            _planRepository = planRepository;
        }

        public async Task<IEnumerable<PlansTypeViewModel>> Handle(GetAllPlansTypeQuery request, CancellationToken cancellationToken)
        {
            var plansType = await _planRepository.GetAllPlansTypeAsync();

            if (plansType == null)
                return null;

            var plansTypeViewModel = plansType.Select(x => new PlansTypeViewModel(x.Id, x.Name, x.PeriodInMonths));
            return plansTypeViewModel;
        }
    }
}
