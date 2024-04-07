using GymManager.Application.ViewModels;
using GymManager.Core.Interfaces;
using MediatR;

namespace GymManager.Application.Queries.GetAllDayOfWeek
{
    public class GetAllDayOfWeekHandler : IRequestHandler<GetAllDayOfWeekQuery, IEnumerable<DayOfWeekViewModel>>
    {
        private readonly IPlanRepository _planRepository;

        public GetAllDayOfWeekHandler(IPlanRepository planRepository)
        {
            _planRepository = planRepository;
        }

        public async Task<IEnumerable<DayOfWeekViewModel>> Handle(GetAllDayOfWeekQuery request, CancellationToken cancellationToken)
        {
            var dayOfWeek = await _planRepository.GetAllDayOfWeekAsync();
            var dayOfWeekViewModel = dayOfWeek.Select(x => new DayOfWeekViewModel(x.Id, x.Name)).ToList();
            return dayOfWeekViewModel;
        }
    }
}
