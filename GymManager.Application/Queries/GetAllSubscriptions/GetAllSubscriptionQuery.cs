using GymManager.Application.ViewModels;
using MediatR;

namespace GymManager.Application.Queries.GetAllSubscriptions
{
    public class GetAllSubscriptionQuery : IRequest<IEnumerable<SubscriptionViewModel>>
    {
        public GetAllSubscriptionQuery(string query)
        {
            Query = query;
        }

        public string Query { get; private set; }
    }
}
