using GymManager.Application.ViewModels;
using MediatR;

namespace GymManager.Application.Queries.GetPlanTimeByIdPlan
{
    public class GetPlanTimeByIdPlanQuery : IRequest<IEnumerable<PlanTimeViewModel>>
    {
        public GetPlanTimeByIdPlanQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
