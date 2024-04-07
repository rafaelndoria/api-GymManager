using MediatR;

namespace GymManager.Application.Commands.CreatePlan
{
    public class CreatePlanCommand : IRequest<int>
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int EntriesPerDay { get; set; }
        public int PlanTypeId { get; set; }
    }
}
