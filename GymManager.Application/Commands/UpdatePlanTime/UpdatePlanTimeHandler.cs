using GymManager.Application.Services.Interfaces;
using GymManager.Core.Entities;
using GymManager.Core.Interfaces;
using MediatR;

namespace GymManager.Application.Commands.UpdatePlanTime
{
    public class UpdatePlanTimeHandler : IRequestHandler<UpdatePlanTimeCommand, bool>
    {
        private readonly IPlanRepository _planRepository;
        private readonly IPlanService _planService;

        public UpdatePlanTimeHandler(IPlanRepository planRepository, IPlanService planService)
        {
            _planRepository = planRepository;
            _planService = planService;
        }

        public async Task<bool> Handle(UpdatePlanTimeCommand request, CancellationToken cancellationToken)
        {
            var planTime = await _planRepository.GetPlanTimeByIdAsync((int)request.PlanTimeId);

            if (planTime == null)
                return false;

            var planTimes = (await _planRepository.GetAllPlanTimeByIdPlanAsync(request.PlanId, planTime.WeekId));
            planTimes.Remove(planTime);

            if (!_planService.ValidPlanTime(planTimes, request.StartTime, request.EndTime))
                return false;

            planTime.Update(request.StartTime, request.EndTime);
            await _planRepository.UpdatePlanTimeAsync(planTime);

            return true;
        }
    }
}
