namespace GymManager.Application.ViewModels
{
    public class PlanTimeViewModel
    {
        public PlanTimeViewModel(int id, string dayWeek, int planId, string startTime, string endTime)
        {
            Id = id;
            DayWeek = dayWeek;
            PlanId = planId;
            StartTime = startTime;
            EndTime = endTime;
        }

        public int Id { get; private set; }
        public string DayWeek { get; private set; }
        public int PlanId { get; private set; }
        public string StartTime { get; private set; }
        public string EndTime { get; private set; }
    }
}
