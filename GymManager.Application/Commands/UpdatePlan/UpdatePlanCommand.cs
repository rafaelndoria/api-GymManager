using MediatR;

namespace GymManager.Application.Commands.UpdatePlan
{
    public class UpdatePlanCommand : IRequest<bool>
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int EntriesPerDay { get; set; }
        public int PlanTypeId { get; set; }
    }
}
