using GymManager.Application.ViewModels;
using MediatR;

namespace GymManager.Application.Queries.GetDetailsPlan
{
    public class GetDetailsPlanQuery : IRequest<PlanDetailsViewModel>
    {
        public GetDetailsPlanQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
