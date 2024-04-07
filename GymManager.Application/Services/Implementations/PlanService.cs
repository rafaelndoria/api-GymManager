using GymManager.Application.Services.Interfaces;
using GymManager.Core.Entities;

namespace GymManager.Application.Services.Implementations
{
    public class PlanService : IPlanService
    {
        public bool ValidPlanTime(List<PlanTime> planTimes, string requestStartTime, string requestEndTime)
        {
            TimeSpan newStartTime = TimeSpan.Parse(requestStartTime);
            TimeSpan newEndTime = TimeSpan.Parse(requestEndTime);

            foreach (var existingPlanTime in planTimes)
            {
                TimeSpan existingStartTime = TimeSpan.Parse(existingPlanTime.StartTime);
                TimeSpan existingEndTime = TimeSpan.Parse(existingPlanTime.EndTime);

                if ((newStartTime >= existingStartTime && newStartTime < existingEndTime) ||
                    (newEndTime > existingStartTime && newEndTime <= existingEndTime) ||
                    (newStartTime <= existingStartTime && newEndTime >= existingEndTime))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
