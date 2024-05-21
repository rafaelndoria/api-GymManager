using GymManager.Application.Services.Interfaces;
using GymManager.Core.Entities;

namespace GymManager.Application.Services.Implementations
{
    public class EntryService : IEntryService
    {
        public Entry IsExit(Customer customer)
        {
            var lastEntry = customer.Entries.OrderByDescending(x => x.Id).First();
            if (lastEntry == null)
                return null;
            if (lastEntry.TimeOn != null)
                return null;
            return lastEntry;
        }

        public void VerifyEntryCustomer(Customer customer)
        {
            var now = DateTime.Now;
            var dayWeek = (int)now.DayOfWeek + 1;
            var timeIn = now.TimeOfDay;

            var planTimes = customer.Plan.PlanTimes;
            if (planTimes == null || !planTimes.Any())
                throw new Exception("The customer plan has not schedules");

            planTimes = planTimes.Where(x => x.WeekId == dayWeek);

            var valid = false;
            foreach (var planTime in planTimes)
            {
                var startTime = TimeSpan.Parse(planTime.StartTime);
                var endTime = TimeSpan.Parse(planTime.EndTime);

                if (timeIn >= startTime && timeIn <= endTime)
                {
                    valid = true;
                    break;
                }
            }

            if (!valid)
                throw new Exception("Customer is not authorized to enter at this time");

            valid = false;
            var entriesPerDay = customer.Plan.EntriesPerDay;
            var entries = customer.Entries.Count();

            if (entriesPerDay <= entries)
                throw new Exception($"Customer cannot access due to plan limit: Entries={entries} | Max={entriesPerDay}");
        }
    }
}
