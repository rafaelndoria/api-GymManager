using MediatR;

namespace GymManager.Application.Commands.AddPlanTime
{
    public class AddPlanTimeCommand : IRequest<bool>
    {
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public int DayWeekId { get; set; }
        public int PlanId { get; set; }
    }
}
