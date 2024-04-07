using GymManager.Core.Entities;
using GymManager.Core.Interfaces;
using GymManager.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace GymManager.Infrastructure.Repositories
{
    public class PlanRepository : IPlanRepository
    {
        private readonly ApplicationDbContext _context;

        public PlanRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreatePlanAsync(Plan plan)
        {
            _context.Plans.Add(plan);
            await _context.SaveChangesAsync();
            return plan.Id;
        }

        public async Task CreatePlanTimeAsync(PlanTime planTime)
        {
            _context.PlanTime.Add(planTime);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePlanTimeAsync(PlanTime planTime)
        {
            _context.PlanTime.Remove(planTime);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Week>> GetAllDayOfWeekAsync()
        {
            return await _context.Weeks.ToListAsync();
        }

        public async Task<List<Plan>> GetAllPlansAsync(string query)
        {
            return await _context.Plans.ToListAsync();
        }

        public async Task<List<PlanType>> GetAllPlansTypeAsync()
        {
            return await _context.PlanType.ToListAsync();
        }

        public async Task<List<PlanTime>> GetAllPlanTimeByIdPlanAsync(int id, int? dayWeek = 0)
        {
            List<PlanTime> planTimes = null;
            if (dayWeek == 0)
            {
                planTimes = await _context.PlanTime.Include(x => x.Week).Where(x => x.PlanId == id).ToListAsync();
            }
            else
            {
                planTimes = await _context.PlanTime.Include(x => x.Week).Where(x => x.PlanId == id && x.WeekId == dayWeek).ToListAsync();
            }
            return planTimes;
        }

        public async Task<Plan> GetPlanByIdAsync(int id)
        {
            return await _context.Plans.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Plan> GetPlanDetailsByIdAsync(int id)
        {
            return await _context.Plans
                .Include(x => x.PlanType)
                .Include(x => x.PlanTimes)
                    .ThenInclude(x => x.Week)
                .Include(x => x.Subscriptions)
                    .ThenInclude(x => x.Customer)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<PlanTime> GetPlanTimeByIdAsync(int id)
        {
            return await _context.PlanTime.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdatePlanAsync(Plan plan)
        {
            _context.Plans.Update(plan);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePlanTimeAsync(PlanTime planTime)
        {
            _context.PlanTime.Update(planTime);
            await _context.SaveChangesAsync();
        }
    }
}
