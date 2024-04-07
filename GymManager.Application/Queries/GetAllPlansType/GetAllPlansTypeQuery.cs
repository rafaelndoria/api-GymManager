using GymManager.Application.ViewModels;
using MediatR;

namespace GymManager.Application.Queries.GetAllPlansType
{
    public class GetAllPlansTypeQuery : IRequest<IEnumerable<PlansTypeViewModel>>
    {
        public GetAllPlansTypeQuery(string query)
        {
            Query = query;
        }

        public string Query { get; private set; }
    }
}
