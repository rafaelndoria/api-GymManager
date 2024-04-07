using GymManager.Application.ViewModels;
using MediatR;

namespace GymManager.Application.Queries.GetAllPlans
{
    public class GetAllPlansQuery : IRequest<IEnumerable<PlanViewModel>>
    {
        public GetAllPlansQuery(string query)
        {
            Query = query;
        }

        public string Query { get; private set; }
    }
}
