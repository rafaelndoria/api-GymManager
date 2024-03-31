namespace GymManager.Core.Entities
{
    public class PlanTime : Entity
    {
        public PlanTime(string startTime, string endTime, int weekId, int planId)
        {
            StartTime = startTime;
            EndTime = endTime;
            WeekId = weekId;
            PlanId = planId;
        }

        public string StartTime { get; private set; }
        public string EndTime { get; private set; }

        public int WeekId { get; private set; }
        public Week? Week { get; private set; }
        public int PlanId { get; private set; }
        public Plan? Plan { get; private set; }

        public void Update(string startTime, string endTime)
        {
            StartTime = startTime;
            EndTime = endTime;
        }
    }
}
