using GymManager.Application.ViewModels;
using MediatR;

namespace GymManager.Application.Queries.GetSubscriptionById
{
    public class GetSubscriptionByIdQuery : IRequest<SubscriptionViewModel>
    {
        public GetSubscriptionByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
