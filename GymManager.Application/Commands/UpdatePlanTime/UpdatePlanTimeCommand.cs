using MediatR;

namespace GymManager.Application.Commands.UpdatePlanTime
{
    public class UpdatePlanTimeCommand : IRequest<bool>
    {
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public int PlanId { get; set; }
        public int? PlanTimeId { get; set; }
    }
}
