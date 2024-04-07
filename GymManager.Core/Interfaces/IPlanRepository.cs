using GymManager.Core.Entities;

namespace GymManager.Core.Interfaces
{
    public interface IPlanRepository
    {
        Task<List<PlanType>> GetAllPlansTypeAsync();
        Task<List<PlanTime>> GetAllPlanTimeByIdPlanAsync(int id, int? dayWeek = 0);
        Task<List<Plan>> GetAllPlansAsync(string query);
        Task<Plan> GetPlanByIdAsync(int id);
        Task<Plan> GetPlanDetailsByIdAsync(int id);
        Task<PlanTime> GetPlanTimeByIdAsync(int id);
        Task<IEnumerable<Week>> GetAllDayOfWeekAsync();
        Task<int> CreatePlanAsync(Plan plan);
        Task UpdatePlanAsync(Plan plan);
        Task CreatePlanTimeAsync(PlanTime planTime);
        Task UpdatePlanTimeAsync(PlanTime planTime);
        Task DeletePlanTimeAsync(PlanTime planTime);
    }
}
