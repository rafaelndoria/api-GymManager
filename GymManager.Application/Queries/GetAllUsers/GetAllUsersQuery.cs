using GymManager.Application.ViewModels;
using MediatR;

namespace GymManager.Application.Queries.GetAllUsers
{
    public class GetAllUsersQuery : IRequest<IEnumerable<UserViewModel>>
    {
        public GetAllUsersQuery(string query)
        {
            Query = query;
        }

        public string Query { get; private set; }
    }
}
