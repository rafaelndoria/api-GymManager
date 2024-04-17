using GymManager.Core.Entities;

namespace GymManager.Application.Services.Interfaces
{
    public interface IPlanService
    {
        bool ValidPlanTime(List<PlanTime> planTimes, string requestStartTime, string requestEndTime);
        Task<Customer> GetCustomerVerifyHasPlan(int customerId);
    }
}
