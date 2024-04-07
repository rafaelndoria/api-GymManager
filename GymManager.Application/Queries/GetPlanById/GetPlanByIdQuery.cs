using GymManager.Application.ViewModels;
using MediatR;

namespace GymManager.Application.Queries.GetPlanById
{
    public class GetPlanByIdQuery : IRequest<PlanViewModel>
    {
        public GetPlanByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
