using GymManager.Application.Services.Interfaces;
using GymManager.Core.Entities;
using GymManager.Core.Interfaces;
using MediatR;

namespace GymManager.Application.Commands.AddPlanTime
{
    public class AddPlanTimeHandler : IRequestHandler<AddPlanTimeCommand, bool>
    {
        private readonly IPlanRepository _planRepository;
        private readonly IPlanService _planService;

        public AddPlanTimeHandler(IPlanRepository planRepository, IPlanService planService)
        {
            _planRepository = planRepository;
            _planService = planService;
        }

        public async Task<bool> Handle(AddPlanTimeCommand request, CancellationToken cancellationToken)
        {
            var planTimes = await _planRepository.GetAllPlanTimeByIdPlanAsync(request.PlanId, request.DayWeekId);

            if (planTimes != null)
            {
                if (!_planService.ValidPlanTime(planTimes, request.StartTime, request.EndTime))
                    return false;
            }

            var planTime = new PlanTime(request.StartTime, request.EndTime, request.DayWeekId, request.PlanId);
            await _planRepository.CreatePlanTimeAsync(planTime);

            return true;
        }
    }
}
